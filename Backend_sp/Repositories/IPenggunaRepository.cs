namespace Backend_sp.Repositories;

// Interface Definition
public interface IPenggunaRepository
{
    // Method Signature (Kontrak)
    Task<penggunaLogin?> LoginAsync(string username, string password);

    Task<List<InformasiView>> ViewAsync();

}
