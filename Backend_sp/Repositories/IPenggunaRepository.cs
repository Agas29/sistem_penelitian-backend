namespace Backend_sp.Repositories;

public interface IPenggunaRepository
{
    Task<penggunaLogin?> LoginAsync(string username, string password);
}
