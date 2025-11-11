using Dapper;
using System.Data;
using Backend_sp.Data;

namespace Backend_sp.Repositories;

public class PenggunaRepository : IPenggunaRepository {
    private readonly DapperContext _ctx;
    public PenggunaRepository(DapperContext ctx) { _ctx = ctx; }

    public async Task<penggunaLogin?> LoginAsync(string nama, string password) {
        const string sp = "dbo.sp_GetPenggunaLogin";

        var p = new DynamicParameters();
        p.Add("@nama", nama, DbType.AnsiString, size: 50);   // varchar -> AnsiString
        p.Add("@sandi", password, DbType.AnsiString, size: 50);   // varchar -> AnsiString

        using var conn = _ctx.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<penggunaLogin>(
            sp, p, commandType: CommandType.StoredProcedure);
    }
}
