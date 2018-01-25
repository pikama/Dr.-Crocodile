using System;
using System.Drawing;
using System.Windows.Forms;

namespace DRcrocodile
{
    public partial class MainForm : Form
    {

        TransparentControl[] teeth;
        string randomTeeth;
        string turn;


        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;           

            //init
            reset.Visible = false;
            pbCloseHead.Visible = false;

            teeth = new TransparentControl[10] { t0, t1, t2, t3, t4, t5, t6, t7, t8, t9 };
            
            foreach (TransparentControl t in teeth)
            {
                t.Click += ClickTeeth;                
            }

            

            turn = "p1"; // player 1 go first
            alert1.BackColor = Color.LimeGreen;
            alert2.BackColor = Color.Transparent;

            randomTeeth = "t" + (new Random()).Next(10);

        }

        
        void ClickTeeth(object sender, EventArgs e)
        {
            TransparentControl pb_click = sender as TransparentControl;
            pb_click.Visible = false;
            if (pb_click.Name == randomTeeth)
            {
                if (turn == "p1")
                {
                    lbP2.Text = (Int32.Parse(lbP2.Text) + 1).ToString();
                }
                else
                {
                    lbP1.Text = (Int32.Parse(lbP1.Text) + 1).ToString();
                }

                foreach (TransparentControl t in teeth)
                {
                    t.Visible = false;

                }
                pbCloseHead.Visible = true;
                pbOpenHead.Visible = false;
                reset.Visible = true;
            }
            else
            {
                changePlayer();
            }           
        }
        
        private void reset_Click(object sender, EventArgs e)
        {
            //reset all setting
            pbCloseHead.Visible = false;
            pbOpenHead.Visible = true;
            reset.Visible = false;
            foreach (TransparentControl t in teeth)
            {
                t.Visible = true;
            }
            randomTeeth = "t" + (new Random()).Next(10);
            changePlayer();
        }
        
        private void changePlayer()
        {
            turn = (turn == "p1") ? "p2" : "p1";
            alert1.BackColor = alert1.BackColor == Color.LimeGreen ? Color.Transparent : Color.LimeGreen;
            alert2.BackColor = alert2.BackColor == Color.LimeGreen ? Color.Transparent : Color.LimeGreen;
        }
        
    }
}
