using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Passageiro> passageiros { get; set; }
        public DbSet<Motorista> motoristas { get; set; }
        public DbSet<Contato> contatos { get; set; }
    }
}

