using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using virtualpet.Models;
using MongoDB.Driver;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Web.Services;

namespace virtualpet
{
    public partial class principal : System.Web.UI.Page
    {
        public HtmlGenericControl healthBar { get; set; }
        public HtmlGenericControl happyBar { get; set; }
        public HtmlGenericControl hungryBar { get; set; }
        public HtmlGenericControl Pts { get; set; }
        private IMongoDatabase db { get; set; }
        public String username { get; set; }
        public String petname { get; set; }
        public Pet pet { get; set; }

        public principal()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.healthBar = Page.FindControl("health") as HtmlGenericControl;
            this.happyBar = Page.FindControl("happy") as HtmlGenericControl;
            this.hungryBar = Page.FindControl("hungry") as HtmlGenericControl;
            this.Pts = Page.FindControl("pts") as HtmlGenericControl;
            this.db = new Conexao().GetConnection();

            this.username = Session["Auth"].ToString();
            this.petname = Request.QueryString["petnome"].ToString();
            Session["petLogged"] = petname;

            pet = new Pet().getPet(db, username, petname);
            
            if (pet.Estado != "dormindo") {
                Debug.WriteLine("update");
                updateEstado(sender, e);
            }
            labelestado.Text = pet.Estado;
            
            if (pet.Estado == "doente") { updateDoente(sender,e); }
            else if (pet.Estado == "faminto") { updateFaminto(sender, e); }
            else if(pet.Estado == "triste") { updateTriste(sender, e); }
            else if(pet.Estado == "morto") { pet.Fome = 0; pet.Saude = 0; pet.Felicidade = 0; }
            else { updateNormal(sender, e); }



            if (pet.Fome < 0) { pet.Fome = 0; }
            if (pet.Saude < 0) { pet.Saude = 0; }
            if (pet.Felicidade < 0) { pet.Felicidade = 0; }

            if (pet.Fome > 100) { pet.Fome = 100; }
            if (pet.Saude > 100) { pet.Saude = 100; }
            if (pet.Felicidade > 100) { pet.Felicidade = 100; }

            healthBar.Style.Add("width", pet.Saude + "%");
            hungryBar.Style.Add("width", pet.Fome + "%");
            happyBar.Style.Add("width", pet.Felicidade + "%");

            pet.Update_Pet(pet.Fome, pet.Saude, pet.Felicidade,pet, DateTime.UtcNow, pet.Estado);
            
        }
        protected void updateNormal(object sender, EventArgs e)
        {
            int deltaTime = (int)Math.Ceiling(DateTime.UtcNow.Subtract(pet.Tempo).TotalMinutes);
            pet.Fome -= deltaTime;
            pet.Saude -= deltaTime;
            pet.Felicidade -= deltaTime;

        }
        protected void updateDoente(object sender, EventArgs e)
        {
            int deltaTime = (int)Math.Ceiling(DateTime.UtcNow.Subtract(pet.Tempo).TotalMinutes);
            pet.Fome -= deltaTime*2;
            pet.Saude -= deltaTime*3;
            pet.Felicidade -= deltaTime;    

        }
        protected void updateTriste(object sender, EventArgs e)
        {
            int deltaTime = (int)Math.Ceiling(DateTime.UtcNow.Subtract(pet.Tempo).TotalMinutes);
            pet.Fome -= deltaTime;
            pet.Saude -= deltaTime*2;
            pet.Felicidade -= deltaTime*2;

        }
        protected void updateFaminto(object sender, EventArgs e)
        {
            int deltaTime = (int)Math.Ceiling(DateTime.UtcNow.Subtract(pet.Tempo).TotalMinutes);
            pet.Fome -= deltaTime*3;
            pet.Saude -= deltaTime*2;
            pet.Felicidade -= deltaTime;

        }

        protected void updateEstado(object sender, EventArgs e)
        {
            if (pet.Fome <= 0 || pet.Saude <= 0 || pet.Felicidade <= 0)
            {
                pet.Estado = "morto";
            }
            else if (pet.Saude < 35)
            {
                pet.Estado = "doente";
            }
            else if (pet.Felicidade < 35)
            {
                pet.Estado = "triste";
            }
            else if (pet.Fome < 35)
            {
                pet.Estado = "faminto";
            }
            else
            {
                pet.Estado = "normal";
            }

        }

        protected void Feed(object sender, EventArgs e)
        {
            if (pet.Estado == "morto" || pet.Estado == "dormindo") { }
            else
            {
                pet.Fome += 20;
                pet.Update_Pet(pet.Fome, pet.Saude, pet.Felicidade, pet, DateTime.UtcNow, pet.Estado);

            }
        }

        protected void Cure(object sender, EventArgs e)
        {
            if (pet.Estado == "morto" || pet.Estado == "dormindo") { }
            else
            {
                pet.Saude += 20;
                pet.Update_Pet(pet.Fome, pet.Saude, pet.Felicidade, pet, DateTime.UtcNow, pet.Estado);
            }
        }

        protected void Sair(object sender, EventArgs e)
        {
            if (pet.Estado == "morto" || pet.Estado == "dormindo") { }
            else
            {
                pet.Felicidade += 100;
                pet.Update_Pet(pet.Fome, pet.Saude, pet.Felicidade, pet, DateTime.UtcNow, pet.Estado);
            }
        }

        protected void excluir_Click(object sender, EventArgs e)
        {
            pet.Delete(pet);
            Response.Redirect("/meuspet.aspx");
        }

        protected void reinicar_Click(object sender, EventArgs e)
        {
            pet.Delete(pet);
            pet.criarPet(username, pet.nomePet, 0);
            Debug.WriteLine("Reviveu");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if(pet.Estado == "dormindo") {
                pet.Estado = "normal";
                pet.Update_Pet(pet.Fome, pet.Saude, pet.Felicidade, pet, DateTime.UtcNow, pet.Estado);
                Debug.WriteLine(pet.Estado);
            }
            else
            {
                pet.Estado = "dormindo";
                labelestado.Text = pet.Estado;
                pet.Update_Pet(pet.Fome, pet.Saude, pet.Felicidade, pet, DateTime.UtcNow, pet.Estado);
                Debug.WriteLine(pet.Estado);
            }

        }
    }
}