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
    public partial class Productos : Form
    {
        public Actividad_Practica_1Entities _context;
        private void cargarCmbCategorias()
        {
            _context = new Actividad_Practica_1Entities();

            var categorias = _context.Categorias.Select(c => new {
                ID = c.CategoriaId,
                Nombre = c.NombreCategoria
            }).ToList();

            comboBox1.DataSource = categorias;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID";

            comboBox2.DataSource = categorias;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "ID";


        }
        public Productos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            var listaProductos = _context.Productos
                  .Select(p => new {
                      ID = p.ProductosId,
                      Nombre = p.NombreProductos,
                      Descripciones = p.Descripcion,
                      Precios = p.Precio,
                      stock = p.Stock,
                      Categoria = p.Categoria.NombreCategoria
                  }).ToList();

            dataGridView1.DataSource = listaProductos;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("La descripción está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("El stock está incorrecta o vacia.");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                MessageBox.Show("La categoria está incorrecto o vacio.");
                return;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("El precio está incorrecta o vacia.");
                return;
            }

            Producto pro = new Producto()
            {
                ProductosId = Convert.ToInt32(textBox1.Text),
                NombreProductos = textBox2.Text,
                Descripcion = textBox5.Text,
                Stock = Convert.ToInt32(textBox3.Text),
                Categoriaid = Convert.ToInt32(comboBox1.SelectedValue),
                Precio = Convert.ToDecimal(textBox4.Text),
            };

            _context.Productos.Add(pro);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha insertado el producto en la base de datos.");
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            cargarCmbCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            int proid = Convert.ToInt32(textBox11.Text);

            Producto pro = _context.Productos.FirstOrDefault(q => q.ProductosId.Equals(proid));
            if (pro == null)
            {
                MessageBox.Show("Producto no existe.");
                return;
            }

            _context.Productos.Remove(pro);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha eliminado el producto en la base de datos.");
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

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("La descripción está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("El stock está incorrecta o vacia.");
                return;
            }
            if (string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()))
            {
                MessageBox.Show("La categoria está incorrecto o vacio.");
                return;
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("El precio está incorrecta o vacia.");
                return;
            }


            int productoID = Convert.ToInt32(textBox10.Text);

            Producto productos = _context.Productos.FirstOrDefault(q => q.ProductosId.Equals(productoID));
            if (productos == null)
            {
                MessageBox.Show("Producto no existe.");
                return;
            }

            productos.NombreProductos = textBox9.Text;
            productos.Descripcion = textBox6.Text;
            productos.Stock = Convert.ToInt32(textBox8.Text);
            productos.Categoriaid = Convert.ToInt32(comboBox2.SelectedValue);
            productos.Precio = Convert.ToDecimal(textBox7.Text);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado el producto en la base de datos.");
            }
        }
    }
}
