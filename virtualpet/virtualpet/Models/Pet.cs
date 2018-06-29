using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace virtualpet.Models
{
    public class Pet
    {
        public ObjectId Id { get; set; }
        public String nomePet { get; set; }
        public String nomeUsuario { get; set; }
        public String Estado { get; set; }
        public double Fome { get; set; }
        public double Felicidade { get; set; }
        public double Saude { get; set; }
        public double Sono { get; set; }
        public DateTime Tempo { get; set; }
        public DateTime Criacao { get; set; } 
        public bool Ativo { get; set; }
        public int pontos { get; set; }

        public Pet criarPet(String nomeUsuario, String nomePet, int pnts)
        {
            var db = new Conexao().GetConnection();
            var colecaoPet = new Conexao().GetPetCollection();
            Pet pet = new Pet()
            {
                pontos = pnts,
                nomeUsuario = nomeUsuario,
                nomePet = nomePet,
                Saude = 100.00,
                Sono = 100.00,
                Fome = 100.00,
                Felicidade = 100.00,
                Estado = "normal",
                Tempo = DateTime.UtcNow,
                Criacao = DateTime.UtcNow,
            };
            colecaoPet.InsertOne(pet);
            return pet;
        }

        public Pet getPet(IMongoDatabase database, string nome_UserLogged, string nome_TamagotchiLogged)
        {
            var tamagotchis = database.GetCollection<Pet>("pett");
            var res = tamagotchis.Find(x => x.nomeUsuario == nome_UserLogged && x.nomePet == nome_TamagotchiLogged);
            if (res.Count() != 0)
            {
                return res.ToList().First();
            }
            else
            {
                return null;
            }
        }
        public Pet Update_Pet(double fome, double saude, double felicidade, Pet p, DateTime tempo,String estado)
        {
            var tamagotchis = new Conexao().GetPetCollection();
            var filtro = Builders<Pet>.Filter.Where(x => x.nomePet == p.nomePet);
            var change = Builders<Pet>.Update.Set(x => x.Fome, fome)
                                                    .Set(x => x.Saude, saude)
                                                    .Set(x => x.Tempo, tempo)
                                                    .Set(x => x.Felicidade, felicidade)
                                                    .Set(x => x.Estado, estado);

            tamagotchis.UpdateOne(filtro, change);
            return p;
        }

        public void Delete(Pet p)
        {
            var tamagotchis = new Conexao().GetPetCollection();
            var filtro = Builders<Pet>.Filter.Where(x => x.nomePet == p.nomePet);
            tamagotchis.FindOneAndDelete(filtro);
        }

        public void Feed()
        {
            this.Fome += 10;
        }

        public void Flush()
        {
            this.Saude += 10;
        }

        public void Play()
        {
            this.Felicidade += 10;
        }

        public void Cure()
        {
            // not implemented
        }

        public void Lights()
        {
            // not implemented
        }

    }
}