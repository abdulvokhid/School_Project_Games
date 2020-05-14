using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuffleGame
{
    public partial class Game : Form
    {
        int num;

        public Game()
        {
            InitializeComponent();
        }
        public void checkButton(Button bttn1, Button bttn2)
        {
            if (bttn2.Text == "")
            {
                bttn2.Text = bttn1.Text;
                bttn1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2,4
            checkButton(button1, button2);
            checkButton(button1, button4);
            checkSolve();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1,5,3
            checkButton(button2, button1);
            checkButton(button2, button5);
            checkButton(button2, button3);
            checkSolve();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //2,6
            checkButton(button3, button2);
            checkButton(button3, button6);
            checkSolve();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1,5,7
            checkButton(button4, button1);
            checkButton(button4, button5);
            checkButton(button4, button7);
            checkSolve();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //2,4,6,8
            checkButton(button5, button2);
            checkButton(button5, button4);
            checkButton(button5, button6);
            checkButton(button5, button8);
            checkSolve();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //3,5,9
            checkButton(button6, button3);
            checkButton(button6, button5);
            checkButton(button6, button9);
            checkSolve();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //4,8,
            checkButton(button7, button4);
            checkButton(button7, button8);
            checkSolve();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //7,5,9,
            checkButton(button8, button7);
            checkButton(button8, button5);
            checkButton(button8, button9);
            checkSolve();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //6,8,12
            checkButton(button9, button6);
            checkButton(button9, button8);
            checkSolve();
        }
        public void checkSolve()  //counts how many time i clicekd
        {
            num = num + 1;
            label1.Text = num + " clicks";
            if (button1.Text == "1" && button2.Text == "2" && button3.Text == "3" && button4.Text == "4" && button5.Text == "5" && button6.Text == "6" && button7.Text == "7" && button8.Text == "8" && button9.Text == "")
            {
                MessageBox.Show("You did it in " + num + "clicks","You win");
                Application.Exit();
            }
        }
        public void Shuffle()
        {
            int i, j, Rn;
            int[] a = new int[9];
            Boolean flag = false;
            i = 1;
            do
            {
                Random rnd = new Random();
                Rn = Convert.ToInt32((rnd.Next(0, 8)) + 1);
                for (j = 1; j <= i; j++)
                {
                    if (a[j] == Rn)
                    {
                        flag = true;
                        break;
                    }

                }
                if (flag == true)
                {
                    flag = false;
                }
                else
                {
                    a[i] = Rn;
                    i = i + 1;
                }
            }
            while (i <= 8);
            button1.Text = Convert.ToString(a[1]);
            button2.Text = Convert.ToString(a[2]);
            button3.Text = Convert.ToString(a[3]);
            button4.Text = Convert.ToString(a[4]);
            button5.Text = Convert.ToString(a[5]);
            button6.Text = Convert.ToString(a[6]);
            button7.Text = Convert.ToString(a[7]);
            button8.Text = Convert.ToString(a[8]);
            button9.Text = "";
            num = 0;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shuffle();
        }
    }
}
