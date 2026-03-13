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
    public partial class Categorias : Form
    {
        public Actividad_Practica_1Entities _context;
        public Categorias()
        {
            InitializeComponent();
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
                MessageBox.Show("El  nombre está incorrecto o vacio.");
                return;
            }


            Categoria cate = new Categoria()
            {

                CategoriaId = Convert.ToInt32(textBox1.Text),
                NombreCategoria= textBox2.Text,
                
            };

            _context.Categorias.Add(cate);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha insertado la categoria en la base de datos.");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            _context = new Actividad_Practica_1Entities();

            var listaCategorias = _context.Categorias.ToList();

            dataGridView1.DataSource = listaCategorias;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            int cateId = Convert.ToInt32(textBox11.Text);

            Categoria cate = _context.Categorias.FirstOrDefault(q => q.CategoriaId.Equals(cateId));
            if (cate == null)
            {
                MessageBox.Show("Cliente no existe.");
                return;
            }

            _context.Categorias.Remove(cate);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha eliminado la categoria en la base de datos.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El  nombre está incorrecto o vacio.");
                return;
            }

            int cateId = Convert.ToInt32(textBox10.Text);

            Categoria cate = _context.Categorias.FirstOrDefault(q => q.CategoriaId.Equals(cateId));
            if (cate == null)
            {
                MessageBox.Show("La categoria no existe.");
                return;
            }

                cate.NombreCategoria = textBox9.Text;

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado la categoria en la base de datos.");
            }

        }
    }
}
