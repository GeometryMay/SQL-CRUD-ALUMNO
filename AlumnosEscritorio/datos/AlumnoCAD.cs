using AlumnosEscritorio.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosEscritorio.datos
{
    internal class AlumnoCAD
    {
        public static bool guardar(Alumno e)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "INSERT INTO tbalumnos(nombres, calificacion)VALUES('"+e.Nombres+"','"+e.Calificacion+"')";
                SqlCommand comando = new SqlCommand(sql,con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    return true;
                } else return false;

                con.desconectar();
                return true;
            }catch(Exception ex)

            {
                return false;
            }
        }

        public static bool actualizar(Alumno e)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "UPDATE  tbalumnos(nombres, calificacion)SET nombres ='"+e.Nombres+"',calificacion='"+e.Calificacion+"' where nombres='"+e.Nombres + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }


                
                return true;
            }
            catch (Exception ex)

            {
                return false;
            }
        }

        public static bool eliminar(string nombres)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "DELETE FROM  tbalumnos(nombres, calificacion)  where nombres='"+nombres + "'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }



                return true;
            }
            catch (Exception ex)

            {
                return false;
            }
        }
        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELECT * FROM tbalumnos;";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);

                con.desconectar();
                return dt;
            }
            catch (Exception ex)

            {
                return null;
            }
        }

        public static Alumno consultar(string nombre)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "SELECT * FROM tbalumnos WHERE nombre = '"+nombre+"';";
                SqlCommand comando = new SqlCommand(sql, con.conectar());
                SqlDataReader dr = comando.ExecuteReader();
                Alumno em = new Alumno();
                if (dr.Read())
                {
                    em.Nombres = dr["nombres"].ToString();
                    em.Calificacion = Convert.ToInt32(dr["calificacion"].ToString());
                    con.desconectar();
                    return em;
                }else
                {
                    con.desconectar();
                    return null;
                }


            }
            catch (Exception ex)

            {
                return null;
            }
        }

    }
}
