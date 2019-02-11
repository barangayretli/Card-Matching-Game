using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Text = totalScore.ToString();
        }
        bool temp=true;
        bool timert = true;
        
        private int counter = 100; //might define inside the loop
        int flag = 0;
        int remainingItem = 16;
        int totalScore = 0;
        PictureBox previous;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            showInit();//
			SetTagRandom();
        }

        void showInit()
        {
            SetTagRandom();
            counter = 5;
            timer1.Stop();
            
            foreach (Control pict in this.Controls)
            {
                if (pict is PictureBox)
                {
                    switch (Convert.ToString((pict as PictureBox).Tag))
                    {
                        case "_1a":
                            (pict as PictureBox).Image = Properties.Resources._1a;
                            break;
                        case "_1b":
                            (pict as PictureBox).Image = Properties.Resources._1b;
                            break;
                        case "_2a":
                            (pict as PictureBox).Image = Properties.Resources._2a;
                            break;
                        case "_2b":
                            (pict as PictureBox).Image = Properties.Resources._2b;
                            break;
                        case "_3a":
                            (pict as PictureBox).Image = Properties.Resources._3a;
                            break;
                        case "_3b":
                            (pict as PictureBox).Image = Properties.Resources._3b;
                            break;
                        case "_4a":
                            (pict as PictureBox).Image = Properties.Resources._4a;
                            break;
                        case "_4b":
                            (pict as PictureBox).Image = Properties.Resources._4b;
                            break;
                        case "_5a":
                            (pict as PictureBox).Image = Properties.Resources._5a;
                            break;
                        case "_5b":
                            (pict as PictureBox).Image = Properties.Resources._5b;
                            break;
                        case "_6a":
                            (pict as PictureBox).Image = Properties.Resources._6a;
                            break;
                        case "_6b":
                            (pict as PictureBox).Image = Properties.Resources._6b;
                            break;
                        case "_7a":
                            (pict as PictureBox).Image = Properties.Resources._7a;
                            break;
                        case "_7b":
                            (pict as PictureBox).Image = Properties.Resources._7b;
                            break;
                        case "_8a":
                            (pict as PictureBox).Image = Properties.Resources._8a;
                            break;
                        case "_8b":
                            (pict as PictureBox).Image = Properties.Resources._8b;
                            break;
                        default:
                            (pict as PictureBox).Image = Properties.Resources._0;
                            break;
                    }
                }
            }
            MessageBox.Show("You have 5 seconds to memorize\nClick OK Button When You are Ready","Get Ready");
            timer1.Enabled = true;
        }

            void initPict0()
            {
                foreach (Control pict in this.Controls)
                {
                    if (pict is PictureBox)
                    {
                        (pict as PictureBox).Image = Properties.Resources._0;
                    }
                }
            }

            void setTag0()
            {
                foreach (Control pict in this.Controls)
                {
                    if (pict is PictureBox)
                    {
                        (pict as PictureBox).Tag = "_0";
                    }
                }
            }

            void showImage(PictureBox box)
            {
                switch (Convert.ToString(box.Tag))
                {
                    case "_1a":
                        box.Image = Properties.Resources._1a;
                        break;
                    case "_1b":
                        box.Image = Properties.Resources._1b;
                        break;
                    case "_2a":
                        box.Image = Properties.Resources._2a;
                        break;
                    case "_2b":
                        box.Image = Properties.Resources._2b;
                        break;
                    case "_3a":
                        box.Image = Properties.Resources._3a;
                        break;
                    case "_3b":
                        box.Image = Properties.Resources._3b;
                        break;
                    case "_4a":
                        box.Image = Properties.Resources._4a;
                        break;
                    case "_4b":
                        box.Image = Properties.Resources._4b;
                        break;
                    case "_5a":
                        box.Image = Properties.Resources._5a;
                        break;
                    case "_5b":
                        box.Image = Properties.Resources._5b;
                        break;
                    case "_6a":
                        box.Image = Properties.Resources._6a;
                        break;
                    case "_6b":
                        box.Image = Properties.Resources._6b;
                        break;
                    case "_7a":
                        box.Image = Properties.Resources._7a;
                        break;
                    case "_7b":
                        box.Image = Properties.Resources._7b;
                        break;
                    case "_8a":
                        box.Image = Properties.Resources._8a;
                        break;
                    case "_8b":
                        box.Image = Properties.Resources._8b;
                        break;
                    default:
                        box.Image = Properties.Resources._0;
                        break;
                }
                // This function converts picureBox tag to image;
            }


            public void SetTagRandom()
            {
                
                string[] randomArr = new string[16] { "_1a", "_1b", "_2a", "_2b", "_3a", "_3b", "_4a", "_4b", "_5a", "_5b", "_6a", "_6b", "_7a", "_7b", "_8a", "_8b" };

                Random rnd = new Random();
                randomArr = randomArr.OrderBy(x => rnd.Next()).ToArray();

                int index = 0;
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox)
                    {
                        (x as PictureBox).Tag = randomArr[index].ToString();
                        index++;
                    }
                }
            }

            void compare(PictureBox previous, PictureBox current)
            {
                if (previous.Tag.ToString().Substring(1, 1) == current.Tag.ToString().Substring(1, 1))
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                    previous.Visible = false;
                    current.Visible = false;
                    remainingItem -= 2;
                    totalScore += 5;
                    
                    this.label6.Text = totalScore.ToString();

                    if (remainingItem == 0)
                    {
                        timer1.Enabled = false;
                        //remainingItem.Text = "Congratulations.";
                        MessageBox.Show("Congratulations, You Won!, Your total score is: " + totalScore, "End of the game");
                        //Hint.Enabled = false;
                    }
                    //else remainingItem.Text = "Remaining Items: " + remainingItem;
                }
                else
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                    previous.Image = Properties.Resources._0;
                    current.Image = Properties.Resources._0;
                    totalScore -= 3;
                    this.label6.Text = totalScore.ToString();
                }
            }

            void allvisibleTrue()
            {
                foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Visible = true;
            }

            void activeAll()
            {
                foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Enabled = true;
            }

            void deActiveAll()
            {
                foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Enabled = false;
            }

            void newgame()
            {
                remainingItem = 16;
                counter = 100;
                totalScore = 0;
                
                //setTag0();
                label6.Text = totalScore.ToString();
                /*SetTagRandom();*/allvisibleTrue(); /*showInit();*/
                flag = 0;initPict0();
                timer1.Enabled = true;
                activeAll();
            }
            void tryagain()
            {
            
            remainingItem = 16;
            counter = 100;
            totalScore = 0;

            //setTag0();
            label6.Text = totalScore.ToString();
            /*SetTagRandom();*/
            allvisibleTrue(); showInit();
            flag = 0; initPict0();
            timer1.Enabled = true;
            activeAll();
        

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void progressBar_Click(object sender, EventArgs e)
            {
                


            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                counter--;
                if(counter==0 && timert && temp)
                {
                    timer1.Stop();
                    timert = false;
                    counter = 100;
                    timer1.Enabled = true;
                    newgame();
                    temp = false;
                }
                else if (counter == 0 && !timert )
                {
                    timer1.Stop();
                    MessageBox.Show("You've lost the game\n\n Try again!", "End of the Game");
                    
                }
            
                

                label1.Text = counter.ToString();
            }

            private void pictureBox18_Click(object sender, EventArgs e)
            {
                PictureBox current = (sender as PictureBox);
                showImage((sender as PictureBox));
                if (flag == 0)
                {
                    previous = current;
                    flag = 1;
                }
                else if (previous != current)
                {
                    compare(previous, current);
                    flag = 0;
                }
            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            public void label6_Click(object sender, EventArgs e)
            {
                label6.Text = totalScore.ToString();
            }

            public void label6_Click_1(object sender, EventArgs e)
            {
                label6.Text = totalScore.ToString();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            tryagain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(temp)
            {
                newgame();
                temp = false;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

