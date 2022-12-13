<h1 align=center>Avarice backend</h1>
<p align=center>
  Backend for the Avarice mobile & web application.
</p>

<p align="center">
  <samp>
    <a href="https://github.com/MatijaNovosel/avarice">🌟 Web</a> |
    <a href="https://github.com/MatijaNovosel/avarice-mobile">📱 Mobile</a>
  </samp>
</p>

## 🔨 Built With

- [MySQL](https://www.mysql.com/)
- [.NET Core](https://dotnet.microsoft.com/en-us/)

## Set up the backend

### Install the dot net core dependencies

```bash
dotnet restore
```

### Restore the MySQL database

```bash
dotnet ef database update
```

### Set the local MySQL connection string

```bash
dotnet user-secrets set "connectionString" "Server={server};Database={db};Uid={uid};Pwd={pwd};"
```

### Set the 16 character JWT signing key

```bash
dotnet user-secrets set "secretKey" "{key}"
```

### Run the backend

```bash
dotnet run
```
