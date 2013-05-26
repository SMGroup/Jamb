using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jamb
{
    public partial class FinishForm : Form
    {
        List<Player> playersFinish;
        GameForm gameForm;
        GameForm2 gameForm2;
        GameForm3 gameForm3;
        

        public FinishForm(List<Player> playersFinish, GameForm2 gameForm)
        {
            InitializeComponent();
            this.gameForm2 = gameForm;
            this.playersFinish = playersFinish;
            ListScore();
        }

        public FinishForm(List<Player> playersFinish, GameForm gameForm)
        {
            InitializeComponent();
            this.gameForm = gameForm;
            this.playersFinish = playersFinish;
            ListScore();
        }

        public FinishForm(List<Player> playersFinish, GameForm3 gameForm3)
        {
            InitializeComponent();
            this.gameForm3 = gameForm3;
            this.playersFinish = playersFinish;
            ListScore();
        }

        public void ListScore()
        {
            playersFinish.OrderBy(x => x.Score);

            lblPobednik.Text += " " + playersFinish[0].Name.ToString() + " со " + (playersFinish[0].Score).ToString() + " поени!";

            switch (playersFinish.Count())
            {
                case 1:
                    lblPrv.Text = "1. " + playersFinish[0].Name + " : " + (playersFinish[0].Score).ToString();
                    lblVtor.Text = "";
                    lblTret.Text = "";
                    lblCetvrt.Text = " ";
                    break;
                case 2:
                    lblPrv.Text = "1. " + playersFinish[0].Name + " : " + (playersFinish[0].Score).ToString();
                    lblVtor.Text = "2. " + playersFinish[1].Name + " : " + (playersFinish[1].Score).ToString();
                    lblTret.Text = "";
                    lblCetvrt.Text = " ";
                    break;
                case 3:
                    lblPrv.Text = "1. " + playersFinish[0].Name + " : " + (playersFinish[0].Score).ToString();
                    lblVtor.Text = "2. " + playersFinish[1].Name + " : " + (playersFinish[1].Score).ToString();
                    lblTret.Text = "3. " + playersFinish[2].Name + " : " + (playersFinish[2].Score).ToString();
                    lblCetvrt.Text = " ";
                    break;
                default:
                    lblPrv.Text = "1. " + playersFinish[0].Name + " : " + (playersFinish[0].Score).ToString();
                    lblVtor.Text = "2. " + playersFinish[1].Name + " : " + (playersFinish[1].Score).ToString();
                    lblTret.Text = "3. " + playersFinish[2].Name + " : " + (playersFinish[2].Score).ToString();
                    lblCetvrt.Text = "4. " + playersFinish[3].Name + " : " + (playersFinish[3].Score).ToString();
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
