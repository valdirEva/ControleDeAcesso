using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeAcesso.Models;

namespace ControleDeAcesso.Data
{
    public class ControleDeAcessoContext : DbContext
    {
        public ControleDeAcessoContext (DbContextOptions<ControleDeAcessoContext> options)
            : base(options)
        {
        }

        public DbSet<ControleDeAcesso.Models.Apartamento> Apartamento { get; set; }
    }
}
