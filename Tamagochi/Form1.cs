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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pets = new List<Pet>();
            pets.Add(new Pet(50, 50, 50, 50, 50, 50, 0, 50, 0, 50, "Eggs\\1.png", "Pets\\1P.png"));
            pets.Add(new Pet(40, 40, 40, 40, 40, 40, 0, 40, 0, 40, "Eggs\\2.png", "Pets\\2P.png"));
            pets.Add(new Pet(60, 60, 60, 60, 60, 60, 0, 60, 0, 60, "Eggs\\3.png", "Pets\\3P.png"));
            pictureBox1.Image = new Bitmap(pets[0].Path_Egg);
        }

        int current = 0;
        List<Pet> pets;

        public void ChoicePet(int plus)
        {
            current += plus;

            if (current == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;

            if (current == pets.Count - 1)
                button3.Enabled = false;
            else
                button3.Enabled = true;

            pictureBox1.Image = new Bitmap(pets[current].Path_Egg);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Дом(this, new Egg(pets[current])).Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChoicePet(-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChoicePet(1);
        }
    }
}
