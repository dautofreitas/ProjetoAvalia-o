# ProjetoAvaliação

Para a configuração da aplicação é necessário realizar os procedimentos abaixo:

Configurar a string de conexão da base de dados no arquivo "Web.config".

A conexão deve possuir o atributo name com o valo "GeaContext" conforme exemplo abaixo:

<connectionStrings>
    <add name="GeaContext" connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GEABANCO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient" />
     
 </connectionStrings>

Executar o Script  configuração da base de dados que estão no arquivo "ScriptDeCriação.sql"

Após a execução do Script será possível logar na aplicação com as seguintes credenciais: 

Login: admin

Senha: admin

Tipo: Administrador

----------------------
Login: normal

Senha: normal

Tipo: Normal


