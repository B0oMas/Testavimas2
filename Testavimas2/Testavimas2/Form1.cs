using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testavimas2
{
    public partial class Form1 : Form
    {
        private Game game;
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateState(string state)
        {
            button2.Text = game.GetTurn().ToString();
            if (state == "Continue")
            {
                return;
            }

            flowLayoutPanel1.Enabled = false;
            button2.Enabled = true;
            MessageBox.Show(state);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text == "X")
            {
                button2.Text = "O";
            }
            else
            {
                button2.Text = "X";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool xTurn = true;
                if (button2.Text == "O")
                {
                    xTurn = false;
                }

                game = new Game(textBox1.Text, UpdateState, textBox2.Text, xTurn);
                PrepareTheBoard();
                button2.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void PrepareTheBoard()
        {
            button2.Text = game.GetTurn().ToString();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            int dimension = Convert.ToInt32(textBox1.Text);
            int buttonSize = flowLayoutPanel1.Width / dimension - 15;
            int fontSize = (int)(buttonSize * 0.25);
            //Console.WriteLine(fontSize);
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Button button = new Button();
                    button.Tag = new Container(i, j);
                    button.Height = buttonSize;
                    button.Width = buttonSize;
                    button.Font = new Font(button.Font.FontFamily, fontSize);
                    button.MouseClick += Button_MouseClick;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            Container c = (Container)b.Tag;

            game.SetGridValue(c.X, c.Y);
            b.Text += game.GetGridValue(c.X, c.Y);
            b.Enabled = false;
        }
    }

    class Container
    {
        private int x;
        private int y;

        public Container(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
