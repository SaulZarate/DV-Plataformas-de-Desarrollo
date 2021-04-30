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
            //Buscar
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

            button8.Show();
            groupBox5.Show();
            radioButton4.Show();
            radioButton5.Show();
            radioButton6.Show();
            groupBox6.Show();
            textBox4.Show();
            label4.Show();
            textBox5.Show();
            label5.Show();
            groupBox7.Show();
            textBox6.Show();
            listBox2.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Volver
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

            button8.Hide();
            groupBox5.Hide();
            radioButton4.Hide();
            radioButton5.Hide();
            radioButton6.Hide();
            groupBox6.Hide();
            textBox4.Hide();
            label4.Hide();
            textBox5.Hide();
            label5.Hide();
            groupBox7.Hide();
            textBox6.Hide();
            listBox2.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Buscar Reservaciones
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
            button5.Enabled = false;
            button6.Enabled = true;
            listBox1.Hide();
            button7.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Mis Reservaciones
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
            button4.Hide();
            button5.Enabled = true;
            button6.Enabled = false;
            listBox1.Show();
            button7.Show();
            button8.Hide();
            groupBox5.Hide();
            radioButton4.Hide();
            radioButton5.Hide();
            radioButton6.Hide();
            groupBox6.Hide();
            textBox4.Hide();
            label4.Hide();
            textBox5.Hide();
            label5.Hide();
            groupBox7.Hide();
            textBox6.Hide();
            listBox2.Hide();
        }
    }
}
