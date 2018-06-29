using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using virtualpet.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace virtualpet
{
    public partial class ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Pet> getRank()
        {
            var CollectionPet = new Conexao().GetPetCollection();
            var res = CollectionPet.Find(x => x.Estado != "morto").ToList().OrderBy(s => s.Criacao).ToList();
            if (res.Count() != 0)
            {
                return res;
            }
            else
            {
                return null;
            }
            
        }
    }
}