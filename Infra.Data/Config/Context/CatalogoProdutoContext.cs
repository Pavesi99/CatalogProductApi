
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class CatalogoProdutoContext : DbContext
    {
        public CatalogoProdutoContext(DbContextOptions<CatalogoProdutoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new CatalogoProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
