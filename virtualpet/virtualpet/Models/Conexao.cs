using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;


namespace virtualpet.Models
{
    public class Conexao
    {
        public IMongoDatabase GetConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("testedb");
            return database;
        }
        public IMongoCollection<Pet> GetPetCollection()
        {
            var database = GetConnection();
            var CollectionPet = database.GetCollection<Pet>("pett");
            return CollectionPet;
        }
        public IMongoCollection<Usuario> GetUsuarioCollection()
        {
            var database = GetConnection();
            var CollectionUsario = database.GetCollection<Usuario>("usuario");
            return CollectionUsario;
        }

    }
}