# SalesWebMVCNewVersion
Uma aplicação web desenvolvida com ASP.NET Core MVC no curso "C# COMPLETO Programação Orientada a Objetos + Projetos" do [Nélio Alves](https://www.udemy.com/user/nelio-alves/?srsltid=AfmBOopB7HoTclAcfBbuDteZLK_-IUAxQQvaezeBD_11i05OlSBFbJiI). Está aplicação serve para gerenciar vendas e vendedores, com suporte a relatórios e filtragem de dados.

🚀 Funcionalidades

- Cadastro de vendedores e vendas
- Relatórios de vendas filtrados por data
- Listagem detalhada e visão geral das vendas

🛠️ Tecnologias Utilizadas

- Backend: ASP.NET Core MVC (C#)
- Frontend: HTML, CSS, Bootstrap
- Banco de Dados: SQL Server ou MySQL
- ORM: Entity Framework Core

📋 Pré-requisitos

- .NET SDK
- SQL Server ou MySQL configurado

⚙️ Configuração do Projeto

- Clone o repositório:
git clone https://github.com/mariaedutt/SalesWebMVCNewVersion.git

- Restaure as dependências:
dotnet restore
Configure o appsettings.json para a conexão com o banco de dados.

- Execute as migrações:
dotnet ef database update

- Inicie o servidor:
dotnet run
