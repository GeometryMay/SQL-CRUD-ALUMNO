using AlumnosEscritorio.datos;
using AlumnosEscritorio.modelo;
using System.Data;

namespace AlumnosEscritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre valido");
            }else if (txtNombres.Text.Trim().Length < 5 )
            {
                MessageBox.Show("Ingrese un nombre largo mayor de 5 caracteres");
            }else
            {
                try
                {   
                    Alumno em = new Alumno();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Calificacion = Convert.ToInt32(txtCalificacion.Text.Trim());

                    if (AlumnoCAD.guardar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("¡Alumno guardado exitosamente!");

                    }else
                    {
                        MessageBox.Show("¡Este alumno ya existe!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
        private void llenarGrid()
        {
            DataTable datos = AlumnoCAD.listar();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a la base de datos");
            }else
            {
                dgLista.DataSource = datos.DefaultView;
            }
        }

        private void limpiarCampos()
        {
            txtNombres.Text = "";
            txtCalificacion.Text = ""; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        bool consultado = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre");
            }
            else 
            {
                Alumno em = AlumnoCAD.consultar(txtNombres.Text.Trim());
                if (em == null)
                {
                    MessageBox.Show("No se encontró el alumno "+txtNombres.Text);
                    limpiarCampos();
                    consultado = false;
                }else
                {
                    txtNombres.Text = em.Nombres;
                    txtCalificacion.Text = em.Calificacion.ToString();
                    consultado = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consultado==false)
            {
                MessageBox.Show("Debe consultar al alumno");
            }
            else if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre valido");
            }
            else if (txtNombres.Text.Trim().Length < 5)
            {
                MessageBox.Show("Ingrese un nombre largo mayor de 5 caracteres");
            }
            else
            {
                try
                {
                    Alumno em = new Alumno();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Calificacion = Convert.ToInt32(txtCalificacion.Text.Trim());

                    if (AlumnoCAD.actualizar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("¡Alumno actualizado exitosamente!");
                        consultado=false;
                    }
                    else
                    {
                        MessageBox.Show("¡Hubo un error, no se pudo actualizar!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (consultado==false)
            {
                MessageBox.Show("Debe consultar al alumno");
            }
            else if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre valido");
            }
            else if (DialogResult.Yes==MessageBox.Show(null,"¿Realmente desea eliminar el registro?","Confirmación",MessageBoxButtons.YesNo))
            {

                try
                {
                   

                    if (AlumnoCAD.eliminar(txtNombres.Text.Trim()))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("¡El alumno ha sido eliminado correctamente!");
                        consultado=false;
                    }
                    else
                    {
                        MessageBox.Show("¡No se pudo eliminar!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}