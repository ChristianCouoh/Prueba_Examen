using Gestion_Asistencias.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gestion_Asistencias.Context
{
    public class DataStoreZ: DbContext
    {
        public DbSet<Profesores> Profesoress { get; set; }
    }
}