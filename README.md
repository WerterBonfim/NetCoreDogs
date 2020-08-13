Passos:
1 - Fazer o build do docker file com o seguinte comando:
	docker build --tag imagem-sql-nonroot

2 - Criar o container:
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=!123Dogs' --name sql -p 1433:1433 -d imagem-sql-nonroot

3 - Rodar as migrations com o seguinte comando na pasta NetCoreDogs.Infra:
	netcore ef migration run
	netcore ef database update
