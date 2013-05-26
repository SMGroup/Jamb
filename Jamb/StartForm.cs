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
    public partial class StartForm : Form
    {
        public List<String> name;
        public int GT = 0;
        public string Jacina = null;

        public StartForm()
        {
            InitializeComponent();
            cbBrP.Items.Add(2);
            
            cbJacina.Items.Add("Normal");
            cbJacina.Items.Add("Medium");
            cbJacina.Items.Add("Hard");

            cbBrP.SelectedIndex = 0;
            cbJacina.SelectedIndex = -1;
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            name = new List<String>();
            name.Clear();

            string errMsg = string.Empty;


            if (cbJacina.SelectedIndex == -1)
            {
                errMsg = "Одберете јачина !";
                errJacina.SetError(cbJacina, errMsg);
            }
            else
            {
                if (txtPlayer1.Text.Trim().Length <= 0)
                {
                    errMsg = "Внесете име за првиот играч.";
                    txtPlayer1.Select(0, txtPlayer1.Text.Length);
                    errPlayer1.SetError(txtPlayer1, errMsg);
                }
                else
                {
                    name.Insert(0, txtPlayer1.Text);
                    errPlayer1.Clear();

                    if (txtPlayer2.Text.Trim().Length <= 0)
                    {
                        errMsg = "Внесете име за вториот играч.";
                        txtPlayer2.Select(0, txtPlayer2.Text.Length);
                        errPlayer2.SetError(txtPlayer2, errMsg);
                        
                    }
                    else
                    {
                        errPlayer2.Clear();
                        name.Insert(1, txtPlayer2.Text);

                        switch (cbJacina.SelectedIndex)
                        {
                            case 0:
                                GameForm Fgame = new GameForm(Convert.ToInt32(cbBrP.SelectedItem), this);
                                GT = 52;
                                Fgame.Show();
                                break;
                            case 1:
                                GameForm2 Fgame2 = new GameForm2(Convert.ToInt32(cbBrP.SelectedItem), this);
                                GT = 78;
                                Fgame2.Show();
                                break;
                            case 2:
                                GameForm3 Fgame3 = new GameForm3(Convert.ToInt32(cbBrP.SelectedItem), this);
                                GT = 104;
                                Fgame3.Show();
                                break;
                        }
                        this.Hide();

                    }

                }
                errJacina.Clear();

            }
        }

        private void cbBrP_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbBrP.SelectedItem))
            {
                case 2:
                    txtPlayer1.Visible = true;
                    txtPlayer2.Visible = true;
                    lblPlayer1.Visible = true;
                    lblPlayer2.Visible = true;
                    break;
                default:
                    txtPlayer1.Visible = false;
                    txtPlayer2.Visible = false;                  
                    lblPlayer1.Visible = false;
                    lblPlayer2.Visible = false;                   
                    break;

            }
        }
    }
}
