using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class NoticiaDAL
    {
        //Fazer o código para acessar o banco de dados
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDSimuladoDAAW;Integrated Security=True";

        public void InserirNoticia(Noticia objNoticia)
        {

            //Cria um objeto de conexão com o banco de dados
            SqlConnection conn = new SqlConnection(connectionString);

            //Abre a conexão criada
            conn.Open();

            //Criar o comando para execução
            string sql = "INSERT INTO Noticias VALUES (@dsTitulo, @dtNoticia, @dsNoticia)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //Definir os parâmetros
            cmd.Parameters.AddWithValue("@dsTitulo", objNoticia.DsTitulo);
            cmd.Parameters.AddWithValue("@dtNoticia", objNoticia.DtNoticia);
            cmd.Parameters.AddWithValue("@dsNoticia", objNoticia.DsNoticia);

            //Executar o comando
            cmd.ExecuteNonQuery();

            //Fechar a conexão
            conn.Close();
        }

        public List<Noticia> SelecionarTodos()
        {
            List<Noticia> listaNoticias = new List<Noticia>();

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Noticias";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Noticia objNoticia;
                while (dr.Read())
                {
                    objNoticia = new Noticia();
                    objNoticia.CdNoticia = Convert.ToInt32(dr["CdNoticia"]);
                    objNoticia.DsTitulo = dr["DsTitulo"].ToString();
                    objNoticia.DtNoticia = Convert.ToDateTime(dr["DtNoticia"]);
                    objNoticia.DsNoticia = dr["DsNoticia"].ToString();

                    listaNoticias.Add(objNoticia);
                }
            }

            conn.Close();

            return listaNoticias;
        }

        public void ExcluirNoticia(int codigoNoticia)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "DELETE FROM Noticias WHERE CdNoticia = @codigo";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigo", codigoNoticia);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Noticia ObterNoticia(int codigoNoticia)
        {
            Noticia objNoticia = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Noticias WHERE CdNoticia = @codigo";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigo", codigoNoticia);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true && dr.Read())
            {
                // Instancia um objPessoa.
                objNoticia = new Noticia();

                // Preenche os dados necessarios do objPessoa.
                objNoticia.CdNoticia = codigoNoticia;
                objNoticia.DsTitulo = dr["DsTitulo"].ToString();
                objNoticia.DtNoticia = Convert.ToDateTime(dr["DtNoticia"]);
                objNoticia.DsNoticia = dr["DsNoticia"].ToString();
            }

            conn.Close();

            return objNoticia;
        }

        public void AtualizarNoticia(Noticia objNoticia)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "UPDATE Noticias SET DsTitulo = @tituloNoticia, DtNoticia = @dataNoticia, DsNoticia = @descricaoNoticia WHERE CdNoticia = @codigoNoticia";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@tituloNoticia", objNoticia.DsTitulo);
            cmd.Parameters.AddWithValue("@dataNoticia", objNoticia.DtNoticia);
            cmd.Parameters.AddWithValue("@descricaoNoticia", objNoticia.DsNoticia);
            cmd.Parameters.AddWithValue("@codigoNoticia", objNoticia.CdNoticia);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
