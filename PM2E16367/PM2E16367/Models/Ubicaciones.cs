using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E16367.Models
{
    public class Ubicaciones
    {
       
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public string latitud { get; set; }

        public string longitud { get; set; }

        [MaxLength(100)]
        public string descripcionl { get; set; }

        [MaxLength(100)]
        public string descripcionc { get; set; }
       
    }
}
