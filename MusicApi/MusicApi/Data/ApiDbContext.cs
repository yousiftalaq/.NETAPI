using Microsoft.EntityFrameworkCore;
using MusicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {

        }

        public DbSet<Song> Songs { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id=1,
                    Title="Yousif",
                    Language=".Net Core",
                    Duration="5"
                }, new Song
                {
                    Id = 2,
                    Title = "Mhomhed",
                    Language = "VueJs",
                    Duration = "7"
                }
                );
        }
    }
}
