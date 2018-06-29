using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Driver;
using virtualpet.Models;

namespace virtualpet
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Btn_Entrar(object sender, EventArgs e)
        {
            String user = nome.Text;
            String pass = senha.Text;
            var usuario = new Conexao().GetUsuarioCollection();
            Usuario UserLogged = new Usuario().Validar(usuario, user, pass);

            if (UserLogged != null)
            {
                Session["Auth"] = UserLogged.Nome;
                Response.Redirect("meuspet.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        public void Btn_Cadastrar(object sender, EventArgs e)
        {
            String user = nome.Text;
            String pass = senha.Text;
            var novousuario = new Usuario().CreateUser(user, pass);
            if (novousuario == null)
            {
                Response.Write("<script>alert('Ops, Algo esta errado por aqui...');</script>");
            }
        }

    }
}