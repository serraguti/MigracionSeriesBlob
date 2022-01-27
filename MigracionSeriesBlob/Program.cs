using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MigracionSeriesBlob.Data;
using MigracionSeriesBlob.Models;
using MigracionSeriesBlob.Repositories;
using System;
using System.Collections.Generic;

namespace MigracionSeriesBlob
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlpersonajes = "https://storageazurepgss.blob.core.windows.net/personajes/";
            string urlseries = "https://storageazurepgss.blob.core.windows.net/series/";
            string cadena = "Data Source=sqlandaluciapgs.database.windows.net;Initial Catalog=AZUREDATABASE;Persist Security Info=True;User ID=adminsql;Password=Admin123";
            var provider =
                new ServiceCollection()
                .AddTransient<RepositorySeries>()
                .AddDbContext<SeriesContext>
                (options => options.UseSqlServer(cadena))
                .BuildServiceProvider();
            RepositorySeries repo = provider.GetService<RepositorySeries>();
            List<Serie> series = repo.GetSeries();
            foreach (Serie s in series)
            {
                repo.UpdateImagenSerie(s.IdSerie, urlseries + s.Imagen);
            }
            List<Personaje> personajes = repo.GetPersonajes();
            foreach (Personaje p in personajes)
            {
                repo.UpdateImagenPersonaje(p.IdPersonaje, urlpersonajes + p.Imagen);
            }
            Console.WriteLine("Listo");
        }
    }
}
