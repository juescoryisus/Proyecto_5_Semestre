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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_5_Semestre
{
    

    public partial class CursoForm : Form
    {

        private string connectionString = "Server=DESKTOP-OG56094\\SQLEXPRESS;Database=Entidades; integrated security=true";
        public CursoForm()
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
            string nombreCurso = textBox1.Text;
            int aula = Convert.ToInt32(textBox2.Text);
            string maestro = textBox3.Text;
            int alumnos = Convert.ToInt32(textBox4.Text);
            int idAula = Convert.ToInt32(textBox5.Text);
            int idTaller = Convert.ToInt32(textBox6.Text);
            int idLaboratorio = Convert.ToInt32(textBox7.Text);
            bool status = true; // Valor por defecto

            // Consulta SQL para insertar los datos en la tabla Curso
            string query = "INSERT INTO Curso (nombreCurso, aula, maestro, alumnos, idAula, idTaller, idLaboratorio, status) " +
                           "VALUES (@nombreCurso, @aula, @maestro, @alumnos, @idAula, @idTaller, @idLaboratorio, @status)";

            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Crear el comando SQL con la consulta y la conexión
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Agregar parámetros para evitar inyecciones SQL
                    cmd.Parameters.AddWithValue("@nombreCurso", nombreCurso);
                    cmd.Parameters.AddWithValue("@aula", aula);
                    cmd.Parameters.AddWithValue("@maestro", maestro);
                    cmd.Parameters.AddWithValue("@alumnos", alumnos);
                    cmd.Parameters.AddWithValue("@idAula", idAula);
                    cmd.Parameters.AddWithValue("@idTaller", idTaller);
                    cmd.Parameters.AddWithValue("@idLaboratorio", idLaboratorio);
                    cmd.Parameters.AddWithValue("@status", status);

                    // Abrir la conexión a la base de datos
                    conn.Open();

                    // Ejecutar la consulta INSERT
                    cmd.ExecuteNonQuery();

                    // Confirmación de que se ha agregado el registro
                    MessageBox.Show("Datos agregados correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar datos: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string nombreCurso = row.Cells["nombreCurso"].Value.ToString();
                    int aula = Convert.ToInt32(row.Cells["aula"].Value);
                    string maestro = row.Cells["maestro"].Value.ToString();
                    int alumnos = Convert.ToInt32(row.Cells["alumnos"].Value);
                    int idAula = Convert.ToInt32(row.Cells["idAula"].Value);
                    int idTaller = Convert.ToInt32(row.Cells["idTaller"].Value);
                    int idLaboratorio = Convert.ToInt32(row.Cells["idLaboratorio"].Value);
                    bool status = Convert.ToBoolean(row.Cells["status"].Value);

                    string query = "INSERT INTO Curso (nombreCurso, aula, maestro, alumnos, idAula, idTaller, idLaboratorio, status) " +
                                   "VALUES (@nombreCurso, @aula, @maestro, @alumnos, @idAula, @idTaller, @idLaboratorio, @status)";

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@nombreCurso", nombreCurso);
                            cmd.Parameters.AddWithValue("@aula", aula);
                            cmd.Parameters.AddWithValue("@maestro", maestro);
                            cmd.Parameters.AddWithValue("@alumnos", alumnos);
                            cmd.Parameters.AddWithValue("@idAula", idAula);
                            cmd.Parameters.AddWithValue("@idTaller", idTaller);
                            cmd.Parameters.AddWithValue("@idLaboratorio", idLaboratorio);
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
            MessageBox.Show("Datos guardados correctamente.");
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
