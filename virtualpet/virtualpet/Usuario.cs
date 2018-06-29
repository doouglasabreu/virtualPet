using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson; 

namespace virtualpet.Models
{
    public class Usuario
    {
        public ObjectId Id { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }

        public Usuario CreateUser(string nome, string senha)
        {
            if (nome == "" && senha == "") { return null; }
            var CollectionUsuario = new Conexao().GetUsuarioCollection();
            Usuario usuario = new Usuario
            {
                Nome = nome,
                Senha = senha
            };

            CollectionUsuario.InsertOne(usuario);
            return usuario;
        }

        public Usuario Validar(IMongoCollection<Usuario> users, string username, string password)
        {
            var res = users.Find(x => x.Nome == username && x.Senha == password).ToList();
            if (res.Count() != 0)
            {
                return res.ToList().First();
            }
            else
            {
                return null;
            }
        }
    }

}