using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosEscritorio.datos
{
    internal class Conexion
    {
        SqlConnection con;
        public Conexion()
        {
            con = new SqlConnection("Server = DESKTOP-0B0JTU7\\SQLEXPRESS;Database = alumno_tb; integrated security = true"); 
        }

        public SqlConnection conectar()
        {
            try
            {
                con.Open();
                return con;

            }catch(Exception e)
            {
                return null;
            }

        }
        public bool desconectar()
        {
            try
            {
                con.Close();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
