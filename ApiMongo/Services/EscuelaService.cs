﻿using ApiMongo.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ApiMongo.Services
{
    public class EscuelaService
    {
        private IMongoCollection<Alumnos> _alumnos;

        public EscuelaService(IEscuelaSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _alumnos = database.GetCollection<Alumnos>(settings.Collection);
        }

        public List<Alumnos> Get() //Obtener los regstro de la BD
        {
            return _alumnos.Find(d => true).ToList();
        }

        public Alumnos Create(Alumnos alumnos) //Para agregar un alumno nuevo
        {
            _alumnos.InsertOne(alumnos);
            return alumnos;
        }

        public void Update(string id, Alumnos alumnos)
        {
            _alumnos.ReplaceOne(alumnos => alumnos.Id == id, alumnos);
        }

        public void Delete(string id)
        {
            _alumnos.DeleteOne(d => d.Id == id);
        }
    }
}
