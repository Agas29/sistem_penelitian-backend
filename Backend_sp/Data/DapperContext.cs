// Using Statements
using System.Data;
using Microsoft.Data.SqlClient;

// Namespace Declaration
namespace Backend_sp.Data;

// Class Declaration
public class DapperContext
{
    // Constructor
    private readonly IConfiguration _cfg;
    public DapperContext(IConfiguration cfg) { _cfg = cfg; }

    // Method CreateConnection
    public IDbConnection CreateConnection()
        => new SqlConnection(_cfg.GetConnectionString("DefaultConnection"));
}
