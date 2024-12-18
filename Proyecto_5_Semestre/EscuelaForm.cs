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
    public partial class EscuelaForm : Form
    {
        private string connectionString = "Server=DESKTOP-OG56094\\SQLEXPRESS;Database=Entidades; integrated security=true";

        public EscuelaForm()
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
            string guardias = textBox1.Text;
            string maestros = textBox2.Text;
            string directivos = textBox3.Text;
            string clases = textBox4.Text;
            int idDireccionGeneral = Convert.ToInt32(textBox5.Text);
            bool status = true;  // Valor por defecto

            // Consulta SQL para insertar los datos en la tabla Escuela
            string query = "INSERT INTO Escuela (Guardias, Maestros, Directivos, Clases, idDireccionGeneral, status) " +
                           "VALUES (@Guardias, @Maestros, @Directivos, @Clases, @idDireccionGeneral, @status)";

            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Crear el comando SQL con la consulta y la conexión
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Agregar parámetros para evitar inyecciones SQL
                    cmd.Parameters.AddWithValue("@Guardias", guardias);
                    cmd.Parameters.AddWithValue("@Maestros", maestros);
                    cmd.Parameters.AddWithValue("@Directivos", directivos);
                    cmd.Parameters.AddWithValue("@Clases", clases);
                    cmd.Parameters.AddWithValue("@idDireccionGeneral", idDireccionGeneral);
                    cmd.Parameters.AddWithValue("@status", status);

                    // Abrir la conexión a la base de datos
                    conn.Open();

                    // Ejecutar la consulta INSERT
                    cmd.ExecuteNonQuery();

                    // Confirmación de que se ha agregado el registro
                    MessageBox.Show("Escuela agregada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar escuela: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string guardias = row.Cells["Guardias"].Value.ToString();
                    string maestros = row.Cells["Maestros"].Value.ToString();
                    string directivos = row.Cells["Directivos"].Value.ToString();
                    string clases = row.Cells["Clases"].Value.ToString();
                    int idDireccionGeneral = Convert.ToInt32(row.Cells["idDireccionGeneral"].Value);
                    bool status = Convert.ToBoolean(row.Cells["status"].Value);

                    string query = "INSERT INTO Escuela (Guardias, Maestros, Directivos, Clases, idDireccionGeneral, status) " +
                                   "VALUES (@Guardias, @Maestros, @Directivos, @Clases, @idDireccionGeneral, @status)";

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@Guardias", guardias);
                            cmd.Parameters.AddWithValue("@Maestros", maestros);
                            cmd.Parameters.AddWithValue("@Directivos", directivos);
                            cmd.Parameters.AddWithValue("@Clases", clases);
                            cmd.Parameters.AddWithValue("@idDireccionGeneral", idDireccionGeneral);
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
            MessageBox.Show("Escuelas guardadas correctamente.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Limpiar TextBox y DataGridView

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

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