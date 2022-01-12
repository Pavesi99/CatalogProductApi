using Domain.Models;

namespace Domain.Interfaces.NomeDaBase
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Categoria Cadastrar(Categoria produto);
        Categoria Buscar(int categoriaId);
        Categoria Deletar(int categoriaId);
    }
}
