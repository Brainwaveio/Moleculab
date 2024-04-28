### Scaffold-DbContext

navigate to project folder:

```
cd .\SchoolSoft.API.DAL\
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
--context QuantumQueryDbContext `
--context-dir Context `
--output-dir Models `
--no-onconfiguring `
--force `
--verbose
```
