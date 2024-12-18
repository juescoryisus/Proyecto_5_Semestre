using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_5_Semestre
{
    public partial class AlumnoForm : Form
    {

        private string connectionString = "Server=DESKTOP-OG56094\\SQLEXPRESS;Database=Entidades; integrated security=true";
        public AlumnoForm()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ", conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt; // Mostrar datos en el DataGridView
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error al cargar" + ex.Message);

                    }
                }
            }
        }


        private void bibliotecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMenu mainMenu = new mainMenu();
            mainMenu.ShowDialog();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string nombreTabla = comboBox1.SelectedItem.ToString();

                CargarDatosDeTabla(nombreTabla);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una tabla primero.");
            }
        }

        private void CargarDatosDeTabla(string nombreTabla)
        {
            string connectionString = "Server=DESKTOP-OG56094\\SQLEXPRESS; Database=Entidades; Integrated Security=True;";
            string query = $"SELECT * FROM  {nombreTabla}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Recoger datos de los TextBoxes
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            int clases = Convert.ToInt32(textBox4.Text);
            string correoElectronico = textBox5.Text;
            int idEvaluacionPorCurso = Convert.ToInt32(textBox6.Text);
            int idReporteDeProgreso = Convert.ToInt32(textBox7.Text);
            int idInstructores = Convert.ToInt32(textBox8.Text);
            bool status = true;  // Valor por defecto

            // Consulta SQL para insertar los datos en la tabla Alumno
            string query = "INSERT INTO Alumno (nombre, apellidoPaterno, apellidoMaterno, clases, correoElectronico, idEvaluacionPorCurso, idReporteDeProgreso, idInstructores, status) " +
                           "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @clases, @correoElectronico, @idEvaluacionPorCurso, @idReporteDeProgreso, @idInstructores, @status)";

            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Crear el comando SQL con la consulta y la conexión
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Agregar parámetros para evitar inyecciones SQL
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@clases", clases);
                    cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                    cmd.Parameters.AddWithValue("@idEvaluacionPorCurso", idEvaluacionPorCurso);
                    cmd.Parameters.AddWithValue("@idReporteDeProgreso", idReporteDeProgreso);
                    cmd.Parameters.AddWithValue("@idInstructores", idInstructores);
                    cmd.Parameters.AddWithValue("@status", status);

                    // Abrir la conexión a la base de datos
                    conn.Open();

                    // Ejecutar la consulta INSERT
                    cmd.ExecuteNonQuery();

                    // Confirmación de que se ha agregado el registro
                    MessageBox.Show("Alumno agregado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar alumno: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string nombre = row.Cells["nombre"].Value.ToString();
                    string apellidoPaterno = row.Cells["apellidoPaterno"].Value.ToString();
                    string apellidoMaterno = row.Cells["apellidoMaterno"].Value.ToString();
                    int clases = Convert.ToInt32(row.Cells["clases"].Value);
                    string correoElectronico = row.Cells["correoElectronico"].Value.ToString();
                    int idEvaluacionPorCurso = Convert.ToInt32(row.Cells["idEvaluacionPorCurso"].Value);
                    int idReporteDeProgreso = Convert.ToInt32(row.Cells["idReporteDeProgreso"].Value);
                    int idInstructores = Convert.ToInt32(row.Cells["idInstructores"].Value);
                    bool status = Convert.ToBoolean(row.Cells["status"].Value);

                    string query = "INSERT INTO Alumno (nombre, apellidoPaterno, apellidoMaterno, clases, correoElectronico, idEvaluacionPorCurso, idReporteDeProgreso, idInstructores, status) " +
                                   "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @clases, @correoElectronico, @idEvaluacionPorCurso, @idReporteDeProgreso, @idInstructores, @status)";

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                            cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                            cmd.Parameters.AddWithValue("@clases", clases);
                            cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                            cmd.Parameters.AddWithValue("@idEvaluacionPorCurso", idEvaluacionPorCurso);
                            cmd.Parameters.AddWithValue("@idReporteDeProgreso", idReporteDeProgreso);
                            cmd.Parameters.AddWithValue("@idInstructores", idInstructores);
                            cmd.Parameters.AddWithValue("@status", status);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar desde el DataGridView: {ex.Message}");
                    }
                }
            }
            MessageBox.Show("Alumnos guardados correctamente.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Limpiar TextBox y DataGridView

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            dataGridView1.DataSource = null;
        }

        private void btnDeleate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }
    }
}
