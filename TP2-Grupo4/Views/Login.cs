using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP2_Grupo4
{
    public partial class Login : Form
    {
        private int intentos = 3;
        
        private ControlPanelClient ingresoCliente = new ControlPanelClient();
        private ControlPanelAdmin ingresoAdmin = new ControlPanelAdmin();

        private AgenciaManager agencia;

        public Login()
        {
            this.agencia = new AgenciaManager();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 40393222, "admin1234"
            string dni = textBox1.Text;
            string password = textBox2.Text;
            if(this.agencia.autenticarUsuario(int.Parse(dni), password))
            {
                MessageBox.Show("Logueado");
            }
            else
            {
                MessageBox.Show("No Logueado");
            }

            /*
            //validar si el usuario está correcto
            //si es válido y es cliente moverse a la VistaCliente
            string user = textBox1.Text;
            string password = textBox2.Text;
            string tempurl = "D:\\usuario\\xampp\\htdocs\\TP2-Grupo4\\usuarios\\" + user + ".txt"; ;
            if (File.Exists(tempurl))
            {
                contraseña = File.ReadAllText(tempurl);
                if (password.Equals(contraseña))
                {
                    ingresoAdmin.Show();
                    //ingresoCliente.Show();
                    this.Hide();
                    MessageBox.Show("Bienvenido usuario.");
                }
                else
                {
                    intentos--;
                    if (intentos == 0)
                    {
                        //acá hay que bloquear al usuario
                        MessageBox.Show("Usuario bloqueado, contacte con un administrador para desbloquear el usuario.");
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta, le quedan " + intentos + " intentos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("El usuario no está registrado, por favor vuelva a intentarlo.");
            }
            //newMDIChild2.Show();

            //si es válido y es admin moverse a la VistaAdmin
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string tempurl = "D:\\usuario\\xampp\\htdocs\\TP2-Grupo4\\usuarios\\" + user + ".txt";
            if (File.Exists(tempurl))
            {
                MessageBox.Show("Usuario ya registrado.");
            }
            else
            {
                File.WriteAllText(tempurl, password);
                MessageBox.Show("Se ha registrado exitosamente.");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.LightGray;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA";
                textBox2.ForeColor = Color.DimGray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControlPanelClient cambiarFormulario = new ControlPanelClient();
            cambiarFormulario.Show();
            this.Hide();
        }
    }
}
