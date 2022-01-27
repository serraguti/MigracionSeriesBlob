using MigracionSeriesBlob.Data;
using MigracionSeriesBlob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MigracionSeriesBlob.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }

        public void UpdateImagenPersonaje(int idpersonaje, string imagen)
        {
            Personaje p = this.context.Personajes.SingleOrDefault(x => x.IdPersonaje == idpersonaje);
            p.Imagen = imagen;
            this.context.SaveChanges();
        }

        public void UpdateImagenSerie(int idserie, string imagen)
        {
            Serie serie = this.context.Series.SingleOrDefault(x => x.IdSerie == idserie);
            serie.Imagen = imagen;
            this.context.SaveChanges();
        }
    }
}
