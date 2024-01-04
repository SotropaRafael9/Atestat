using System;
using System.Windows.Forms;

namespace Capitalele_Europei
{
   
    public partial class Form2 : Form
    {
        Random intrebare = new Random();
        static int x;
        int test = 1;
        int RaspunsCorect;
        int nrintrebari = 0;
        int Corecte = 0;
        int Gresite = 0;
        int[] intrebari;
        int intrebaritotal = 10;
        private void Seteaza_Raspunsuri(int x)
        {
            richTextBox1.Text = conturiDataSet.Intrebari[x].Enunt.ToString();
            radioButton1.Text = conturiDataSet.Intrebari[x].Raspuns1;
            radioButton2.Text = conturiDataSet.Intrebari[x].Raspuns2;
            radioButton3.Text = conturiDataSet.Intrebari[x].Raspuns3;
            radioButton4.Text = conturiDataSet.Intrebari[x].Raspuns4;
            RaspunsCorect = Convert.ToInt32(conturiDataSet.Intrebari[x].RaspunsCorect.ToString());
        }
        public Form2()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start test!")
            {
                button1.Text = "Verifica";
                richTextBox1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                this.intrebariTableAdapter.Fill(this.conturiDataSet.Intrebari);
                intrebari = new int[intrebaritotal+1];
                for(int i=0;i< intrebaritotal; i++)
                    intrebari[i] = intrebare.Next(0, conturiDataSet.Intrebari.Count);
                nrintrebari = 0;
                Seteaza_Raspunsuri(nrintrebari);
            }
            else
            if (button1.Text == "Verifica")
            {
                
                if (radioButton1.Checked == true && RaspunsCorect == 1) Corecte++;
                else
                if (radioButton2.Checked == true && RaspunsCorect == 2) Corecte++;
                else
                 if (radioButton3.Checked == true && RaspunsCorect == 3) Corecte++;
                else
                 if (radioButton4.Checked == true && RaspunsCorect == 4) Corecte++;
                else
                    Gresite++;
                textBox1.Text = Corecte.ToString();
                textBox2.Text = Gresite.ToString();
                nrintrebari++;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                if ((test == 1 && nrintrebari >= intrebaritotal) ||(test == 0 && nrintrebari >= 20))
                {
                    button1.Visible = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                }
                Seteaza_Raspunsuri(nrintrebari);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esti sigur ca vrei sa inchizi aplicatia ?", "Inchidere", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'conturiDataSet.Utilizator' table. You can move, or remove it, as needed.
            this.utilizatorTableAdapter.Fill(this.conturiDataSet.Utilizator);
            // TODO: This line of code loads data into the 'conturiDataSet.Intrebari' table. You can move, or remove it, as needed.
            //this.intrebariTableAdapter.Fill(this.conturiDataSet.Intrebari);
            //x = intrebare.Next(0, conturiDataSet.Intrebari.Count - 1);
            //Creeaza_intrebari(x);
            //Seteaza_Raspunsuri(x);
            //Random r = new Random();
            //int nr = r.Next(1, 20);
            //int nr2 = r.Next(1, 20);
            //while (nr == nr2) nr2 = r.Next(1, 20);
            //int nr3 = r.Next(1, 20);
            //while (nr3 == nr || nr3 == nr2) nr3 = r.Next(1, 20);
            //int nr4 = r.Next(1, 20);
            //while (nr4 == nr || nr4 == nr2 || nr4 == nr3) nr4 = r.Next(1, 20);
            textBox1.Text = "0";
            textBox2.Text = "0";
        }
        private void intrebariBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.intrebariBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.conturiDataSet);

        }

        private void despreAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void testNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test = 0;
            button1.Text = "Verifica";
            button1.Visible = true;
            richTextBox1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            this.intrebariTableAdapter.Fill(this.conturiDataSet.Intrebari);
            intrebari = new int[intrebaritotal + 1];
            for (int i = 10; i <= intrebaritotal; i++)
                intrebari[i] = intrebare.Next(1, conturiDataSet.Intrebari.Count);
            nrintrebari = 10;
            Seteaza_Raspunsuri(nrintrebari);
        }
    }
}
