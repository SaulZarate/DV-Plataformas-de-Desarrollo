using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class VistaCliente : Form
    {
        public VistaCliente()
        {
            InitializeComponent();
            button4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login cambiarFormulario = new Login();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            comboBox1.Hide();
            groupBox2.Hide();
            label2.Hide();
            textBox1.Hide();
            label3.Hide();
            textBox2.Hide();
            groupBox3.Hide();
            textBox3.Hide();
            groupBox4.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            button3.Hide();
            button4.Show();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            comboBox1.Show();
            groupBox2.Show();
            label2.Show();
            textBox1.Show();
            label3.Show();
            textBox2.Show();
            groupBox3.Show();
            textBox3.Show();
            groupBox4.Show();
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Show();
            button3.Show();
            button4.Hide();
        }
    }
}
