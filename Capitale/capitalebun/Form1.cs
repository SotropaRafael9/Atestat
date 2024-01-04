using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitalele_Europei
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void înregistrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Înregistrare_panel.Visible = !Înregistrare_panel.Visible;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string parola = textBox2.Text;
            int ok = 1;
            if (nume != "" && parola != "" && textBox3.Text != "")
            {
                for(int i = 0;i< conturiDataSet.Utilizator.Count;i ++)
                {
                    if (nume == conturiDataSet.Utilizator[i].Nume)
                        ok = 0;
                }
                if (ok == 1)
                {
                    if (parola == textBox3.Text)
                    {
                        utilizatorTableAdapter.InregistrareQuery(nume, parola, false);
                        utilizatorTableAdapter.Fill(conturiDataSet.Utilizator);
                        MessageBox.Show("Contul a fost creat cu succes");
                    }
                    else
                        MessageBox.Show("Parolele nu sunt identice");
                }
                else
                    MessageBox.Show("Exista deja un cont cu acest nume");

            }
            else
                MessageBox.Show("Nu ai introdus corect datele");
        }

        private void utilizatorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizatorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.conturiDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'conturiDataSet.Utilizator' table. You can move, or remove it, as needed.
            this.utilizatorTableAdapter.Fill(this.conturiDataSet.Utilizator);
            Conectare_panel.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nume = textBox4.Text;
            string parola = textBox5.Text;
            int k= -1;
            for(int i =0;i< conturiDataSet.Utilizator.Count;i++)
            {
                if(textBox4.Text == conturiDataSet.Utilizator[i].Nume)
                {
                    k = i;
                }
            }
            if(k == -1)
            {
                MessageBox.Show("Nu exista cont");
            }
            else
            {
                if(parola == conturiDataSet.Utilizator[k].Parola)
                {
                    MessageBox.Show("S-a conectat");
                    
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                   
                    
                
                }
                    
                else
                    MessageBox.Show("Parola gresita");
            }
                
        }

        private void Conectare_panel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void conectareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conectare_panel.Visible = !Conectare_panel.Visible;
        }
    }
}
