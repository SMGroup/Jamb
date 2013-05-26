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
    public partial class GameForm : Form
    {
        Game game;
        StartForm startForm;
        FinishForm finishForm;
        Image imgBlank;
        Image img1;
        Image img2;
        Image img3;
        Image img4;
        Image img5;
        Image img6;
        Timer timer;

        bool started;
        public int here = 0;

        public GameForm(int pCount, StartForm form)
        {
            InitializeComponent();
            startForm = form;

            imgBlank = Properties.Resources.dice_blank;
            img1 = Properties.Resources.dice_1;
            img2 = Properties.Resources.dice_2;
            img3 = Properties.Resources.dice_3;
            img4 = Properties.Resources.dice_4;
            img5 = Properties.Resources.dice_5;
            img6 = Properties.Resources.dice_6;


            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            game = new Game(pCount);
            btnEndTurn.Enabled = false;

            for (int i = 0; i < game.Players.Count; i++)
                game.Players[i] = new Player(startForm.name[i], startForm.GT);

            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (here != 0 )
                btnEndTurn.Enabled = true;
            else
                btnEndTurn.Enabled = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Jamb - " + startForm.Jacina;

            lblPlayer1.Text = game.Players[0].Name;
            lblPlayer2.Text = game.Players[1].Name;


            for (int i = 0; i < game.Players.Count; i++)
                game.Players[i] = new Player(startForm.name[i], startForm.GT);

            lblIme.Text = "Се чека " + (game.Players[game.WhoTurn].Name);

            imgBlank = Properties.Resources.dice_blank;
            img1 = Properties.Resources.dice_1;
            img2 = Properties.Resources.dice_2;
            img3 = Properties.Resources.dice_3;
            img4 = Properties.Resources.dice_4;
            img5 = Properties.Resources.dice_5;
            img6 = Properties.Resources.dice_6;


            pic1.Image = ImageDice(0);
            pic2.Image = ImageDice(0);
            pic3.Image = ImageDice(0);
            pic4.Image = ImageDice(0);
            pic5.Image = ImageDice(0);
            pic6.Image = ImageDice(0);

            lblGameTurn.Text = "Преостанати вртења: " + game.Players[game.WhoTurn].GameTurns.ToString();
        }

        private Image ImageDice(int diceValue)
        {
            switch (diceValue)
            {
                case 0:
                    return imgBlank;
                case 1:
                    return img1;
                case 2:
                    return img2;
                case 3:
                    return img3;
                case 4:
                    return img4;
                case 5:
                    return img5;
                case 6:
                    return img6;
                default:
                    return imgBlank;
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
           
            lblTurns.Text = game.Players[game.WhoTurn].RollTurns.ToString();

            if (!started)
            {
                Check(true);
                started = true;

            }


            if (game.Players[game.WhoTurn].GameTurns > 3)
            {
                if (game.Players[game.WhoTurn].RollTurns > 2)
                {
                    lblTurns.Text = "Најмногу 3 пати ";
                    btnRoll.Enabled = false;
                    ResetButtonsHolds();
                }

            }
            else
            {
                if (game.Players[game.WhoTurn].RollTurns > 4)
                {
                    lblTurns.Text = "Најмногу 5 пати ";
                    btnRoll.Enabled = false;
                    ResetButtonsHolds();
                }
            }

            game.Players[game.WhoTurn].RollDice();

            pic1.Image = ImageDice(game.Players[game.WhoTurn].Dice[0].Value);
            pic2.Image = ImageDice(game.Players[game.WhoTurn].Dice[1].Value);
            pic3.Image = ImageDice(game.Players[game.WhoTurn].Dice[2].Value);
            pic4.Image = ImageDice(game.Players[game.WhoTurn].Dice[3].Value);
            pic5.Image = ImageDice(game.Players[game.WhoTurn].Dice[4].Value);
            pic6.Image = ImageDice(game.Players[game.WhoTurn].Dice[5].Value);

            btnHold1.Enabled = true;
            btnHold2.Enabled = true;
            btnHold3.Enabled = true;
            btnHold4.Enabled = true;
            btnHold5.Enabled = true;
            btnHold6.Enabled = true;

            lblIme.Text = game.Players[game.WhoTurn].Name;
            lblIgra.Text = game.Players[game.WhoTurn].ToString();

            lblGameTurn.Text = "Преостанати вртења: " + game.Players[game.WhoTurn].GameTurns.ToString();

            ResetButtonsHolds();

        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            lblTurns.Text = null;

            if (game.NextTurn())
            {
                btnRoll.Enabled = true;

                lblIme.Text = "Се чека " + (game.Players[game.WhoTurn].Name);
                lblIgra.Text = null;

                ResetButtonsHolds();
                SetButtonDesable(here);
                GetContent(here);

                btnEndTurn.Enabled = false;

                Check(true);

                switch (game.WhoTurn)
                {
                    case 0:
                        gbPlayer1.Enabled = true;
                        gbPlayer2.Enabled = false;
                        break;
                    case 1:
                        gbPlayer1.Enabled = false;
                        gbPlayer2.Enabled = true;
                        break;
                }

                here = 0;
                
                btnHold1.Enabled = false;
                btnHold2.Enabled = false;
                btnHold3.Enabled = false;
                btnHold4.Enabled = false;
                btnHold5.Enabled = false;
                btnHold6.Enabled = false;

                lblGameTurn.Text = "Преостанати вртења: " + game.Players[game.WhoTurn].GameTurns.ToString();

                pic1.Image = ImageDice(0);
                pic2.Image = ImageDice(0);
                pic3.Image = ImageDice(0);
                pic4.Image = ImageDice(0);
                pic5.Image = ImageDice(0);
                pic6.Image = ImageDice(0);
            }
            else
            {
                ResetButtonsHolds();
                SetButtonDesable(here);
                GetContent(here);
                game.Players[0].Score = NotStr(lblRezP1.Text);
                game.Players[1].Score = NotStr(lblRezP2.Text);
                btnEndTurn.Enabled = false;
                btnRoll.Enabled = false;
                finishForm = new FinishForm(game.PlayerFinished, this);
                finishForm.Show();
                this.Hide(); 
            }


            TotalCalculate();


        }

        private void Check(bool tr)
        {
            btnRoll.Enabled = tr;


            if (!started)
            {

                btnHold1.Enabled = tr;
                btnHold2.Enabled = tr;
                btnHold3.Enabled = tr;
                btnHold4.Enabled = tr;
                btnHold5.Enabled = tr;
                btnHold6.Enabled = tr;
            }
        }

        private void ResetButtonsHolds()
        {
            btnHold1.Text = "Hold";
            btnHold1.Font = new Font(btnHold1.Font, FontStyle.Regular);

            btnHold2.Text = "Hold";
            btnHold2.Font = new Font(btnHold2.Font, FontStyle.Regular);

            btnHold3.Text = "Hold";
            btnHold3.Font = new Font(btnHold3.Font, FontStyle.Regular);

            btnHold4.Text = "Hold";
            btnHold4.Font = new Font(btnHold4.Font, FontStyle.Regular);

            btnHold5.Text = "Hold";
            btnHold5.Font = new Font(btnHold5.Font, FontStyle.Regular);

            btnHold6.Text = "Hold";
            btnHold6.Font = new Font(btnHold6.Font, FontStyle.Regular);
        }

        public void SetPic(int n)
        {
            pic1.Image = ImageDice(game.Players[n].Dice[0].Value);
            pic2.Image = ImageDice(game.Players[n].Dice[1].Value);
            pic3.Image = ImageDice(game.Players[n].Dice[2].Value);
            pic4.Image = ImageDice(game.Players[n].Dice[3].Value);
            pic5.Image = ImageDice(game.Players[n].Dice[4].Value);
            pic6.Image = ImageDice(game.Players[n].Dice[5].Value);
        }

       

        private void btnHold1_Click(object sender, EventArgs e)
        {
            if (game.Players[game.WhoTurn].Dice[0].IsHeld == false)
            {
                game.Players[game.WhoTurn].Dice[0].IsHeld = true;
                btnHold1.Text = "Held";
                btnHold1.Font = new Font(btnHold1.Font, FontStyle.Bold);
            }
            else
            {
                game.Players[game.WhoTurn].Dice[0].IsHeld = false;
                btnHold1.Text = "Hold";
                btnHold1.Font = new Font(btnHold1.Font, FontStyle.Regular);
            }
        }

        private void btnHold2_Click(object sender, EventArgs e)
        {
            if (game.Players[game.WhoTurn].Dice[1].IsHeld == false)
            {
                game.Players[game.WhoTurn].Dice[1].IsHeld = true;
                btnHold2.Text = "Held";
                btnHold2.Font = new Font(btnHold2.Font, FontStyle.Bold);
            }
            else
            {
                game.Players[game.WhoTurn].Dice[1].IsHeld = false;
                btnHold2.Text = "Hold";
                btnHold2.Font = new Font(btnHold2.Font, FontStyle.Regular);
            }
        }

        private void btnHold3_Click(object sender, EventArgs e)
        {
            if (game.Players[game.WhoTurn].Dice[2].IsHeld == false)
            {
                game.Players[game.WhoTurn].Dice[2].IsHeld = true;
                btnHold3.Text = "Held";
                btnHold3.Font = new Font(btnHold3.Font, FontStyle.Bold);
            }
            else
            {
                game.Players[game.WhoTurn].Dice[2].IsHeld = false;
                btnHold3.Text = "Hold";
                btnHold3.Font = new Font(btnHold3.Font, FontStyle.Regular);
            }
        }

        private void btnHold4_Click(object sender, EventArgs e)
        {
            if (game.Players[game.WhoTurn].Dice[3].IsHeld == false)
            {
                game.Players[game.WhoTurn].Dice[3].IsHeld = true;
                btnHold4.Text = "Held";
                btnHold4.Font = new Font(btnHold4.Font, FontStyle.Bold);
            }
            else
            {
                game.Players[game.WhoTurn].Dice[3].IsHeld = false;
                btnHold4.Text = "Hold";
                btnHold4.Font = new Font(btnHold4.Font, FontStyle.Regular);
            }
        }

        private void btnHold5_Click(object sender, EventArgs e)
        {
            if (game.Players[game.WhoTurn].Dice[4].IsHeld == false)
            {
                game.Players[game.WhoTurn].Dice[4].IsHeld = true;
                btnHold5.Text = "Held";
                btnHold5.Font = new Font(btnHold5.Font, FontStyle.Bold);
            }
            else
            {
                game.Players[game.WhoTurn].Dice[4].IsHeld = false;
                btnHold5.Text = "Hold";
                btnHold5.Font = new Font(btnHold5.Font, FontStyle.Regular);
            }
        }

        private void btnHold6_Click(object sender, EventArgs e)
        {
            if (game.Players[game.WhoTurn].Dice[5].IsHeld == false)
            {
                game.Players[game.WhoTurn].Dice[5].IsHeld = true;
                btnHold6.Text = "Held";
                btnHold6.Font = new Font(btnHold6.Font, FontStyle.Bold);
            }
            else
            {
                game.Players[game.WhoTurn].Dice[5].IsHeld = false;
                btnHold6.Text = "Hold";
                btnHold6.Font = new Font(btnHold6.Font, FontStyle.Regular);
            }
        }


        public bool ButtonVisable(int m, int n)
        {
            if (m == n)
                return true;
            else
                return false;
        }

        public void GetContent(int m)
        {
            switch (m)
            {
                #region Kolona Nadole za Player 1
                case 1:
                    txtNadolu_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 2:
                    txtNadolu_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 3:
                    txtNadolu_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 4:
                    txtNadolu_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 5:
                    txtNadolu_05_P1.Text = (game.Players[0].DiceResult[4] * 5).ToString();
                    break;
                case 6:
                    txtNadolu_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 7:
                    txtMax_Nadolu_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 8:
                    txtMin_Nadolu_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 9:
                    txtTriling_Nadolu_P1.Text = game.Players[0].Znak[0].value.ToString();
                    break;
                case 10:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Nadolu_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Nadolu_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Nadolu_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 11:
                    txtFull_Nadolu_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 12:
                    txtPoker_Nadolu_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 13:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Nadolu_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Nadolu_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Nadolu_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Nadolu_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Slobodna za Player 1
                case 14:
                    txtSlobodna_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 15:
                    txtSlobodna_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 16:
                    txtSlobodna_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 17:
                    txtSlobodna_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 18:
                    txtSlobodna_05_P1.Text = (game.Players[0].DiceResult[4] * 5).ToString();
                    break;
                case 19:
                    txtSlobodna_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 20:
                    txtMax_Slobodna_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 21:
                    txtMin_Slobodna_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 22:
                    txtTriling_Slobodna_P1.Text = game.Players[0].Znak[0].value.ToString();
                    break;
                case 23:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Slobodna_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Slobodna_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Slobodna_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 24:
                    txtFull_Slobodna_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 25:
                    txtPoker_Slobodna_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 26:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Slobodna_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Slobodna_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Slobodna_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Slobodna_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Nagore za Player 1
                case 27:
                    txtNagore_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 28:
                    txtNagore_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 29:
                    txtNagore_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 30:
                    txtNagore_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 31:
                    txtNagore_05_P1.Text = (game.Players[0].DiceResult[4] * 5).ToString();
                    break;
                case 32:
                    txtNagore_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 33:
                    txtMax_Nagore_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 34:
                    txtMin_Nagore_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 35:
                    txtTriling_Nagore_P1.Text = (game.Players[0].Znak[0].value).ToString();
                    break;
                case 36:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Nagore_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Nagore_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Nagore_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 37:
                    txtFull_Nagore_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 38:
                    txtPoker_Nagore_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 39:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Nagore_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Nagore_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Nagore_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Nagore_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Start Min-Max za Player 1
                case 40:
                    txtStartMinMax_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 41:
                    txtStartMinMax_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 42:
                    txtStartMinMax_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 43:
                    txtStartMinMax_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 44:
                    txtStartMinMax_05_P1.Text = (game.Players[0].DiceResult[4] * 5).ToString();
                    break;
                case 45:
                    txtStartMinMax_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 46:
                    txtMax_StartMinMax_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 47:
                    txtMin_StartMinMax_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 48:
                    txtTriling_StartMinMax_P1.Text = (game.Players[0].Znak[0].value).ToString();
                    break;
                case 49:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_StartMinMax_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_StartMinMax_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_StartMinMax_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 50:
                    txtFull_StartMinMax_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 51:
                    txtPoker_StartMinMax_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 52:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_StartMinMax_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_StartMinMax_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_StartMinMax_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_StartMinMax_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Nadole za Player 2
                case 121:
                    txtNadolu_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 122:
                    txtNadolu_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 123:
                    txtNadolu_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 124:
                    txtNadolu_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 125:
                    txtNadolu_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 126:
                    txtNadolu_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 127:
                    txtMax_Nadolu_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 128:
                    txtMin_Nadolu_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 129:
                    txtTriling_Nadolu_P2.Text = game.Players[1].Znak[0].value.ToString();
                    break;
                case 130:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Nadolu_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[2].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Nadolu_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Nadolu_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 131:
                    txtFull_Nadolu_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 132:
                    txtPoker_Nadolu_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 133:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Nadolu_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Nadolu_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Nadolu_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Nadolu_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Slobodna za Player 2
                case 134:
                    txtSlobodna_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 135:
                    txtSlobodna_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 136:
                    txtSlobodna_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 137:
                    txtSlobodna_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 138:
                    txtSlobodna_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 139:
                    txtSlobodna_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 140:
                    txtMax_Slobodna_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 141:
                    txtMin_Slobodna_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 142:
                    txtTriling_Slobodna_P2.Text = game.Players[1].Znak[0].value.ToString();
                    break;
                case 143:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Slobodna_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Slobodna_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Slobodna_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 144:
                    txtFull_Slobodna_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 145:
                    txtPoker_Slobodna_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 146:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Slobodna_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Slobodna_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Slobodna_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Slobodna_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Nagore za Player 2
                case 147:
                    txtNagore_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 148:
                    txtNagore_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 149:
                    txtNagore_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 150:
                    txtNagore_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 151:
                    txtNagore_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 152:
                    txtNagore_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 153:
                    txtMax_Nagore_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 154:
                    txtMin_Nagore_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 155:
                    txtTriling_Nagore_P2.Text = (game.Players[1].Znak[0].value).ToString();
                    break;
                case 156:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Nagore_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Nagore_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Nagore_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 157:
                    txtFull_Nagore_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 158:
                    txtPoker_Nagore_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 159:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Nagore_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Nagore_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Nagore_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Nagore_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Start Min-Max za Player 2
                case 160:
                    txtStartMinMax_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 161:
                    txtStartMinMax_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 162:
                    txtStartMinMax_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 163:
                    txtStartMinMax_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 164:
                    txtStartMinMax_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 165:
                    txtStartMinMax_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 166:
                    txtMax_StartMinMax_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 167:
                    txtMin_StartMinMax_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 168:
                    txtTriling_StartMinMax_P2.Text = (game.Players[1].Znak[0].value).ToString();
                    break;
                case 169:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_StartMinMax_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_StartMinMax_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_StartMinMax_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 170:
                    txtFull_StartMinMax_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 171:
                    txtPoker_StartMinMax_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 172:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_StartMinMax_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_StartMinMax_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_StartMinMax_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_StartMinMax_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion
            }
        }


        public void SetButtonDesable(int m)
        {
            switch (m)
            {
                #region Kolona Nadole za Player 1
                case 1:
                    txtNadolu_01_P1.Enabled = false;
                    txtNadolu_02_P1.Visible = true;
                    break;
                case 2:
                    txtNadolu_02_P1.Enabled = false;
                    txtNadolu_03_P1.Visible = true;
                    break;
                case 3:
                    txtNadolu_03_P1.Enabled = false;
                    txtNadolu_04_P1.Visible = true;
                    break;
                case 4:
                    txtNadolu_04_P1.Enabled = false;
                    txtNadolu_05_P1.Visible = true;
                    break;
                case 5:
                    txtNadolu_05_P1.Enabled = false;
                    txtNadolu_06_P1.Visible = true;
                    break;
                case 6:
                    txtNadolu_06_P1.Enabled = false;
                    txtMax_Nadolu_P1.Visible = true;
                    break;
                case 7:
                    txtMax_Nadolu_P1.Enabled = false;
                    txtMin_Nadolu_P1.Visible = true;
                    break;
                case 8:
                    txtMin_Nadolu_P1.Enabled = false;
                    txtTriling_Nadolu_P1.Visible = true;
                    break;
                case 9:
                    txtTriling_Nadolu_P1.Enabled = false;
                    txtSkala_Nadolu_P1.Visible = true;
                    break;
                case 10:
                    txtSkala_Nadolu_P1.Enabled = false;
                    txtFull_Nadolu_P1.Visible = true;
                    break;
                case 11:
                    txtFull_Nadolu_P1.Enabled = false;
                    txtPoker_Nadolu_P1.Visible = true;
                    break;
                case 12:
                    txtPoker_Nadolu_P1.Enabled = false;
                    txtJamb_Nadolu_P1.Visible = true;
                    break;
                case 13:
                    txtJamb_Nadolu_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Slobodna za Player 1
                case 14:
                    txtSlobodna_01_P1.Enabled = false;
                    break;
                case 15:
                    txtSlobodna_02_P1.Enabled = false;
                    break;
                case 16:
                    txtSlobodna_03_P1.Enabled = false;
                    break;
                case 17:
                    txtSlobodna_04_P1.Enabled = false;
                    break;
                case 18:
                    txtSlobodna_05_P1.Enabled = false;
                    break;
                case 19:
                    txtSlobodna_06_P1.Enabled = false;
                    break;
                case 20:
                    txtMax_Slobodna_P1.Enabled = false;
                    break;
                case 21:
                    txtMin_Slobodna_P1.Enabled = false;
                    break;
                case 22:
                    txtTriling_Slobodna_P1.Enabled = false;
                    break;
                case 23:
                    txtSkala_Slobodna_P1.Enabled = false;
                    break;
                case 24:
                    txtFull_Slobodna_P1.Enabled = false;
                    break;
                case 25:
                    txtPoker_Slobodna_P1.Enabled = false;
                    break;
                case 26:
                    txtJamb_Slobodna_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Nagore za Player 1
                case 27:
                    txtNagore_01_P1.Enabled = false;
                    break;
                case 28:
                    txtNagore_01_P1.Visible = true;
                    txtNagore_02_P1.Enabled = false;
                    break;
                case 29:
                    txtNagore_02_P1.Visible = true;
                    txtNagore_03_P1.Enabled = false;
                    break;
                case 30:
                    txtNagore_03_P1.Visible = true;
                    txtNagore_04_P1.Enabled = false;
                    break;
                case 31:
                    txtNagore_04_P1.Visible = true;
                    txtNagore_05_P1.Enabled = false;
                    break;
                case 32:
                    txtNagore_05_P1.Visible = true;
                    txtNagore_06_P1.Enabled = false;
                    break;
                case 33:
                    txtNagore_06_P1.Visible = true;
                    txtMax_Nagore_P1.Enabled = false;
                    break;
                case 34:
                    txtMax_Nagore_P1.Visible = true;
                    txtMin_Nagore_P1.Enabled = false;
                    break;
                case 35:
                    txtMin_Nagore_P1.Visible = true;
                    txtTriling_Nagore_P1.Enabled = false;
                    break;
                case 36:
                    txtTriling_Nagore_P1.Visible = true;
                    txtSkala_Nagore_P1.Enabled = false;
                    break;
                case 37:
                    txtSkala_Nagore_P1.Visible = true;
                    txtFull_Nagore_P1.Enabled = false;
                    break;
                case 38:
                    txtFull_Nagore_P1.Visible = true;
                    txtPoker_Nagore_P1.Enabled = false;
                    break;
                case 39:
                    txtPoker_Nagore_P1.Visible = true;
                    txtJamb_Nagore_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Start Min-Max za Player 1
                case 40:
                    txtStartMinMax_01_P1.Enabled = false;
                    break;
                case 41:
                    txtStartMinMax_01_P1.Visible = true;
                    txtStartMinMax_02_P1.Enabled = false;
                    break;
                case 42:
                    txtStartMinMax_02_P1.Visible = true;
                    txtStartMinMax_03_P1.Enabled = false;
                    break;
                case 43:
                    txtStartMinMax_03_P1.Visible = true;
                    txtStartMinMax_04_P1.Enabled = false;
                    break;
                case 44:
                    txtStartMinMax_04_P1.Visible = true;
                    txtStartMinMax_05_P1.Enabled = false;
                    break;
                case 45:
                    txtStartMinMax_05_P1.Visible = true;
                    txtStartMinMax_06_P1.Enabled = false;
                    break;
                case 46:
                    txtStartMinMax_06_P1.Visible = true;
                    txtMax_StartMinMax_P1.Enabled = false;
                    break;
                case 47:
                    txtMin_StartMinMax_P1.Enabled = false;
                    txtTriling_StartMinMax_P1.Visible = true;
                    break;
                case 48:
                    txtTriling_StartMinMax_P1.Enabled = false;
                    txtSkala_StartMinMax_P1.Visible = true;
                    break;
                case 49:
                    txtSkala_StartMinMax_P1.Enabled = false;
                    txtFull_StartMinMax_P1.Visible = true;
                    break;
                case 50:
                    txtFull_StartMinMax_P1.Enabled = false;
                    txtPoker_StartMinMax_P1.Visible = true;
                    break;
                case 51:
                    txtPoker_StartMinMax_P1.Enabled = false;
                    txtJamb_StartMinMax_P1.Visible = true;
                    break;
                case 52:
                    txtJamb_StartMinMax_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Nadole za Player 2
                case 121:
                    txtNadolu_01_P2.Enabled = false;
                    txtNadolu_02_P2.Visible = true;
                    break;
                case 122:
                    txtNadolu_02_P2.Enabled = false;
                    txtNadolu_03_P2.Visible = true;
                    break;
                case 123:
                    txtNadolu_03_P2.Enabled = false;
                    txtNadolu_04_P2.Visible = true;
                    break;
                case 124:
                    txtNadolu_04_P2.Enabled = false;
                    txtNadolu_05_P2.Visible = true;
                    break;
                case 125:
                    txtNadolu_05_P2.Enabled = false;
                    txtNadolu_06_P2.Visible = true;
                    break;
                case 126:
                    txtNadolu_06_P2.Enabled = false;
                    txtMax_Nadolu_P2.Visible = true;
                    break;
                case 127:
                    txtMax_Nadolu_P2.Enabled = false;
                    txtMin_Nadolu_P2.Visible = true;
                    break;
                case 128:
                    txtMin_Nadolu_P2.Enabled = false;
                    txtTriling_Nadolu_P2.Visible = true;
                    break;
                case 129:
                    txtTriling_Nadolu_P2.Enabled = false;
                    txtSkala_Nadolu_P2.Visible = true;
                    break;
                case 130:
                    txtSkala_Nadolu_P2.Enabled = false;
                    txtFull_Nadolu_P2.Visible = true;
                    break;
                case 131:
                    txtFull_Nadolu_P2.Enabled = false;
                    txtPoker_Nadolu_P2.Visible = true;
                    break;
                case 132:
                    txtPoker_Nadolu_P2.Enabled = false;
                    txtJamb_Nadolu_P2.Visible = true;
                    break;
                case 133:
                    txtJamb_Nadolu_P2.Enabled = false;
                    break;
                #endregion

                #region Kolona Slobodna za Player 2
                case 134:
                    txtSlobodna_01_P2.Enabled = false;
                    break;
                case 135:
                    txtSlobodna_02_P2.Enabled = false;
                    break;
                case 136:
                    txtSlobodna_03_P2.Enabled = false;
                    break;
                case 137:
                    txtSlobodna_04_P2.Enabled = false;
                    break;
                case 138:
                    txtSlobodna_05_P2.Enabled = false;
                    break;
                case 139:
                    txtSlobodna_06_P2.Enabled = false;
                    break;
                case 140:
                    txtMax_Slobodna_P2.Enabled = false;
                    break;
                case 141:
                    txtMin_Slobodna_P2.Enabled = false;
                    break;
                case 142:
                    txtTriling_Slobodna_P2.Enabled = false;
                    break;
                case 143:
                    txtSkala_Slobodna_P2.Enabled = false;
                    break;
                case 144:
                    txtFull_Slobodna_P2.Enabled = false;
                    break;
                case 145:
                    txtPoker_Slobodna_P2.Enabled = false;
                    break;
                case 146:
                    txtJamb_Slobodna_P2.Enabled = false;
                    break;
                #endregion

                #region Kolona Nagore za Player 2
                case 147:
                    txtNagore_01_P2.Enabled = false;
                    break;
                case 148:
                    txtNagore_01_P2.Visible = true;
                    txtNagore_02_P2.Enabled = false;
                    break;
                case 149:
                    txtNagore_02_P2.Visible = true;
                    txtNagore_03_P2.Enabled = false;
                    break;
                case 150:
                    txtNagore_03_P2.Visible = true;
                    txtNagore_04_P2.Enabled = false;
                    break;
                case 151:
                    txtNagore_04_P2.Visible = true;
                    txtNagore_05_P2.Enabled = false;
                    break;
                case 152:
                    txtNagore_05_P2.Visible = true;
                    txtNagore_06_P2.Enabled = false;
                    break;
                case 153:
                    txtNagore_06_P2.Visible = true;
                    txtMax_Nagore_P2.Enabled = false;
                    break;
                case 154:
                    txtMax_Nagore_P2.Visible = true;
                    txtMin_Nagore_P2.Enabled = false;
                    break;
                case 155:
                    txtMin_Nagore_P2.Visible = true;
                    txtTriling_Nagore_P2.Enabled = false;
                    break;
                case 156:
                    txtTriling_Nagore_P2.Visible = true;
                    txtSkala_Nagore_P2.Enabled = false;
                    break;
                case 157:
                    txtSkala_Nagore_P2.Visible = true;
                    txtFull_Nagore_P2.Enabled = false;
                    break;
                case 158:
                    txtFull_Nagore_P2.Visible = true;
                    txtPoker_Nagore_P2.Enabled = false;
                    break;
                case 159:
                    txtPoker_Nagore_P2.Visible = true;
                    txtJamb_Nagore_P2.Enabled = false;
                    break;
                #endregion

                #region Kolona Start Min-Max za Player 2
                case 160:
                    txtStartMinMax_01_P2.Enabled = false;
                    break;
                case 161:
                    txtStartMinMax_01_P2.Visible = true;
                    txtStartMinMax_02_P2.Enabled = false;
                    break;
                case 162:
                    txtStartMinMax_02_P2.Visible = true;
                    txtStartMinMax_03_P2.Enabled = false;
                    break;
                case 163:
                    txtStartMinMax_03_P2.Visible = true;
                    txtStartMinMax_04_P2.Enabled = false;
                    break;
                case 164:
                    txtStartMinMax_04_P2.Visible = true;
                    txtStartMinMax_05_P2.Enabled = false;
                    break;
                case 165:
                    txtStartMinMax_05_P2.Visible = true;
                    txtStartMinMax_06_P2.Enabled = false;
                    break;
                case 166:
                    txtStartMinMax_06_P2.Visible = true;
                    txtMax_StartMinMax_P2.Enabled = false;
                    break;
                case 167:
                    txtMin_StartMinMax_P2.Enabled = false;
                    txtTriling_StartMinMax_P2.Visible = true;
                    break;
                case 168:
                    txtTriling_StartMinMax_P2.Enabled = false;
                    txtSkala_StartMinMax_P2.Visible = true;
                    break;
                case 169:
                    txtSkala_StartMinMax_P2.Enabled = false;
                    txtFull_StartMinMax_P2.Visible = true;
                    break;
                case 170:
                    txtFull_StartMinMax_P2.Enabled = false;
                    txtPoker_StartMinMax_P2.Visible = true;
                    break;
                case 171:
                    txtPoker_StartMinMax_P2.Enabled = false;
                    txtJamb_StartMinMax_P2.Visible = true;
                    break;
                case 172:
                    txtJamb_StartMinMax_P2.Enabled = false;
                    break;
                #endregion
            }
        }

        public void TotalCalculate()
        {
            int SumRow1P1 = 0, SumRow2P1 = 0, SumRow3P1 = 0, SumRow4P1 = 0, SumRow1P2 = 0, SumRow2P2 = 0, SumRow3P2 = 0, SumRow4P2 = 0;

            #region Kalkulacija za Player 1
            txtZbir_01_Nadolu_P1.Text = (CalculateNumber(NotStr(txtNadolu_01_P1.Text), NotStr(txtNadolu_02_P1.Text), NotStr(txtNadolu_03_P1.Text), NotStr(txtNadolu_04_P1.Text), NotStr(txtNadolu_05_P1.Text), NotStr(txtNadolu_06_P1.Text), NotStr(txtMax_Nadolu_P1.Text), NotStr(txtMin_Nadolu_P1.Text))).ToString();
            txtZbir_02_Max_Min_Nadolu_P1.Text = (NotStr(txtMax_Nadolu_P1.Text) + NotStr(txtMin_Nadolu_P1.Text)).ToString();
            txtZbir_03_Nadolu_P1.Text = (NotStr(txtTriling_Nadolu_P1.Text) + NotStr(txtSkala_Nadolu_P1.Text) + NotStr(txtFull_Nadolu_P1.Text) + NotStr(txtPoker_Nadolu_P1.Text) + NotStr(txtJamb_Nadolu_P1.Text)).ToString();

            txtZbir_01_Slobodna_P1.Text = (CalculateNumber(NotStr(txtSlobodna_01_P1.Text), NotStr(txtSlobodna_02_P1.Text), NotStr(txtSlobodna_03_P1.Text), NotStr(txtSlobodna_04_P1.Text), NotStr(txtSlobodna_05_P1.Text), NotStr(txtSlobodna_06_P1.Text), NotStr(txtMax_Slobodna_P1.Text), NotStr(txtMin_Slobodna_P1.Text))).ToString();
            txtZbir_02_Max_Min_Slobodna_P1.Text = (NotStr(txtMax_Slobodna_P1.Text) + NotStr(txtMin_Slobodna_P1.Text)).ToString();
            txtZbir_03_Slobodna_P1.Text = (NotStr(txtTriling_Slobodna_P1.Text) + NotStr(txtSkala_Slobodna_P1.Text) + NotStr(txtFull_Slobodna_P1.Text) + NotStr(txtPoker_Slobodna_P1.Text) + NotStr(txtJamb_Slobodna_P1.Text)).ToString();

            txtZbir_01_Nagore_P1.Text = (CalculateNumber(NotStr(txtNagore_01_P1.Text), NotStr(txtNagore_02_P1.Text), NotStr(txtNagore_03_P1.Text), NotStr(txtNagore_04_P1.Text), NotStr(txtNagore_05_P1.Text), NotStr(txtNagore_06_P1.Text), NotStr(txtMax_Nagore_P1.Text), NotStr(txtMin_Nagore_P1.Text))).ToString();
            txtZbir_02_Max_Min_Nagore_P1.Text = (NotStr(txtMax_Nagore_P1.Text) + NotStr(txtMin_Nagore_P1.Text)).ToString();
            txtZbir_03_Nagore_P1.Text = (NotStr(txtTriling_Nagore_P1.Text) + NotStr(txtSkala_Nagore_P1.Text) + NotStr(txtFull_Nagore_P1.Text) + NotStr(txtPoker_Nagore_P1.Text) + NotStr(txtJamb_Nagore_P1.Text)).ToString();

            txtZbir_01_StartMinMax_P1.Text = (CalculateNumber(NotStr(txtStartMinMax_01_P1.Text), NotStr(txtStartMinMax_02_P1.Text), NotStr(txtStartMinMax_03_P1.Text), NotStr(txtStartMinMax_04_P1.Text), NotStr(txtStartMinMax_05_P1.Text), NotStr(txtStartMinMax_06_P1.Text), NotStr(txtMax_StartMinMax_P1.Text), NotStr(txtMin_StartMinMax_P1.Text))).ToString();
            txtZbir_02_Max_Min_StartMinMax_P1.Text = (NotStr(txtMax_StartMinMax_P1.Text) + NotStr(txtMin_StartMinMax_P1.Text)).ToString();
            txtZbir_03_StartMinMax_P1.Text = (NotStr(txtTriling_StartMinMax_P1.Text) + NotStr(txtSkala_StartMinMax_P1.Text) + NotStr(txtFull_StartMinMax_P1.Text) + NotStr(txtPoker_StartMinMax_P1.Text) + NotStr(txtJamb_StartMinMax_P1.Text)).ToString();


            SumRow1P1 = (CalculateSumaColl(NotStr(txtZbir_01_Nadolu_P1.Text), NotStr(txtZbir_02_Max_Min_Nadolu_P1.Text), NotStr(txtZbir_03_Nadolu_P1.Text)));
            SumRow2P1 = (CalculateSumaColl(NotStr(txtZbir_01_Slobodna_P1.Text), NotStr(txtZbir_02_Max_Min_Slobodna_P1.Text), NotStr(txtZbir_03_Slobodna_P1.Text)));
            SumRow3P1 = (CalculateSumaColl(NotStr(txtZbir_01_Nagore_P1.Text), NotStr(txtZbir_02_Max_Min_Nagore_P1.Text), NotStr(txtZbir_03_Nagore_P1.Text)));
            SumRow4P1 = (CalculateSumaColl(NotStr(txtZbir_01_StartMinMax_P1.Text), NotStr(txtZbir_02_Max_Min_StartMinMax_P1.Text), NotStr(txtZbir_03_StartMinMax_P1.Text)));

            lblRezP1.Text = (SumRow1P1 + SumRow2P1 + SumRow3P1 + SumRow4P1).ToString();
            #endregion

            #region Kalkulacija za Player 2
            txtZbir_01_Nadolu_P2.Text = (CalculateNumber(NotStr(txtNadolu_01_P2.Text), NotStr(txtNadolu_02_P2.Text), NotStr(txtNadolu_03_P2.Text), NotStr(txtNadolu_04_P2.Text), NotStr(txtNadolu_05_P2.Text), NotStr(txtNadolu_06_P2.Text), NotStr(txtMax_Nadolu_P2.Text), NotStr(txtMin_Nadolu_P2.Text))).ToString();
            txtZbir_02_Max_Min_Nadolu_P2.Text = (NotStr(txtMax_Nadolu_P2.Text) + NotStr(txtMin_Nadolu_P2.Text)).ToString();
            txtZbir_03_Nadolu_P2.Text = (NotStr(txtTriling_Nadolu_P2.Text) + NotStr(txtSkala_Nadolu_P2.Text) + NotStr(txtFull_Nadolu_P2.Text) + NotStr(txtPoker_Nadolu_P2.Text) + NotStr(txtJamb_Nadolu_P2.Text)).ToString();

            txtZbir_01_Slobodna_P2.Text = (CalculateNumber(NotStr(txtSlobodna_01_P2.Text), NotStr(txtSlobodna_02_P2.Text), NotStr(txtSlobodna_03_P2.Text), NotStr(txtSlobodna_04_P2.Text), NotStr(txtSlobodna_05_P2.Text), NotStr(txtSlobodna_06_P2.Text), NotStr(txtMax_Slobodna_P2.Text), NotStr(txtMin_Slobodna_P2.Text))).ToString();
            txtZbir_02_Max_Min_Slobodna_P2.Text = (NotStr(txtMax_Slobodna_P2.Text) + NotStr(txtMin_Slobodna_P2.Text)).ToString();
            txtZbir_03_Slobodna_P2.Text = (NotStr(txtTriling_Slobodna_P2.Text) + NotStr(txtSkala_Slobodna_P2.Text) + NotStr(txtFull_Slobodna_P2.Text) + NotStr(txtPoker_Slobodna_P2.Text) + NotStr(txtJamb_Slobodna_P2.Text)).ToString();

            txtZbir_01_Nagore_P2.Text = (CalculateNumber(NotStr(txtNagore_01_P2.Text), NotStr(txtNagore_02_P2.Text), NotStr(txtNagore_03_P2.Text), NotStr(txtNagore_04_P2.Text), NotStr(txtNagore_05_P2.Text), NotStr(txtNagore_06_P2.Text), NotStr(txtMax_Nagore_P2.Text), NotStr(txtMin_Nagore_P2.Text))).ToString();
            txtZbir_02_Max_Min_Nagore_P2.Text = (NotStr(txtMax_Nagore_P2.Text) + NotStr(txtMin_Nagore_P2.Text)).ToString();
            txtZbir_03_Nagore_P2.Text = (NotStr(txtTriling_Nagore_P2.Text) + NotStr(txtSkala_Nagore_P2.Text) + NotStr(txtFull_Nagore_P2.Text) + NotStr(txtPoker_Nagore_P2.Text) + NotStr(txtJamb_Nagore_P2.Text)).ToString();

            txtZbir_01_StartMinMax_P2.Text = (CalculateNumber(NotStr(txtStartMinMax_01_P2.Text), NotStr(txtStartMinMax_02_P2.Text), NotStr(txtStartMinMax_03_P2.Text), NotStr(txtStartMinMax_04_P2.Text), NotStr(txtStartMinMax_05_P2.Text), NotStr(txtStartMinMax_06_P2.Text), NotStr(txtMax_StartMinMax_P2.Text), NotStr(txtMin_StartMinMax_P2.Text))).ToString();
            txtZbir_02_Max_Min_StartMinMax_P2.Text = (NotStr(txtMax_StartMinMax_P2.Text) + NotStr(txtMin_StartMinMax_P2.Text)).ToString();
            txtZbir_03_StartMinMax_P2.Text = (NotStr(txtTriling_StartMinMax_P2.Text) + NotStr(txtSkala_StartMinMax_P2.Text) + NotStr(txtFull_StartMinMax_P2.Text) + NotStr(txtPoker_StartMinMax_P2.Text) + NotStr(txtJamb_StartMinMax_P2.Text)).ToString();


            SumRow1P2 = (CalculateSumaColl(NotStr(txtZbir_01_Nadolu_P2.Text), NotStr(txtZbir_02_Max_Min_Nadolu_P2.Text), NotStr(txtZbir_03_Nadolu_P2.Text)));
            SumRow2P2 = (CalculateSumaColl(NotStr(txtZbir_01_Slobodna_P2.Text), NotStr(txtZbir_02_Max_Min_Slobodna_P2.Text), NotStr(txtZbir_03_Slobodna_P2.Text)));
            SumRow3P2 = (CalculateSumaColl(NotStr(txtZbir_01_Nagore_P2.Text), NotStr(txtZbir_02_Max_Min_Nagore_P2.Text), NotStr(txtZbir_03_Nagore_P2.Text)));
            SumRow4P2 = (CalculateSumaColl(NotStr(txtZbir_01_StartMinMax_P2.Text), NotStr(txtZbir_02_Max_Min_StartMinMax_P2.Text), NotStr(txtZbir_03_StartMinMax_P2.Text)));

            lblRezP2.Text = (SumRow1P2 + SumRow2P2 + SumRow3P2 + SumRow4P2).ToString();
            #endregion


        }

        public int NotStr(string str)
        {
            if (str.Trim().Length == 0)
                return 0;
            else
                return Convert.ToInt32(str);
        }
        public int CalculateNumber(int b1, int b2, int b3, int b4, int b5, int b6, int Max, int Min)
        {
            int S = 0;
            S = ((Max - Min) * b1) + b2 + b3 + b4 + b5 + b6;
            if ((b1 + b2 + b3 + b4 + b5 + b6) >= 60)
                return (S + 30);
            else
                return S;
        }
        public int CalculateSumaColl(int n1, int n2, int n3)
        {
            return n1 + n2 + n3;
        }

        #region PLAYER 1

        #region Textbox Event Nadole za Player 1
        private void txtNadolu_01_P1_Click(object sender, EventArgs e)
        {
            here = txtNadolu_01_P1.TabIndex; 
            GetContent(here);
        }
        private void txtNadolu_02_P1_Click(object sender, EventArgs e)
        {
            here = txtNadolu_02_P1.TabIndex;
            GetContent(txtNadolu_02_P1.TabIndex);
        }
        private void txtNadolu_03_P1_Click(object sender, EventArgs e)
        {
            here = txtNadolu_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_04_P1_Click(object sender, EventArgs e)
        {
            here = txtNadolu_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_05_P1_Click(object sender, EventArgs e)
        {
            here = txtNadolu_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_06_P1_Click(object sender, EventArgs e)
        {
            here = txtNadolu_06_P1.TabIndex;
            GetContent(here);
        }
        private void txtNadolu_01_P1_Leave(object sender, EventArgs e)
        {
            txtNadolu_01_P1.Clear();
            
        }

        private void txtNadolu_02_P1_Leave(object sender, EventArgs e)
        {
            txtNadolu_02_P1.Clear();
           
        }
        private void txtNadolu_03_P1_Leave(object sender, EventArgs e)
        {
            txtNadolu_03_P1.Clear();
          
        }

        private void txtNadolu_04_P1_Leave(object sender, EventArgs e)
        {
            txtNadolu_04_P1.Clear();
         
        }

        private void txtNadolu_05_P1_Leave(object sender, EventArgs e)
        {
            txtNadolu_05_P1.Clear();
           
        }

        private void txtNadolu_06_P1_Leave(object sender, EventArgs e)
        {
            txtNadolu_06_P1.Clear();
           
        }

        private void txtMax_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_Nadolu_P1.TabIndex;
            GetContent(here);
        }
        private void txtMin_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Nadolu_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Nadolu_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_Nadolu_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Nadolu_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Nadolu_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Nadolu_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Nadolu_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Nadolu_P1.Clear();
        }

        private void txtMin_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Nadolu_P1.Clear();
        }

        private void txtTriling_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Nadolu_P1.Clear();
        }

        private void txtSkala_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Nadolu_P1.Clear();
        }

        private void txtFull_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Nadolu_P1.Clear();
        }

        private void txtPoker_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Nadolu_P1.Clear();
        }

        private void txtJamb_Nadolu_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_Nadolu_P1.Clear();
        }
        #endregion

        #region Textbox Event Slobodna za Player 1
        private void txtSlobodna_01_P1_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_02_P1_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_02_P1.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_03_P1_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_04_P1_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_05_P1_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_06_P1_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Slobodna_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Slobodna_P1.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_01_P1_Leave(object sender, EventArgs e)
        {
            txtSlobodna_01_P1.Clear();

        }

        private void txtSlobodna_02_P1_Leave(object sender, EventArgs e)
        {
            txtSlobodna_02_P1.Clear();
        }

        private void txtSlobodna_03_P1_Leave(object sender, EventArgs e)
        {
            txtSlobodna_03_P1.Clear();
        }

        private void txtSlobodna_04_P1_Leave(object sender, EventArgs e)
        {
            txtSlobodna_04_P1.Clear();
        }

        private void txtSlobodna_05_P1_Leave(object sender, EventArgs e)
        {
            txtSlobodna_05_P1.Clear();
        }

        private void txtSlobodna_06_P1_Leave(object sender, EventArgs e)
        {
            txtSlobodna_06_P1.Clear();
        }

        private void txtMax_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Slobodna_P1.Clear();
        }

        private void txtMin_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Slobodna_P1.Clear();
        }

        private void txtTriling_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Slobodna_P1.Clear();
        }

        private void txtSkala_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Slobodna_P1.Clear();
        }

        private void txtFull_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Slobodna_P1.Clear();
        }

        private void txtPoker_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Slobodna_P1.Clear();
        }

        private void txtJamb_Slobodna_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_Slobodna_P1.Clear();
        }
        #endregion

        #region Textbox Event Nagore za Player 1
        private void txtNagore_01_P1_Click(object sender, EventArgs e)
        {
            here = txtNagore_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtNagore_02_P1_Click(object sender, EventArgs e)
        {
            here = txtNagore_02_P1.TabIndex;
            GetContent(here);
        }

        private void txtNagore_03_P1_Click(object sender, EventArgs e)
        {
            here = txtNagore_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtNagore_04_P1_Click(object sender, EventArgs e)
        {
            here = txtNagore_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtNagore_05_P1_Click(object sender, EventArgs e)
        {
            here = txtNagore_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtNagore_06_P1_Click(object sender, EventArgs e)
        {
            here = txtNagore_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Nagore_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Nagore_P1.TabIndex;
            GetContent(here);
        }

        private void txtNagore_01_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtNagore_02_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtNagore_03_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtNagore_04_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtNagore_05_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtNagore_06_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtMax_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtMin_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtTriling_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtSkala_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtFull_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtPoker_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }

        private void txtJamb_Nagore_P1_Leave(object sender, EventArgs e)
        {

        }
        #endregion

        #region Textbox Event Start Min max za Player 1
        private void txtStartMinMax_01_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_02_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_02_P1.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_03_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_04_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_05_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_06_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_StartMinMax_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_StartMinMax_P1.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_01_P1_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_01_P1.Clear();
        }

        private void txtStartMinMax_02_P1_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_02_P1.Clear();
        }

        private void txtStartMinMax_03_P1_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_03_P1.Clear();
        }

        private void txtStartMinMax_04_P1_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_04_P1.Clear();
        }

        private void txtStartMinMax_05_P1_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_05_P1.Clear();
        }

        private void txtStartMinMax_06_P1_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_06_P1.Clear();
        }

        private void txtMax_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtMax_StartMinMax_P1.Clear();
        }

        private void txtMin_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtMin_StartMinMax_P1.Clear();
        }

        private void txtTriling_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_StartMinMax_P1.Clear();
        }

        private void txtSkala_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_StartMinMax_P1.Clear();
        }

        private void txtFull_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtFull_StartMinMax_P1.Clear();
        }

        private void txtPoker_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_StartMinMax_P1.Clear();
        }

        private void txtJamb_StartMinMax_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_StartMinMax_P1.Clear();
        }
        #endregion

        #endregion  END za PLAYER 1


        #region PLAYER 2

        #region Textbox Event Nadole za Player 2

        private void txtNadolu_01_P2_Click(object sender, EventArgs e)
        {
            here = txtNadolu_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_02_P2_Click(object sender, EventArgs e)
        {
            here = txtNadolu_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_03_P2_Click(object sender, EventArgs e)
        {
            here = txtNadolu_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_04_P2_Click(object sender, EventArgs e)
        {
            here = txtNadolu_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_05_P2_Click(object sender, EventArgs e)
        {
            here = txtNadolu_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtNadolu_06_P2_Click(object sender, EventArgs e)
        {
            here = txtNadolu_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_Nadolu_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Nadolu_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Nadolu_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Nadolu_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Nadolu_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Nadolu_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Nadolu_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Nadolu_P2.TabIndex;
            GetContent(here);
        }
        private void txtNadolu_01_P2_Leave(object sender, EventArgs e)
        {
            txtNadolu_01_P2.Clear();
        }

        private void txtNadolu_02_P2_Leave(object sender, EventArgs e)
        {
            txtNadolu_02_P2.Clear();
        }

        private void txtNadolu_03_P2_Leave(object sender, EventArgs e)
        {
            txtNadolu_03_P2.Clear();
        }

        private void txtNadolu_04_P2_Leave(object sender, EventArgs e)
        {
            txtNadolu_04_P2.Clear();
        }

        private void txtNadolu_05_P2_Leave(object sender, EventArgs e)
        {
            txtNadolu_05_P2.Clear();
        }

        private void txtNadolu_06_P2_Leave(object sender, EventArgs e)
        {
            txtNadolu_06_P2.Clear();
        }

        private void txtMax_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Nadolu_P2.Clear();
        }

        private void txtMin_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Nadolu_P2.Clear();
        }

        private void txtTriling_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Nadolu_P2.Clear();
        }

        private void txtSkala_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Nadolu_P2.Clear();
        }

        private void txtFull_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Nadolu_P2.Clear();
        }

        private void txtPoker_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Nadolu_P2.Clear();
        }

        private void txtJamb_Nadolu_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Nadolu_P2.Clear();
        }
        #endregion

        #region Textbox Event Slobodna za Player 2
        private void txtSlobodna_01_P2_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_02_P2_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_03_P2_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_04_P2_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_05_P2_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_06_P2_Click(object sender, EventArgs e)
        {
            here = txtSlobodna_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Slobodna_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Slobodna_P2.TabIndex;
            GetContent(here);
        }

        private void txtSlobodna_01_P2_Leave(object sender, EventArgs e)
        {
            txtSlobodna_01_P2.Clear();
        }

        private void txtSlobodna_02_P2_Leave(object sender, EventArgs e)
        {
            txtSlobodna_02_P2.Clear();
        }

        private void txtSlobodna_03_P2_Leave(object sender, EventArgs e)
        {
            txtSlobodna_03_P2.Clear();
        }

        private void txtSlobodna_04_P2_Leave(object sender, EventArgs e)
        {
            txtSlobodna_04_P2.Clear();

        }

        private void txtSlobodna_05_P2_Leave(object sender, EventArgs e)
        {
            txtSlobodna_05_P2.Clear();
        }

        private void txtSlobodna_06_P2_Leave(object sender, EventArgs e)
        {
            txtSlobodna_06_P2.Clear();
        }

        private void txtMax_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Slobodna_P2.Clear();
        }

        private void txtMin_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Slobodna_P2.Clear();
        }

        private void txtTriling_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Slobodna_P2.Clear();
        }

        private void txtSkala_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Slobodna_P2.Clear();
        }

        private void txtFull_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Slobodna_P2.Clear();
        }

        private void txtPoker_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Slobodna_P2.Clear();
        }

        private void txtJamb_Slobodna_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Slobodna_P2.Clear();
        }
        #endregion

        #region Textbox Event Nagore za Player 2
        private void txtNagore_01_P2_Click(object sender, EventArgs e)
        {
            here = txtNagore_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtNagore_02_P2_Click(object sender, EventArgs e)
        {
            here = txtNagore_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtNagore_03_P2_Click(object sender, EventArgs e)
        {
            here = txtNagore_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtNagore_04_P2_Click(object sender, EventArgs e)
        {
            here = txtNagore_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtNagore_05_P2_Click(object sender, EventArgs e)
        {
            here = txtNagore_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtNagore_06_P2_Click(object sender, EventArgs e)
        {
            here = txtNagore_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_Nagore_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Nagore_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Nagore_P2.TabIndex;
            GetContent(here);

        }

        private void txtSkala_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Nagore_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Nagore_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Nagore_P2.TabIndex;
            GetContent(here);

        }

        private void txtJamb_Nagore_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Nagore_P2.TabIndex;
            GetContent(here);
        }

        private void txtNagore_01_P2_Leave(object sender, EventArgs e)
        {
            txtNagore_01_P2.Clear();
        }

        private void txtNagore_02_P2_Leave(object sender, EventArgs e)
        {
            txtNagore_02_P2.Clear();
        }

        private void txtNagore_03_P2_Leave(object sender, EventArgs e)
        {
            txtNagore_03_P2.Clear();
        }

        private void txtNagore_04_P2_Leave(object sender, EventArgs e)
        {
            txtNagore_04_P2.Clear();
        }

        private void txtNagore_05_P2_Leave(object sender, EventArgs e)
        {
            txtNagore_05_P2.Clear();
        }

        private void txtNagore_06_P2_Leave(object sender, EventArgs e)
        {
            txtNagore_06_P2.Clear();
        }

        private void txtMax_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Nagore_P2.Clear();
        }

        private void txtMin_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Nagore_P2.Clear();
        }

        private void txtTriling_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Nagore_P2.Clear();
        }

        private void txtSkala_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Nagore_P2.Clear();
        }

        private void txtFull_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Nagore_P2.Clear();
        }

        private void txtPoker_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Nagore_P2.Clear();
        }

        private void txtJamb_Nagore_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Nagore_P2.Clear();
        }
        #endregion

        #region Textbox Event Start Min-Max za Player 2
        private void txtStartMinMax_01_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_02_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_03_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_04_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_05_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_06_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_StartMinMax_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_StartMinMax_P2.TabIndex;
            GetContent(here);
        }

        private void txtStartMinMax_01_P2_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_01_P2.Clear();
        }

        private void txtStartMinMax_02_P2_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_02_P2.Clear();
        }

        private void txtStartMinMax_03_P2_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_03_P2.Clear();
        }

        private void txtStartMinMax_04_P2_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_04_P2.Clear();
        }

        private void txtStartMinMax_05_P2_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_05_P2.Clear();
        }

        private void txtStartMinMax_06_P2_Leave(object sender, EventArgs e)
        {
            txtStartMinMax_06_P2.Clear();
        }

        private void txtMax_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtMax_StartMinMax_P2.Clear();
        }

        private void txtMin_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtMin_StartMinMax_P2.Clear();
        }

        private void txtTriling_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_StartMinMax_P2.Clear();
        }

        private void txtSkala_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_StartMinMax_P2.Clear();
        }

        private void txtFull_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtFull_StartMinMax_P2.Clear();
        }

        private void txtPoker_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_StartMinMax_P2.Clear();
        }

        private void txtJamb_StartMinMax_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_StartMinMax_P2.Clear();
        }
        #endregion END Start Min-Max

        private void gbPlayer1_Enter(object sender, EventArgs e)
        {

        }





        #endregion END za PLAYER 2


    }
}
