using Actividad_Practica_4_por_mi_paz_mental_.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Actividad_Practica_4_por_mi_paz_mental_
{
    public partial class Proveedores : Form
    {
        public Actividad_Practica_1Entities _context;

        
        public Proveedores()
        {
            InitializeComponent();
        }
        
        private void btnCargar_Click(object sender, EventArgs e)
        {
            _context = new Actividad_Practica_1Entities();

            var listaProveedores= _context.Proveedores.ToList();

            dataGridView1.DataSource = listaProveedores;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("EL correo electronico está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("El telefono está incorrecto o vacio.");
                return;
            }

            Proveedore prover = new Proveedore()
            {

                ProveedorID = Convert.ToInt32(textBox1.Text),
                NombreProveedor = textBox2.Text,
                CorreoElectronico = textBox3.Text,
                Telefono = maskedTextBox1.Text,
            };

            _context.Proveedores.Add(prover);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha insertado el proveedor en la base de datos.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            int proid = Convert.ToInt32(textBox11.Text);

            Proveedore prover = _context.Proveedores.FirstOrDefault(q => q.ProveedorID.Equals(proid));
            if (prover == null)
            {
                MessageBox.Show("Proveedor no existe.");
                return;
            }

            _context.Proveedores.Remove(prover);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha eliminado el proveedor en la base de datos.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("EL correo electronico está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(maskedTextBox2.Text))
            {
                MessageBox.Show("El telefono está incorrecto o vacio.");
                return;
            }


            int proid = Convert.ToInt32(textBox10.Text);

            Proveedore prover = _context.Proveedores.FirstOrDefault(q => q.ProveedorID.Equals(proid));
            if (prover == null)
            {
                MessageBox.Show("Proveedor no existe.");
                return;
            }
            prover.NombreProveedor = textBox9.Text;
            prover.CorreoElectronico = textBox8.Text;
            prover.Telefono = maskedTextBox2.Text;

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado el proveedor en la base de datos.");
            }
        }
    }
}
