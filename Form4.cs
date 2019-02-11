using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
			label6.Text = totalScore.ToString();
        }
		bool temp = true;
		bool timert = true;

		private int counter = 200; //might define inside the loop
		int flag = 0;
		int remainingItem = 36;
		int totalScore = 0;
		PictureBox previous;

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
						case "_1":
							(pict as PictureBox).Image = Properties.Resources._1;
							break;
						case "_2":
							(pict as PictureBox).Image = Properties.Resources._2;
							break;
						case "_3":
							(pict as PictureBox).Image = Properties.Resources._3;
							break;
						case "_4":
							(pict as PictureBox).Image = Properties.Resources._4;
							break;
						case "_5":
							(pict as PictureBox).Image = Properties.Resources._5;
							break;
						case "_6":
							(pict as PictureBox).Image = Properties.Resources._6;
							break;
						case "_7":
							(pict as PictureBox).Image = Properties.Resources._7;
							break;
						case "_8":
							(pict as PictureBox).Image = Properties.Resources._8;
							break;
						case "_9":
							(pict as PictureBox).Image = Properties.Resources._9;
							break;
						case "_10":
							(pict as PictureBox).Image = Properties.Resources._10;
							break;
						case "_11":
							(pict as PictureBox).Image = Properties.Resources._11;
							break;
						case "_12":
							(pict as PictureBox).Image = Properties.Resources._12;
							break;
						case "_13":
							(pict as PictureBox).Image = Properties.Resources._13;
							break;
						case "_14":
							(pict as PictureBox).Image = Properties.Resources._14;
							break;
						case "_15":
							(pict as PictureBox).Image = Properties.Resources._15;
							break;
						case "_16":
							(pict as PictureBox).Image = Properties.Resources._16;
							break;
						case "_17":
							(pict as PictureBox).Image = Properties.Resources._17;
							break;
						case "_18":
							(pict as PictureBox).Image = Properties.Resources._18;
							break;
						default:
							(pict as PictureBox).Image = Properties.Resources._0;
							break;
					}
				}
			}
			MessageBox.Show("You have 5 seconds to memorize\nClick OK Button When You are Ready", "Get Ready");
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
				case "_1":
					box.Image = Properties.Resources._1;
					break;
				case "_2":
					box.Image = Properties.Resources._2;
					break;
				case "_3":
					box.Image = Properties.Resources._3;
					break;
				case "_4":
					box.Image = Properties.Resources._4;
					break;
				case "_5":
					box.Image = Properties.Resources._5;
					break;
				case "_6":
					box.Image = Properties.Resources._6;
					break;
				case "_7":
					box.Image = Properties.Resources._7;
					break;
				case "_8":
					box.Image = Properties.Resources._8;
					break;
				case "_9":
					box.Image = Properties.Resources._9;
					break;
				case "_10":
					box.Image = Properties.Resources._10;
					break;
				case "_11":
					box.Image = Properties.Resources._11;
					break;
				case "_12":
					box.Image = Properties.Resources._12;
					break;
				case "_13":
					box.Image = Properties.Resources._13;
					break;
				case "_14":
					box.Image = Properties.Resources._14;
					break;
				case "_15":
					box.Image = Properties.Resources._15;
					break;
				case "_16":
					box.Image = Properties.Resources._16;
					break;
				case "_17":
					box.Image = Properties.Resources._17;
					break;
				case "_18":
					box.Image = Properties.Resources._18;
					break;
				default:
					box.Image = Properties.Resources._0;
					break;
			}
			// This function converts picureBox tag to image;
		}


		public void SetTagRandom()
		{

			string[] randomArr = new string[36] { "_1", "_2", "_3", "_4", "_5", "_6", "_7", "_8", "_9", "_10", "_11", "_12", "_13", "_14", "_15", "_16", "_17","_18", "_1", "_2", "_3", "_4", "_5", "_6", "_7", "_8", "_9", "_10", "_11", "_12", "_13", "_14", "_15", "_16", "_17", "_18" };

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
			if (previous.Tag.ToString() == current.Tag.ToString())
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
			remainingItem = 36;
			counter = 200;
			totalScore = 0;

			//setTag0();
			label6.Text = totalScore.ToString();
			/*SetTagRandom();*/
			allvisibleTrue(); /*showInit();*/
			flag = 0; initPict0();
			timer1.Enabled = true;
			activeAll();
		}
		void tryagain()
		{

			remainingItem = 36;
			counter = 200;
			totalScore = 0;

			//setTag0();
			label6.Text = totalScore.ToString();
			/*SetTagRandom();*/
			allvisibleTrue(); showInit();
			flag = 0; initPict0();
			timer1.Enabled = true;
			activeAll();


		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void ClickPict(object sender)
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

		private void pictureBox32_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox33_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox34_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox35_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox36_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox25_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox26_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox27_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox28_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox29_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox30_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox19_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox20_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox21_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox22_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox23_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox24_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox13_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox14_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox15_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox16_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox17_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox18_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox8_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox9_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox10_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox11_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox12_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void pictureBox31_Click(object sender, EventArgs e)
		{
			ClickPict(sender);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			counter--;
			if (counter == 0 && timert && temp)
			{
				timer1.Stop();
				timert = false;
				counter = 200;
				timer1.Enabled = true;
				newgame();
				temp = false;
			}
			else if (counter == 0 && !timert)
			{
				timer1.Stop();
				MessageBox.Show("You've lost the game\n\n Try again!", "End of the Game");

			}



			label1.Text = counter.ToString();
		}

		private void Form4_Load(object sender, EventArgs e)
		{
			showInit();
			SetTagRandom();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			tryagain();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (temp)
			{
				newgame();
				temp = false;
			}
		}
	}
}
