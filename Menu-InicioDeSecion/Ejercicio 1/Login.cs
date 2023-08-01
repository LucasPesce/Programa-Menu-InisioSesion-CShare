using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // INICIALIZAMOS LOS ELEMENTOS DEL FORMULARIO
        private void Login_Load(object sender, EventArgs e)             
        {
            textUsuario.Clear();            //Limpia la caja de texto del Usuario
            textContraseña.Clear();         //Limpia la caja de texto de la Contraseña

            comboModulo.Items.Clear();      //Limpia las opciones de Modulo
            comboModulo.Items.Add("ADM");   //Agrega opcion al modulo
            comboModulo.Items.Add("SIST");
            comboModulo.Items.Add("COM");
            comboModulo.Items.Add("VTA");

            textContraseña.Enabled = false; //Ihnabilita la caja de texto de contraseña
            comboModulo.Enabled = false;    //Ihnabilita los modulos
            btnAceptar.Enabled = false;     //Ihnabilita el boton de aceptar
        }

        //ACTIVACION PROGRESIVA DE LOS CAMPOS A LLENAR
        private void comboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboModulo.Text != null)           //Si la caja de texto de Usuario no esta vacia, se activara el campo contraseña
            {
                btnAceptar.Enabled = true;
            }
        }
        private void textContraseña_TextChanged(object sender, EventArgs e)
        {
            if (textContraseña.Text != null)           //Si la caja de texto de Contraseña no esta vacia, se activara el campo de los modulos
            {
                comboModulo.Enabled = true;
            }
        }
        private void textUsuario_TextChanged(object sender, EventArgs e)
        {
            if (textUsuario.Text != null)           //Si la caja de texto de Usuario no esta vacia, se activara el campo contraseña
            {
                textContraseña.Enabled = true;
            }

        }

        //BOTENES DEL FORMULARIO
        private void btnCancelar_Click(object sender, EventArgs e)  //BOTON CANCELAR
        {
            this.Close();
        }

        int intentos = 0;
        private void btnAceptar_Click(object sender, EventArgs e)  //BOTON ACEPTAR
        {
            if ((textUsuario.Text == "Adm" && textContraseña.Text == "adm123" &&                                 
                (comboModulo.Text == "ADM" || comboModulo.Text == "COM" || comboModulo.Text == "VTA")) ||

                (textUsuario.Text == "Jhon" && textContraseña.Text == "1234" && comboModulo.Text == "SIST") ||  

                (textUsuario.Text == "Ceci" && textContraseña.Text == "1234" && (comboModulo.Text == "ADM" || comboModulo.Text == "VTA")) ||

                (textUsuario.Text == "God" && textContraseña.Text == "god123" &&
                (comboModulo.Text == "ADM" || comboModulo.Text == "COM" || comboModulo.Text == "VTA" || comboModulo.Text == "SIST"))) 
            {
                this.Hide();                                // Ocultar Formulario
                Bienvenido bienvenido = new Bienvenido();   // Crear Formulario de bienvenida
                bienvenido.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Error en los datos ingresados");
                intentos++;
                if (intentos == 2)
                {
                    this.Close();
                }
            }
        }
    }
}
