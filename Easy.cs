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
	public partial class Easy : Form
	{
		public Easy()
		{
			InitializeComponent();
			label4.Text = counter.ToString();
			timer3.Start();
			label10.Text = totalScore.ToString();
		}

		bool temp = true;
		int remainingItem = 4;
		int totalScore = 0;
		int counter = 5;
		int flag = 0;
		bool timert = true;
		PictureBox previous;

		private void Easy_Load(object sender, EventArgs e)
		{
			showInit();
			SetTagRandom();
		}
		void showInit()
		{
			SetTagRandom();
			
			counter = 5;
			timer3.Stop();
			//label4.Text = counter.ToString();
			

			foreach (Control pict in this.Controls)
			{
				if (pict is PictureBox)
				{
					switch (Convert.ToString(pict.Tag))
					{
						case "_2aa":
							(pict as PictureBox).Image = Properties.Resources._2aa;
							break;
						case "_2bb":
							(pict as PictureBox).Image = Properties.Resources._2bb;
							break;
						case "_3aa":
							(pict as PictureBox).Image = Properties.Resources._3aa;
							break;
						case "_3bb":
							(pict as PictureBox).Image = Properties.Resources._3bb;
							break;
						default:
							(pict as PictureBox).Image = Properties.Resources._0;
							break;
					}
				}

			}
			MessageBox.Show("You have 5 seconds to memorize\nClick OK Button When You are Ready", "Get Ready");
			timer3.Enabled = true;
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
		void showImage(PictureBox box)
		{
			switch (Convert.ToString(box.Tag))
			{
				case "_2aa":
					box.Image = Properties.Resources._2aa;
					break;
				case "_2bb":
					box.Image = Properties.Resources._2bb;
					break;
				case "_3aa":
					box.Image = Properties.Resources._3aa;
					break;
				case "_3bb":
					box.Image = Properties.Resources._3bb;
					break;
				default:
					box.Image = Properties.Resources._0;
					break;
			}
			// This function converts picureBox tag to image;
		}
		public void SetTagRandom()
		{
			Random r = new Random();

			string[] randomArr = new string[4] { "_2aa", "_2bb", "_3aa", "_3bb" };

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

				label10.Text = totalScore.ToString();

				if (remainingItem == 0)
				{
					timer3.Enabled = false;
					
					MessageBox.Show("Congratulations, You Won!, Your total score is: " + totalScore, "End of the game");
					
				}
				
			}
			else
			{
				Application.DoEvents();
				System.Threading.Thread.Sleep(500);
				previous.Image = Properties.Resources._0;
				current.Image = Properties.Resources._0;
				totalScore -= 3;
				label10.Text = totalScore.ToString();
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
			remainingItem = 4;
			counter = 20;
			totalScore = 0;

			//setTag0();
			label10.Text = totalScore.ToString();
			/*SetTagRandom();*/
			allvisibleTrue(); /*showInit();*/
			flag = 0; initPict0();
			timer3.Enabled = true;
			activeAll();
		}

		void tryagain()
		{
			remainingItem = 4;
			counter = 20;
			totalScore = 0;

			//setTag0();
			label10.Text = totalScore.ToString();
			/*SetTagRandom();*/
			allvisibleTrue();
			showInit();
			flag = 0; initPict0();
			timer3.Enabled = true;
			activeAll();
		}

		private void timer3_Tick(object sender, EventArgs e)
		{
			counter--;
			if (counter == 0 && timert && temp)
			{
				timer3.Stop();
				timert = false;
				counter = 20;
				timer3.Enabled = true;
				newgame();
				temp = false;
			}
			else if (counter == 0 && !timert)
			{
				timer3.Stop();
				MessageBox.Show("You've lost the game\n\n Try again!", "End of the Game");

			}
			label4.Text = counter.ToString();
		}


		private void pictureBox1_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}



		private void button1_Click(object sender, EventArgs e)
		{
			if (temp)
			{
				newgame();
				temp = false;
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}


		//private void InitializeComponent()
		//{
		//    this.SuspendLayout();
		//    // 
		//    // Easy
		//    // 
		//    this.ClientSize = new System.Drawing.Size(422, 261);
		//    this.Name = "Easy";
		//    this.ResumeLayout(false);

		//}

		private void Easy_Load_1(object sender, EventArgs e)
		{
			showInit();
			SetTagRandom();
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox8_Click(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox7_Click_1(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox8_Click_1(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox6_Click_1(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void pictureBox5_Click_1(object sender, EventArgs e)
		{
			//PictureBox current = (sender as PictureBox);
			//showImage((sender as PictureBox));
			//if (flag == 0)
			//{
			//	previous = current;
			//	flag = 1;
			//}
			//else if (previous != current)
			//{
			//	compare(previous, current);
			//	flag = 0;
			//}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		

		private void label4_Click_1(object sender, EventArgs e)
		{
		}

		private void pictureBox5_Click_2(object sender, EventArgs e)
		{
			Compare(sender);
		}

		private void Compare(object sender)
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

		private void pictureBox7_Click_2(object sender, EventArgs e)
		{
			Compare(sender);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			tryagain();
		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (temp)
			{
				newgame();
				temp = false;
			}
		}

		private void label10_Click(object sender, EventArgs e)
		{

		}
	}
}