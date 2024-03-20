<h1>Ocian-Net</h1>

> <p>Example of backend using the company Ocian - Barra Bonita.</p>

<p> Project made in C# - AspNet Core containing 3 contact forms stored in the Postgresql database and another for resumes sent via email.</p>
<br/>
<p>Obs: This is another version of the same API in Rust but rewritten in C#.</p>

<h2>Build</h2>
<p>To compile the project, download the repository and run the following command:</p>

    $ dotnet run

<br/>
<p>Create the .env file in the project root with the following example information:</p>

    SERVER="yourserver.com"
    DATABASE_NAME="your_database_name"
    PORT="5432"
    DB_USER="your_database_user"
    DB_PASSWORD="your_database_password"
    
    HOST="smtp.gmail.com"
    USERNAME="yourgmailfrom@gmail.com"
    PASSWORD="your_smtp_account_password"
    EMAIL="yourgmailto@gmail.com"


<p>Remembering that the information above is TOTALLY an example, so it is possible to use any other SMTP server, for example.</p>
<br/>

<h2>Testing API</h2>
<p>To test the API, run the project:</p>

    $ dotnet run

<p>If something similar to: </p>

    info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5156

<p>Copy the address and in a browser put for example: 

  http://localhost:5156/swagger/index.html</p>
<p>After inserting the modified url, the default swagger page should appear with the test routes.</p>
