using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;
using Werter.Dogs.Servicos.ServicosDeFoto;
using Werter.Dogs.WebApi.Configuracoes;

namespace Werter.Dogs.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        private readonly IRepositorioFoto _repositorioFoto;
        private readonly ConfiguracaoAplicacao _configuracao;
        private readonly ServicosDeFotos _servicosDeFotos;

        public FotoController(
            IRepositorioFoto repositorioFoto,
            ConfiguracaoAplicacao configuracaoAplicacao,
            ServicosDeFotos servicosDeFotos
        )
        {
            _repositorioFoto = repositorioFoto;
            _configuracao = configuracaoAplicacao;
            _servicosDeFotos = servicosDeFotos;
        }

       

        [HttpPost]
        [Route("incrementar-acesso")]
        public IActionResult IncrementarQtdAcessos([FromBody]RequisitosParaIncrementarAcesso requisitos)
        {
            var resultado = _servicosDeFotos.LidarCom(requisitos);
            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult AtualizarFoto([FromBody]RequisitosParaAtualizarFoto requisitos)
        {
            var resultado = _servicosDeFotos.LidarCom(requisitos);
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletarFoto([FromRoute] RequisitosParaExcluirFoto requisitos)
        {
            var resultado = _servicosDeFotos.LidarCom(requisitos);
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        

        #region [ Cadastrar Foto ]

        [HttpPost]
        public IActionResult Cadastrar(
            List<IFormFile> files,
            [FromForm] RequisitosParaCadastrarFoto requisitos
        )
        {
            var arquivoPostado = files.FirstOrDefault();
            
            // TODO: Definir 2 MB como tamanho maximo. Validar extenção do arquivo
            var arquivoInvalido = (arquivoPostado.Length <= 0);
            if (arquivoInvalido)
                return StatusCode(417, new {Mensagem = "Arquivo ou imagem inválida"});

            var resultado = _servicosDeFotos.LidarCom(requisitos);
            if (!resultado.Sucesso)
                return BadRequest(resultado);

            GravarFotoNoDiretorio(resultado, arquivoPostado);

            return Ok(resultado);
        }

        private string MontarFullPathArquivo(IFormFile arquivoPostado, Foto foto)
        {
            var nomeArquivo = MontarNomeArquivo(arquivoPostado, foto);
            var arquivo = Path.Combine(_configuracao.DiretorioImagens, nomeArquivo);
            return arquivo;
        }

        private static string MontarNomeArquivo(IFormFile arquivoPostado, Foto foto)
        {
            var extencao = ObterExtencaoArquivo(arquivoPostado);
            var nomeArquivo = $"{foto.Id.ToString()}.{extencao}";
            return nomeArquivo;
        }

        private static string ObterExtencaoArquivo(IFormFile arquivoPostado)
        {
            var split = arquivoPostado.FileName.Split('.');
            var extencao = split[split.Length -1];
            return extencao;

        }
        
        private void GravarFotoNoDiretorio(IResultado resultado, IFormFile arquivoPostado)
        {
            var foto = (Foto) resultado.Dados;

            var arquivo = MontarFullPathArquivo(arquivoPostado, foto);
            using (var stream = System.IO.File.Create(arquivo))
            {
                arquivoPostado.CopyTo(stream);
            }
        }
        
        #endregion
    }
}