using Microsoft.EntityFrameworkCore;
using ProjetoRPGProver.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetoRPGProver.Contexto
{
    public class PersonagemContexto:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=localhost;Database=PersonagemDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet <Personagem> Personagens { get; set; }
        public DbSet<Poder> Poderes { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<Armadura> Armaduras { get; set; }
        public DbSet<Atributo> Atributos { get; set; }








        


    }
}
