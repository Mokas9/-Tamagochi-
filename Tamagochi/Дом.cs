using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagochi
{
    public partial class Дом : Form
    {
        public Дом(Form1 form1, Egg egg)
        {
            InitializeComponent();
            this.form1 = form1;
            this.egg = egg;       
            pictureBox1.Image = new Bitmap(egg.Animal.Path_Egg);

        }

        Egg egg;
        Form1 form1;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (egg.Seconds < 0 && !egg.Apeared)
            {
                pictureBox1.Image = new Bitmap(egg.Animal.Path_Pet);
                egg.Apeared = !egg.Apeared;
                label19.Visible = false;
                MessageBox.Show("Вылупился!");
                ShowAllLabels();
            }
            else if (!egg.Apeared)
                --egg.Seconds;
            else
            {
                ShowPetStats();
                ShowButtons();
                HealthOut();
                timer2.Enabled = true;
                timer1.Enabled = false;
            }
        }
        public void ShowPetStats()
        {

            label1.Text = egg.Animal.Health.ToString();
            label5.Text = egg.Animal.Max_Health.ToString();
            label2.Text = egg.Animal.Tired.ToString();
            label6.Text = egg.Animal.Max_Tired.ToString();
            label3.Text = egg.Animal.Hunger.ToString();
            label7.Text = egg.Animal.Max_Hunger.ToString();
            label4.Text = egg.Animal.Piss.ToString();
            label8.Text = egg.Animal.Max_Piss.ToString();
            label18.Text = egg.Animal.Age.ToString();
        }

        public void ShowButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        public void ShowAllLabels()
        {
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label12.Visible = true;
            label11.Visible = true;
            label10.Visible = true;
            label9.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label18.Visible = true;
            button5.Visible = true;

        }

        private void убитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Животное умерло(((");
            form1.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            egg.Animal.Eat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            egg.Animal.Tualet();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            egg.Animal.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            egg.Animal.Sleep();
        }

        private void HealthOut()
        {
            egg.Animal.Ill();
            if(egg.Animal.Health == 0)
            {
                egg.Animal.Kill();
                egg.Animal.Hunger = 0;
                egg.Animal.Health = 0;
                egg.Animal.Piss = 0;
                egg.Animal.Tired = 0;
                timer2.Enabled = false;
                убитьToolStripMenuItem_Click(null, null);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ShowPetStats();
            HealthOut();

            if (egg.Animal.StatsSeconds < 0)
            {
                egg.Animal.ChangeStats();
                egg.Animal.UpDateTimer();
            }
            else
                --egg.Animal.StatsSeconds;


            if (egg.Animal.AgeSeconds < 0)
            {
                egg.Animal.Birthday();
                egg.Animal.UpDateTimer();
                MessageBox.Show("У вашего питомца День Рoждения!:D");
            }
            else
                --egg.Animal.AgeSeconds;
        }

        public void Messages()
        {
            if(egg.Animal.Health <= 20)
            {
                MessageBox.Show("Поиграйте с вашим питомцем, иначе он умрет :O");
            }

            if(egg.Animal.Hunger <= 20)
            {
                MessageBox.Show("Покормите вашего питомца, иначе он умрет :O");
            }

            if(egg.Animal.Piss >= egg.Animal.Max_Piss - 20)
            {
                MessageBox.Show("Уберите за вашим питомцем, иначе он умрет :O");
            }

            if(egg.Animal.Tired <= 20)
            {
                MessageBox.Show("Уложите вашего питомца спать, иначе он умрет :O");
            }
        }

         private void button5_Click(object sender, EventArgs e)
         {
             label20.Visible = !label20.Visible;
             label21.Visible = !label21.Visible;
             label22.Visible = !label22.Visible;
         }
    }
}
