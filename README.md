<h1>Lift+  </h1>  
API em ASP.NET para Aplicação Mobile desenvolvida em Java para o projeto disciplinar da matéria PAM
        <div>
        <h1> Dupla </h1>
        <h3> Lauan Amorim </h3>
        <h3> Lucas Gabriel </h3>
        </div>

# Rodando o projeto
## Requisitos
<ul>
        <li>Visual Studio 2022</li>
        <li>.Net Core SDK</li>
        <li>Pacote <a href="https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql" target="_blank">Pomelo.EntityFrameworkCore.MySql </a>(7.0.0)</li>
        <li>MySQL Workbench 8.0.33 ou superior</li>
</ul>

## Instalação

Primeiro clone o projeto para sua máquina local

```bash
git clone https://github.com/macedolg/LiftPLUS.git
```
## Criar e utilizar o banco de dados
Baixe e execute a query <a href="https://github.com/macedolg/LiftPLUS/blob/main/dbLiftPLUS.sql" target="_blank">dbLiftPLUS.sql</a> no seu MySQL Workbench. <br/>
Abra o arquivo appsettings.json em seu projeto e atualize a seção ConnectionStrings com as informações do seu banco de dados MySQL:
```bash
// ...
{
  "ConnectionStrings": {
    "DataBase": "Server=seu-server;Database=dbLiftPLUS;User=seu-user;Password=12345678;Port=3306;"
  },
  // ...
}
```
Note que a configuração padrão do projeto está para:
```bash
// ...
{
  "ConnectionStrings": {
    "DataBase": "Server=localhost;Database=dbLiftPLUS;User=root;Password=12345678;Port=3306;"
  },
  // ...
}
```

## Rodando o projeto
Dentro da raiz do projeto, execute
```bash
dotnet run
```
