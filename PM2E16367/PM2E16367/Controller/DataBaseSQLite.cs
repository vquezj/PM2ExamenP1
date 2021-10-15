using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2E16367.Models;
using SQLite;

namespace PM2E16367.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //Constructor de la clase DataBaseSQLite
        public DataBaseSQLite(string pathdb)
        {
            //crear conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            //crear la tabla ubicaciones dentro de sqlite
            db.CreateTableAsync<Ubicaciones>().Wait();
        }

        //Operaciones CRUD con SQLite
        //READ List way
        public Task<List<Ubicaciones>> ObtenerListaUbicaciones()
        {
            return db.Table<Ubicaciones>().ToListAsync();
        }

        //READ on by one
        public Task<Ubicaciones> ObtenerUbicacion(int pcodigo)
        {
            return db.Table<Ubicaciones>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //CREATE ubicacion
        public Task<int> GrabarUbicacion(Ubicaciones ubicacion)
        {//si es distinto de cero la actualiza sino inserta
            if (ubicacion.codigo != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }

        //DELETE
        public Task<int> EliminarUbicacion(Ubicaciones ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }
    }
}
