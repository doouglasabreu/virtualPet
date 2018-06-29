using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using virtualpet.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace virtualpet
{
    public partial class meuspet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Update()
        {

        }

        protected List<Pet> meusPets()
        {
            var CollectionPet = new Conexao().GetPetCollection();
            var res = CollectionPet.Find(x => x.nomeUsuario == Session["Auth"].ToString()).ToList().OrderByDescending(s => s.pontos).ToList();
            if (res.Count() != 0)
            {
                return res;
            }
            else
            {
                return null;
            }
        }
        public void criarPet(object sender, EventArgs e)
        {
            var UserLogged = Session["Auth"];
            string Nome = nomedoPet.Text;
            Pet pet = new Pet().criarPet(UserLogged.ToString(), Nome, 0);
            Page_Load(sender, e);
        }
    }
}