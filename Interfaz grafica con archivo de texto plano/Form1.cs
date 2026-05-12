using Interfaz_grafica_con_archivo_de_texto_plano.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_grafica_con_archivo_de_texto_plano
{
    /// <summary>
    /// 120526
    /// se creo una interfaz gráfica con un archivo de texto plano, donde se pueden agregar, modificar y eliminar registros de productos. Al salir de la aplicación, se guardan los datos en el archivo de texto plano. Al iniciar la aplicación, se cargan los datos desde el archivo de texto plano. Se utiliza un DataGridView para mostrar los datos y un BindingSource para enlazar los datos con el DataGridView.
    /// </summary>
    public partial class Form1 : Form
    {
        List<Constructor> lista = new List<Constructor>();
        string ruta = "productos.txt";

        public Form1()
        {
            InitializeComponent();
        }
        

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Constructor nuevoregistro = new Constructor(4, "Cereales", 30, 5);
            lista.Add(nuevoregistro);
            bs1.ResetBindings(false);
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgvdata.CurrentRow != null)
            {
                Constructor modificar = (Constructor)dgvdata.CurrentRow.DataBoundItem;

                modificar.Nombre = "Lácteos";
                modificar.Precio = 80;
                modificar.Cantidad = 7;

                bs1.ResetBindings(false);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            Constructor datoseliminar = (Constructor)dgvdata.CurrentRow.DataBoundItem;
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lista.Remove(datoseliminar);
                bs1.ResetBindings(false);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(ruta);

            foreach (Constructor item in lista)
            {
                sw.WriteLine(item.Id + "|" + item.Nombre + "|" + item.Precio + "|" + item.Cantidad);
            }

            sw.Close();

            MessageBox.Show("Datos guardados correctamente");

            Application.Exit();
        }
        private void cargararchivo()
        {
            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split('|');

                    lista.Add(new Constructor(int.Parse(datos[0]),datos[1],int.Parse(datos[2]),int.Parse(datos[3])));
                }
            }
            else
            {
                lista.Add(new Constructor(1, "Frutas", 50, 4));
                lista.Add(new Constructor(2, "Carne", 100, 3));
                lista.Add(new Constructor(3, "Verduras", 25, 6));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargararchivo();

            bs1.DataSource = lista;
            dgvdata.DataSource = bs1;

            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvdata.MultiSelect = false;
            dgvdata.ReadOnly = true;
        }
    }
}
