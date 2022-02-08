using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace P_042_diedasilva_BD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Permet de donner le nom du serveur sur lequel je veux me conecter
        string MyConnectionString = "Server=localhost;Database=mysql;Uid=root;Pwd=root;";
        
        MySqlConnection connexion;

        bool connecté = false;
        private void BtnConnexion_Click(object sender, EventArgs e)
        {
            //Nouvelle connection
            connexion = new MySqlConnection(MyConnectionString);

            try
            {
                //Si le bouton est sur "connexion"
                if(btnConnexion.Text == "Connexion")
                {
                    //Permet d'ouvrir ma base de données
                    connexion.Open();

                    //Message indiquant que la connexion est réussi
                    btnConnexion.BackColor = Color.Green;
                    btnConnexion.Text = "Connecter";
                    connecté = true;

                }
                else if(btnConnexion.Text == "Connecter")
                {
                    connexion.Close();
                    btnConnexion.Text = "Se déconnecter";
                    btnConnexion.BackColor = Color.Red;
                    connecté = false;
                }
            }
            catch
            {
                MessageBox.Show("Vous n'êtes pas connecter");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            
            if(txtBoxName.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom !!");
            }
            else
            {
                String query = "CREATE DATABASE " + txtBoxName.Text;

                MySqlCommand myCommand = new MySqlCommand(query, connexion);
                try
                {
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("La base de données à été créerm", "MyProgram");
                    txtBoxName.Text = "";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtBoxDelete.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom !!");
            }
            else
            {
                String query = "DROP DATABASE " + txtBoxDelete.Text;

                MySqlCommand myCommand = new MySqlCommand(query, connexion);
                try
                {
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("La base de données a été supprimer avec succès", "MyProgram");
                    txtBoxDelete.Text = "";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram");
                }
            }
        }
    }
}
