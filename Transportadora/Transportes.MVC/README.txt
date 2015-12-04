Autor?:Sebastiao Valfrides Siqueira

O Projeto:
O Projeto foi desenvolvido através de uma arquitetura DDD (Domain Drive Designer) Code First.
Usando CSS boostrap(bootswach).
Contendo 5 Projetos
0 _ Presentation - Camado de visão para o usuario;
1 - Service - Contendo um projeto para validação CPF, RG IE e outros se precisar;
2 - Application - Camada chamada para realizar os Crud;
3 - Domain - Camada que contem as classes dos dominios que podem conter as regras de negócios;
4 - Infra - Projeto que contem as DBContext e as classes de migration que cria o banco a partir da aplicação.

Para rodar a aplicação
1 - Acessar o Projeto Dentro da pasta 0 -Presentation e mudar o web config colocar o local que deseja executar localmente ou algum banco que tenha acesso.

2 - Entrar na camada de Infra Dentro de pasta 4.1 Projeto -Transportes.Infra.Data.
Depois acessar Package Manager Console e digitar o comando (Update-Database _Verbose) para criar o banco de dados que ja estará incluso o usuario Sebastiao Valfrides Siqueira. Mas voce poderá criar o usuario depois.
