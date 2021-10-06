using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimuladoDAWPP
{
    public partial class CadastroNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarNoticias();
            }
        }

        public void CarregarNoticias()
        {
            NoticiaDAL nDAL = new NoticiaDAL();

            gvNoticias.DataSource = nDAL.SelecionarTodos();
            gvNoticias.DataBind();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Noticia objNoticia = new Noticia();
            objNoticia.DsTitulo = txbTitulo.Text;
            objNoticia.DtNoticia = Convert.ToDateTime(txbData.Text);
            objNoticia.DsNoticia = txbNoticia.Text;

            NoticiaDAL nDAL = new NoticiaDAL();
            nDAL.InserirNoticia(objNoticia);

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txbCodigo.Text = "";
            txbTitulo.Text = "";
            txbData.Text = "";
            txbNoticia.Text = "";

            CarregarNoticias();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            NoticiaDAL nDal = new NoticiaDAL();

            nDal.ExcluirNoticia(Convert.ToInt32(txbCodigo.Text));

            LimpaCampos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NoticiaDAL nDal = new NoticiaDAL();

            Noticia objNoticia = nDal.ObterNoticia(Convert.ToInt32(txbCodigo.Text));

            if (objNoticia != null)
            {
                // Preeche os campos da tela com os dados do objPessoa.
                txbTitulo.Text = objNoticia.DsTitulo;
                txbData.Text = Convert.ToString(objNoticia.DtNoticia);
                txbNoticia.Text = objNoticia.DsNoticia;
            }
            else
            {
                LimpaCampos();
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Noticia objNoticia = new Noticia();
            objNoticia.CdNoticia = Convert.ToInt32(txbCodigo.Text);
            objNoticia.DsTitulo = txbTitulo.Text;
            objNoticia.DtNoticia = Convert.ToDateTime(txbData.Text);
            objNoticia.DsNoticia = txbNoticia.Text;

            NoticiaDAL nDAL = new NoticiaDAL();

            nDAL.AtualizarNoticia(objNoticia);

            LimpaCampos();
        }
    }
}