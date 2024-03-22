using AlunosApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Aluno>().HasData(
        //        new Aluno
        //        {
        //            Id = 1,
        //            Nome = "Gabriel Ferreira",
        //            Email = "GabrielFerreira@gmail.com",
        //            Idade = 22
        //        }, new Aluno
        //        {
        //            Id = 2,
        //            Nome = "Renato Ferreira",
        //            Email = "RenatoFerreira@gmail.com",
        //            Idade = 25
        //        });
        //}

    }
}
