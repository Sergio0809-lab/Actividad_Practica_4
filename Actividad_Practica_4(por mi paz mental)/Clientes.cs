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
    public partial class Clientes : Form
    {
        public Actividad_Practica_1Entities _context;
        public Clientes()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            _context = new Actividad_Practica_1Entities();

            var listaClientes = _context.Clientes.ToList();

            dataGridView1.DataSource = listaClientes;
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

            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("El telefono está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("El correo  está incorrecta o vacia.");
                return;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("La direccion está incorrecta o vacia.");
                return;
            }

            Cliente clien = new Cliente ()
            {

                ClienteID = Convert.ToInt32(textBox1.Text),
                NombreCompleto = textBox2.Text,
                CorreoElectronico = textBox3.Text,
                Telefono = maskedTextBox1.Text,
                Direccion = textBox4.Text,
            };

            _context.Clientes.Add(clien);

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

            int clienid = Convert.ToInt32(textBox11.Text);

            Cliente clien = _context.Clientes.FirstOrDefault(q => q.ClienteID.Equals(clienid));
            if (clien == null)
            {
                MessageBox.Show("Cliente no existe.");
                return;
            }

            _context.Clientes.Remove(clien);
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

            if (string.IsNullOrEmpty(maskedTextBox2.Text))
            {
                MessageBox.Show("El telefono está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("El correo  está incorrecta o vacia.");
                return;
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("La direccion está incorrecta o vacia.");
                return;
            }

            int clienid = Convert.ToInt32(textBox10.Text);

            Cliente clien = _context.Clientes.FirstOrDefault(q => q.ClienteID.Equals(clienid));
            if (clien == null)
            {
                MessageBox.Show("Cliente no existe.");
                return;
            }


            clien.ClienteID = Convert.ToInt32(textBox10.Text);
            clien.NombreCompleto = textBox9.Text;
            clien.CorreoElectronico = textBox8.Text;
            clien.Telefono = maskedTextBox2.Text;
            clien.Direccion = textBox5.Text;
          

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado el cliente en la base de datos.");
            }


        }
    }
}
