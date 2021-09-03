using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace TravelAgency.Client
{
    internal class ClientiContext : DbContext
    {

        public DbSet<Clienti> Clienti { get; set; }
        public DbSet<Polizze> Polizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		Database=Assicurazione;Trusted_Connection=True;");
        }

    }
}