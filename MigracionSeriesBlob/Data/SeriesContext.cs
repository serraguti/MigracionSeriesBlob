using Microsoft.EntityFrameworkCore;
using MigracionSeriesBlob.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigracionSeriesBlob.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options)
            :base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
