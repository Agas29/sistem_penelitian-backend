//  Using Statements
using Dapper;
using System.Data;
using Backend_sp.Data;

namespace Backend_sp.Repositories;

// Class Definition & Inheritance
public class PenggunaRepository : IPenggunaRepository{

    //  Dependency Injection - Constructor
    private readonly DapperContext _ctx;
    public PenggunaRepository(DapperContext ctx) { _ctx = ctx; }

    // Method Implementation
    public async Task<penggunaLogin?> LoginAsync(string nama, string password) {
        // Stored Procedure
        const string sp = "dbo.sp_GetPenggunaLogin";

        // DynamicParameters
        var p = new DynamicParameters();
        p.Add("@nama", nama, DbType.AnsiString, size: 50);   // varchar -> AnsiString
        p.Add("@sandi", password, DbType.AnsiString, size: 50);   // varchar -> AnsiString

        // Execute Query
        using var conn = _ctx.CreateConnection();

        return await conn.QueryFirstOrDefaultAsync<penggunaLogin>(
            sp, p, commandType: CommandType.StoredProcedure);
    }


    public async Task<List<InformasiView>> ViewAsync()
    {
        const string sp = "dbo.sp_GetInformasiView";

        using var conn = _ctx.CreateConnection();

        var result = await conn.QueryAsync<InformasiView>(
        sp, commandType: CommandType.StoredProcedure);

        return result.ToList();
    }


   
}
