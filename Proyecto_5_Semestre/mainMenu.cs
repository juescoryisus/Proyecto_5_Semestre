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
    public partial class mainMenu : Form
    {

       
        public mainMenu()
        {
            InitializeComponent();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }

        private void visitanteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VisitanteForm visitanteForm = new VisitanteForm();
            visitanteForm.Show();
        }

        private void escuelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EscuelaForm escuelaForm = new EscuelaForm();
            escuelaForm.Show();
        }

        private void direccionGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DireccionGeneralForm direccionGeneralForm = new DireccionGeneralForm();
            direccionGeneralForm.Show();
        }

        private void administracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministracionForm administracionForm = new AdministracionForm();
            administracionForm.Show();
        }

        private void bibliotecaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BibliotecaForm bibliotecaForm = new BibliotecaForm();
            bibliotecaForm.Show();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursoForm cursoForm = new CursoForm();
            cursoForm.Show();
        }

        private void aulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AulaForm aulaForm = new AulaForm();
            aulaForm.Show();
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoForm alumnoForm = new AlumnoForm();
            alumnoForm.Show();
        }

        private void horarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HorarioForm horarioForm = new HorarioForm();
            horarioForm.Show();
        }

        private void edificioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdificioForm edificioForm = new EdificioForm();
            edificioForm.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm();
            clienteForm.Show();
        }
    }
}
