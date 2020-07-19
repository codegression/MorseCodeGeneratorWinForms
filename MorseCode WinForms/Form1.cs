using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseCode_WinForms
{
    public partial class Form1 : Form
    {
        MorseCode morsecode;
        public Form1()
        {
            InitializeComponent();

            morsecode = new MorseCode();
            morsecode.NewTimeSegment += Morsecode_NewTimeSegment;
        }

        private void Morsecode_NewTimeSegment(bool On, string dotdash)
        {
            if (!On)
            {
                Invoke(new Action(() =>
                {
                    this.BackColor = System.Drawing.SystemColors.Control;
                }));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    this.BackColor = Color.Yellow;
                }));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Play")
            {
                morsecode.WPM = trackBar1.Value;
                textBox1.Visible = false;
                trackBar1.Visible = false;
                label1.Visible = false;
                button1.Text = "Stop";
                int i = await morsecode.PlayAsync(textBox1.Text);

                this.BackColor = System.Drawing.SystemColors.Control;
                textBox1.Visible = true;
                trackBar1.Visible = true;
                label1.Visible = true;
                button1.Text = "Play";

            }
            else
            {           
                morsecode.Stop();
                this.BackColor = System.Drawing.SystemColors.Control;

                textBox1.Visible = true;
                trackBar1.Visible = true;
                label1.Visible = true;
                button1.Text = "Play";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                int duration = 20 * 60 / i;
                Sound.BeepSave(1100, duration, "Dot - " + duration.ToString() + ".wav");
                Sound.BeepSave(1100, duration * 3, "Dash - " + duration.ToString() + ".wav");
            }



        }
    }
}
