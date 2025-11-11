using System.Data;
using Microsoft.Data.SqlClient;

namespace Backend_sp.Data;

public class DapperContext
{
    private readonly IConfiguration _cfg;
    public DapperContext(IConfiguration cfg) { _cfg = cfg; }
    public IDbConnection CreateConnection()
        => new SqlConnection(_cfg.GetConnectionString("DefaultConnection"));
}
