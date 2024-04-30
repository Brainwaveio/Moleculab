### Scaffold-DbContext

navigate to project folder:

```
cd .\Moleculab.DAL.SQLite\
```

run scaffolding:
_replace conneciton string with yours if needed_

```
dotnet ef dbcontext scaffold `
"Data Source=F:\Projects\src\QuantumQuery\Database\QuantumQuerySQLite.db" `
Microsoft.EntityFrameworkCore.Sqlite `
`
--table Element `
`
--data-annotations `
--context MoleculabDbContext `
--context-dir Context `
--output-dir Models `
--no-onconfiguring `
--force `
--verbose
```
