using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class VistaAdminAlojamientos : Form
    {
        public VistaAdminAlojamientos()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VistaAdminReservas cambiarFormulario = new VistaAdminReservas();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VistaAdminUsuarios cambiarFormulario = new VistaAdminUsuarios();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login cambiarFormulario = new Login();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dataGridView1);
            fila.Cells[0].Value = textBox1.Text;
            fila.Cells[1].Value = textBox2.Text;
            fila.Cells[2].Value = textBox3.Text;
            fila.Cells[3].Value = textBox4.Text;
            fila.Cells[4].Value = textBox5.Text;
            fila.Cells[5].Value = textBox6.Text;
            fila.Cells[6].Value = textBox7.Text;
            fila.Cells[7].Value = textBox8.Text;
            fila.Cells[8].Value = textBox9.Text;
            fila.Cells[9].Value = textBox10.Text;
            fila.Cells[10].Value = textBox11.Text;

            dataGridView1.Rows.Add(fila);
            textBox1.Text = "código";
            textBox2.Text = "ciudad";
            textBox3.Text = "barrio";
            textBox4.Text = "estrellas";
            textBox5.Text = "can. pers.";
            textBox6.Text = "tv";
            textBox7.Text = "tipo";
            textBox8.Text = "precio persona";
            textBox9.Text = "precio día";
            textBox10.Text = "habitaciones";
            textBox11.Text = "baños";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch
            {
                MessageBox.Show("No se puede eliminar esta columna.");
            }
        }
    }
}
