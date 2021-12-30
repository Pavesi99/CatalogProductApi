using Domain.Models;
using Havan.Logistica.Core.Repository;
using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.NomeDaBase
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Categoria Cadastrar(Categoria produto);
        Categoria Buscar(int categoriaId);
        Categoria Deletar(int categoriaId);
    }
}
