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
    public partial class GameForm3 : Form
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

        public bool odjava1 = false, odjava2 = false, najava1 = false, najava2 = false;
        public bool[] NajavaP1 = new bool[14];
        public bool[] OdjavaP1 = new bool[14];
        public bool[] RacnaP1 = new bool[14];

        public bool[] NajavaP2 = new bool[14];
        public bool[] OdjavaP2 = new bool[14];
        public bool[] RacnaP2 = new bool[14];

        public List<Najava> lNajavaP1;
        public List<Najava> lNajavaP2;
        public List<Najava> lRacnaP1;
        public List<Najava> lRacnaP2;

        bool started;
        public int here = 0;

        public GameForm3(int pCount, StartForm form)
        {

            InitializeComponent();
            startForm = form;

            lNajavaP1 = new List<Najava>();
            lNajavaP2 = new List<Najava>();
            lRacnaP1 = new List<Najava>();
            lRacnaP2 = new List<Najava>();

            imgBlank = Properties.Resources.dice_blank;
            img1 = Properties.Resources.dice_1;
            img2 = Properties.Resources.dice_2;
            img3 = Properties.Resources.dice_3;
            img4 = Properties.Resources.dice_4;
            img5 = Properties.Resources.dice_5;
            img6 = Properties.Resources.dice_6;

            game = new Game(pCount);
            btnEndTurn.Enabled = false;

            for (int i = 0; i < game.Players.Count; i++)
                game.Players[i] = new Player(startForm.name[i], startForm.GT);

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (here != 0)
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

            imgBlank = Properties.Resources.dice_blank;
            img1 = Properties.Resources.dice_1;
            img2 = Properties.Resources.dice_2;
            img3 = Properties.Resources.dice_3;
            img4 = Properties.Resources.dice_4;
            img5 = Properties.Resources.dice_5;
            img6 = Properties.Resources.dice_6;

            for (int i = 0; i < NajavaP1.Length; i++)
            {
                NajavaP1[i] = false;
            }

            pic1.Image = ImageDice(0);
            pic2.Image = ImageDice(0);
            pic3.Image = ImageDice(0);
            pic4.Image = ImageDice(0);
            pic5.Image = ImageDice(0);
            pic6.Image = ImageDice(0);



            cbNajava_P1.Enabled = false;
            lblGameTurn.Text = "Преостанати вртења: " + game.Players[game.WhoTurn].GameTurns.ToString();

            cbNajava_P1.Items.Clear();
            lNajavaP1.Add(new Najava(0, "ништо"));
            lNajavaP1.Add(new Najava(1, "единици (1)"));
            lNajavaP1.Add(new Najava(2, "двојки (2)"));
            lNajavaP1.Add(new Najava(3, "тројки (3)"));
            lNajavaP1.Add(new Najava(4, "четворки (4)"));
            lNajavaP1.Add(new Najava(5, "петки (5)"));
            lNajavaP1.Add(new Najava(6, "шестки (6)"));
            lNajavaP1.Add(new Najava(7, "максимум (Max)"));
            lNajavaP1.Add(new Najava(8, "минимум (Min)"));
            lNajavaP1.Add(new Najava(9, "Трилинг"));
            lNajavaP1.Add(new Najava(10, "Скала"));
            lNajavaP1.Add(new Najava(11, "Фул Хаус"));
            lNajavaP1.Add(new Najava(12, "Покер"));
            lNajavaP1.Add(new Najava(13, "Јабм"));

            for (int i = 0; i < lNajavaP1.Count; i++)
            {
                cbNajava_P1.Items.Add(lNajavaP1[i]);
            }
            cbNajava_P1.SelectedIndex = 0;

            cbNajava_P2.Items.Clear();
            lNajavaP2.Add(new Najava(0, "ништо"));
            lNajavaP2.Add(new Najava(1, "единици (1)"));
            lNajavaP2.Add(new Najava(2, "двојки (2)"));
            lNajavaP2.Add(new Najava(3, "тројки (3)"));
            lNajavaP2.Add(new Najava(4, "четворки (4)"));
            lNajavaP2.Add(new Najava(5, "петки (5)"));
            lNajavaP2.Add(new Najava(6, "шестки (6)"));
            lNajavaP2.Add(new Najava(7, "максимум (Max)"));
            lNajavaP2.Add(new Najava(8, "минимум (Min)"));
            lNajavaP2.Add(new Najava(9, "Трилинг"));
            lNajavaP2.Add(new Najava(10, "Скала"));
            lNajavaP2.Add(new Najava(11, "Фул Хаус"));
            lNajavaP2.Add(new Najava(12, "Покер"));
            lNajavaP2.Add(new Najava(13, "Јабм"));

           

            for (int i = 0; i < lNajavaP2.Count; i++)
            {
                cbNajava_P2.Items.Add(lNajavaP2[i]);
            }
            cbNajava_P2.SelectedIndex = 0;

            for (int i = 0; i < NajavaP1.Length; i++)
                NajavaP1[i] = false;

            for (int i = 0; i < NajavaP2.Length; i++)
                NajavaP2[i] = false;

            for (int i = 0; i < OdjavaP1.Length; i++)
                OdjavaP1[i] = false;

            for (int i = 0; i < OdjavaP2.Length; i++)
                OdjavaP2[i] = false;

            for (int i = 0; i < RacnaP1.Length; i++)
                RacnaP1[i] = false;

            for (int i = 0; i < RacnaP2.Length; i++)
                RacnaP2[i] = false;

            lRacnaP1.Clear();
            for (int i = 0; i < 13; i++)
                lRacnaP1.Insert(i, new Najava(i + 1));

            lRacnaP2.Clear();
            for (int i = 0; i < 13; i++)
                lRacnaP2.Insert(i, new Najava(i + 1));

              

            SetNajavaEnableP1();
            SetNajavaEnableP2();
            SetOdjavaEnableP1();
            SetOdjavaEnableP2();
            SetRacnaEnableP1();
            SetRacnaEnableP2();

            lblIme.Text = "Се чека " + (game.Players[game.WhoTurn].Name);

            
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

            
            if (game.Players[0].RollTurns == 1)
            { 
                for (int i = 0; i < lRacnaP1.Count; i++)
                {
                    RacnaP1[lRacnaP1[i].Value] = true;
                    
                }
           
            }
            else
            {
                for (int i = 0; i < RacnaP1.Length; i++)
                {
                    RacnaP1[i] = false;

                }
                
            }
            SetRacnaEnableP1();

            if (game.Players[1].RollTurns == 1)
            {
                for (int i = 0; i < lRacnaP2.Count; i++)
                {
                    RacnaP2[lRacnaP2[i].Value] = true;
                    
                }
      
            }
            else
            {
                for (int i = 0; i < RacnaP2.Length; i++)
                {
                    RacnaP2[i] = false;
                }
                
            }
            SetRacnaEnableP2();

            

            if (game.Players[0].RollTurns == 1 && !najava1 && !odjava1)
                cbNajava_P1.Enabled = true;
            else
                cbNajava_P1.Enabled = false;


            if (odjava2 && najava1)
            {
                OdjavaP2[lNajavaP1[cbNajava_P1.SelectedIndex].Value] = true;
                SetOdjavaEnableP2();
                cbNajava_P2.Enabled = false;
            }
            else
                ResetO();
            
            if (game.Players[1].RollTurns == 1 && !najava2 && !odjava2)
                cbNajava_P2.Enabled = true;
            else
                cbNajava_P2.Enabled = false;


            if (odjava1 && najava2)
            {
                OdjavaP1[lNajavaP2[cbNajava_P2.SelectedIndex].Value] = true;
                SetOdjavaEnableP1();
                cbNajava_P1.Enabled = false;
            }
            else
                ResetO();




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
                cbNajava_P1.Enabled = false;
                cbNajava_P2.Enabled = false;

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
                        gbMod1_P1.Enabled = true;
                        gbMod2_P1.Enabled = true;
                        gbMod3_P1.Enabled = true;

                        if (najava1 && !odjava1)
                        {
                            lNajavaP1.RemoveAt(cbNajava_P1.SelectedIndex);
                            cbNajava_P1.Items.Clear();

                            for (int i = 0; i < lNajavaP1.Count; i++)
                                cbNajava_P1.Items.Add(lNajavaP1[i]);

                            cbNajava_P1.SelectedIndex = 0;
                            SetOdjavaEnableP2();
                            najava1 = false;
                        }
                        else if (najava2 && odjava1)
                        {
                            gbMod1_P1.Enabled = false;
                            gbMod2_P1.Enabled = false;
                            gbMod3_P1.Enabled = false;
                            SetOdjavaEnableP1();
                            cbNajava_P1.Enabled = false;
                        }
                       
                        break;

                    case 1:
                        gbPlayer1.Enabled = false;
                        gbPlayer2.Enabled = true;
                        gbMod1_P2.Enabled = true;
                        gbMod2_P2.Enabled = true;
                        gbMod3_P2.Enabled = true;

                        if (najava2 && !odjava2)
                        {
                            lNajavaP2.RemoveAt(cbNajava_P2.SelectedIndex);
                            cbNajava_P2.Items.Clear();

                            for (int i = 0; i < lNajavaP2.Count; i++)
                                cbNajava_P2.Items.Add(lNajavaP2[i]);
                            SetOdjavaEnableP1();
                            cbNajava_P2.SelectedIndex = 0;
                            najava1 = false;

                        }
                        else if (odjava2 && najava1)
                        {
                            gbMod1_P2.Enabled = false;
                            gbMod2_P2.Enabled = false;
                            gbMod3_P2.Enabled = false;
                            SetOdjavaEnableP2();
                            cbNajava_P2.Enabled = false;
                        }
                        break;
                }

                if (game.Players[0].RollTurns == 1 && here > 91 && here < 104)
                {
                    for (int i = 0; i < lRacnaP1.Count; i++)
                        if (lRacnaP1[i].Value == (here - 92)+1)
                        {
                            lRacnaP1.Remove(lRacnaP1[i]);
                        }

                    for (int i = 0; i < RacnaP1.Length; i++)
                        RacnaP1[i] = false;

                    for (int i = 0; i < lRacnaP1.Count; i++)
                        RacnaP1[lRacnaP1[i].Value] = true;
                }
                

                if (game.Players[1].RollTurns == 1 && here > 211 && here < 225)
                {
                    for (int i = 0; i < lRacnaP2.Count; i++)
                        if (lRacnaP2[i].Value == (here - 212) + 1)
                        {
                            lRacnaP2.Remove(lRacnaP2[i]);
                        }

                    for (int i = 0; i < RacnaP2.Length; i++)
                        RacnaP2[i] = false;

                    for (int i = 0; i < lRacnaP2.Count; i++)
                        RacnaP2[lRacnaP2[i].Value] = true;
                }
                

               

                here = 0;

                for (int i = 0; i < OdjavaP1.Length; i++)
                    OdjavaP1[i] = false;

                for (int i = 0; i < OdjavaP2.Length; i++)
                    OdjavaP2[i] = false;

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
                timer.Stop();
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


            
            ResetO();
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
                //Koloni za Player 1
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

                #region Kolona Najava za Player 1
                case 53:
                    txtNajava_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 54:
                    txtNajava_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 55:
                    txtNajava_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 56:
                    txtNajava_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 57:
                    txtNajava_05_P1.Text = (game.Players[0].DiceResult[4] * 5).ToString();
                    break;
                case 58:
                    txtNajava_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 59:
                    txtMax_Najava_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 60:
                    txtMin_Najava_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 61:
                    txtTriling_Najava_P1.Text = (game.Players[0].Znak[0].value).ToString();
                    break;
                case 62:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Najava_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Najava_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Najava_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 63:
                    txtFull_Najava_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 64:
                    txtPoker_Najava_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 65:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Najava_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Najava_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Najava_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Najava_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Odjava za Player 1
                case 66:
                    txtOdjava_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 67:
                    txtOdjava_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 68:
                    txtOdjava_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 69:
                    txtOdjava_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 70:
                    txtOdjava_05_P1.Text = (game.Players[0].DiceResult[5] * 5).ToString();
                    break;
                case 71:
                    txtOdjava_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 72:
                    txtMax_Odjava_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 73:
                    txtMin_Odjava_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 74:
                    txtTriling_Odjava_P1.Text = (game.Players[0].Znak[0].value).ToString();
                    break;
                case 75:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Odjava_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Odjava_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Odjava_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 76:
                    txtFull_Odjava_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 77:
                    txtPoker_Odjava_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 78:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Odjava_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Odjava_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Odjava_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Odjava_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Start1J za Player 1
                case 79:
                    txtStart1J_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 80:
                    txtStart1J_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 81:
                    txtStart1J_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 82:
                    txtStart1J_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 83:
                    txtStart1J_05_P1.Text = (game.Players[0].DiceResult[5] * 5).ToString();
                    break;
                case 84:
                    txtStart1J_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 85:
                    txtMax_Start1J_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 86:
                    txtMin_Start1J_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 87:
                    txtTriling_Start1J_P1.Text = (game.Players[0].Znak[0].value).ToString();
                    break;
                case 88:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Start1J_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Start1J_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Start1J_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 89:
                    txtFull_Start1J_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 90:
                    txtPoker_Start1J_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 91:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Start1J_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Start1J_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Start1J_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Start1J_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Racna za Player 1
                case 92:
                    txtRacna_01_P1.Text = (game.Players[0].DiceResult[0] * 1).ToString();
                    break;
                case 93:
                    txtRacna_02_P1.Text = (game.Players[0].DiceResult[1] * 2).ToString();
                    break;
                case 94:
                    txtRacna_03_P1.Text = (game.Players[0].DiceResult[2] * 3).ToString();
                    break;
                case 95:
                    txtRacna_04_P1.Text = (game.Players[0].DiceResult[3] * 4).ToString();
                    break;
                case 96:
                    txtRacna_05_P1.Text = (game.Players[0].DiceResult[4] * 5).ToString();
                    break;
                case 97:
                    txtRacna_06_P1.Text = (game.Players[0].DiceResult[5] * 6).ToString();
                    break;
                case 98:
                    txtMax_Racna_P1.Text = (game.Players[0].SumaMax).ToString();
                    break;
                case 99:
                    txtMin_Racna_P1.Text = (game.Players[0].SumaMin).ToString();
                    break;
                case 100:
                    txtTriling_Racna_P1.Text = (game.Players[0].Znak[0].value).ToString();
                    break;
                case 101:
                    if (game.Players[0].Znak[9].value > game.Players[0].Znak[8].value)
                        txtSkala_Racna_P1.Text = game.Players[0].Znak[9].value.ToString();
                    else if (game.Players[0].Znak[8].value > game.Players[0].Znak[7].value)
                        txtSkala_Racna_P1.Text = game.Players[0].Znak[8].value.ToString();
                    else
                        txtSkala_Racna_P1.Text = game.Players[0].Znak[7].value.ToString();
                    break;
                case 102:
                    txtFull_Racna_P1.Text = game.Players[0].Znak[1].value.ToString();
                    break;
                case 103:
                    txtPoker_Racna_P1.Text = game.Players[0].Znak[2].value.ToString();
                    break;
                case 104:
                    if (game.Players[0].Znak[3].value > 0)
                        txtJamb_Racna_P1.Text = game.Players[0].Znak[3].value.ToString();
                    else if (game.Players[0].Znak[6].value > game.Players[0].Znak[5].value)
                        txtJamb_Racna_P1.Text = game.Players[0].Znak[6].value.ToString();
                    else if (game.Players[0].Znak[5].value >= game.Players[0].Znak[4].value)
                        txtJamb_Racna_P1.Text = game.Players[0].Znak[5].value.ToString();
                    else if (game.Players[0].Znak[4].value > game.Players[0].Znak[3].value)
                        txtJamb_Racna_P1.Text = game.Players[0].Znak[4].value.ToString();
                    break;
                #endregion

                //Koloni za Player 2
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

                #region Kolona Najava za Player 2
                case 173:
                    txtNajava_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 174:
                    txtNajava_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 175:
                    txtNajava_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 176:
                    txtNajava_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 177:
                    txtNajava_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 178:
                    txtNajava_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 179:
                    txtMax_Najava_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 180:
                    txtMin_Najava_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 181:
                    txtTriling_Najava_P2.Text = (game.Players[1].Znak[0].value).ToString();
                    break;
                case 182:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Najava_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Najava_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Najava_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 183:
                    txtFull_Najava_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 184:
                    txtPoker_Najava_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 185:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Najava_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Najava_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Najava_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Najava_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Odjava za Player 2
                case 186:
                    txtOdjava_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 187:
                    txtOdjava_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 188:
                    txtOdjava_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 189:
                    txtOdjava_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 190:
                    txtOdjava_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 191:
                    txtOdjava_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 192:
                    txtMax_Odjava_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 193:
                    txtMin_Odjava_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 194:
                    txtTriling_Odjava_P2.Text = (game.Players[1].Znak[0].value).ToString();
                    break;
                case 195:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Odjava_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Odjava_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Odjava_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 196:
                    txtFull_Odjava_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 197:
                    txtPoker_Odjava_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 198:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Odjava_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Odjava_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Odjava_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Odjava_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Start1J za Player 2
                case 199:
                    txtStart1J_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 200:
                    txtStart1J_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 201:
                    txtStart1J_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 202:
                    txtStart1J_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 203:
                    txtStart1J_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 204:
                    txtStart1J_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 205:
                    txtMax_Start1J_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 206:
                    txtMin_Start1J_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 207:
                    txtTriling_Start1J_P2.Text = (game.Players[1].Znak[0].value).ToString();
                    break;
                case 208:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Start1J_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Start1J_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Start1J_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 209:
                    txtFull_Start1J_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 210:
                    txtPoker_Start1J_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 211:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Start1J_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Start1J_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Start1J_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Start1J_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

                #region Kolona Racna za Player 2
                case 212:
                    txtRacna_01_P2.Text = (game.Players[1].DiceResult[0] * 1).ToString();
                    break;
                case 213:
                    txtRacna_02_P2.Text = (game.Players[1].DiceResult[1] * 2).ToString();
                    break;
                case 214:
                    txtRacna_03_P2.Text = (game.Players[1].DiceResult[2] * 3).ToString();
                    break;
                case 215:
                    txtRacna_04_P2.Text = (game.Players[1].DiceResult[3] * 4).ToString();
                    break;
                case 216:
                    txtRacna_05_P2.Text = (game.Players[1].DiceResult[4] * 5).ToString();
                    break;
                case 217:
                    txtRacna_06_P2.Text = (game.Players[1].DiceResult[5] * 6).ToString();
                    break;
                case 218:
                    txtMax_Racna_P2.Text = (game.Players[1].SumaMax).ToString();
                    break;
                case 219:
                    txtMin_Racna_P2.Text = (game.Players[1].SumaMin).ToString();
                    break;
                case 220:
                    txtTriling_Racna_P2.Text = (game.Players[1].Znak[0].value).ToString();
                    break;
                case 221:
                    if (game.Players[1].Znak[9].value > game.Players[1].Znak[8].value)
                        txtSkala_Racna_P2.Text = game.Players[1].Znak[9].value.ToString();
                    else if (game.Players[1].Znak[8].value > game.Players[1].Znak[7].value)
                        txtSkala_Racna_P2.Text = game.Players[1].Znak[8].value.ToString();
                    else
                        txtSkala_Racna_P2.Text = game.Players[1].Znak[7].value.ToString();
                    break;
                case 222:
                    txtFull_Racna_P2.Text = game.Players[1].Znak[1].value.ToString();
                    break;
                case 223:
                    txtPoker_Racna_P2.Text = game.Players[1].Znak[2].value.ToString();
                    break;
                case 224:
                    if (game.Players[1].Znak[3].value > 0)
                        txtJamb_Racna_P2.Text = game.Players[1].Znak[3].value.ToString();
                    else if (game.Players[1].Znak[6].value > game.Players[1].Znak[5].value)
                        txtJamb_Racna_P2.Text = game.Players[1].Znak[6].value.ToString();
                    else if (game.Players[1].Znak[5].value >= game.Players[1].Znak[4].value)
                        txtJamb_Racna_P2.Text = game.Players[1].Znak[5].value.ToString();
                    else if (game.Players[1].Znak[4].value > game.Players[1].Znak[3].value)
                        txtJamb_Racna_P2.Text = game.Players[1].Znak[4].value.ToString();
                    break;
                #endregion

            }
        }


        public void SetButtonDesable(int m)
        {
            switch (m)
            {
                //Koloni za Player 1
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

                #region Kolona Najava za Player1
                case 53:
                    txtNajava_01_P1.Enabled = false;
                    break;
                case 54:
                    txtNajava_02_P1.Enabled = false;
                    break;
                case 55:
                    txtNajava_03_P1.Enabled = false;
                    break;
                case 56:
                    txtNajava_04_P1.Enabled = false;
                    break;
                case 57:
                    txtNajava_05_P1.Enabled = false;
                    break;
                case 58:
                    txtNajava_06_P1.Enabled = false;
                    break;
                case 59:
                    txtMax_Najava_P1.Enabled = false;
                    break;
                case 60:
                    txtMin_Najava_P1.Enabled = false;
                    break;
                case 61:
                    txtTriling_Najava_P1.Enabled = false;
                    break;
                case 62:
                    txtSkala_Najava_P1.Enabled = false;
                    break;
                case 63:
                    txtFull_Najava_P1.Enabled = false;
                    break;
                case 64:
                    txtPoker_Najava_P1.Enabled = false;
                    break;
                case 65:
                    txtJamb_Najava_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Odjava za Player 1
                case 66:
                    txtOdjava_01_P1.Enabled = false;
                    break;
                case 67:
                    txtOdjava_02_P1.Enabled = false;
                    break;
                case 68:
                    txtOdjava_03_P1.Enabled = false;
                    break;
                case 69:
                    txtOdjava_04_P1.Enabled = false;
                    break;
                case 70:
                    txtOdjava_05_P1.Enabled = false;
                    break;
                case 71:
                    txtOdjava_06_P1.Enabled = false;
                    break;
                case 72:
                    txtMax_Odjava_P1.Enabled = false;
                    break;
                case 73:
                    txtMin_Odjava_P1.Enabled = false;
                    break;
                case 74:
                    txtTriling_Odjava_P1.Enabled = false;
                    break;
                case 75:
                    txtSkala_Odjava_P1.Enabled = false;
                    break;
                case 76:
                    txtFull_Odjava_P1.Enabled = false;
                    break;
                case 77:
                    txtPoker_Odjava_P1.Enabled = false;
                    break;
                case 78:
                    txtJamb_Odjava_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Start1J za Player 1
                case 79:
                    txtStart1J_01_P1.Enabled = false;
                    txtStart1J_02_P1.Visible = true;
                    break;
                case 80:
                   txtStart1J_02_P1.Enabled = false;
                    txtStart1J_03_P1.Visible = true;
                    break;
                case 81:
                    txtStart1J_03_P1.Enabled = false;
                    txtStart1J_04_P1.Visible = true;
                    break;
                case 82:
                    txtStart1J_04_P1.Enabled = false;
                    txtStart1J_05_P1.Visible = true;
                    break;
                case 83:
                    txtStart1J_05_P1.Enabled = false;
                    txtStart1J_06_P1.Visible = true;
                    break;
                case 84:
                    txtStart1J_06_P1.Enabled = false;
                    txtMax_Start1J_P1.Visible = true;
                    break;
                case 85:
                    txtMax_Start1J_P1.Enabled = false;
                    break;
                case 86:
                    txtMin_Start1J_P1.Enabled = false;
                    break;
                case 87:
                    txtMin_Start1J_P1.Visible = true;
                    txtTriling_Start1J_P1.Enabled = false;
                    break;
                case 88:
                    txtTriling_Start1J_P1.Visible = true;
                    txtSkala_Start1J_P1.Enabled = false;
                    break;
                case 89:
                    txtSkala_Start1J_P1.Visible = true;
                    txtFull_Start1J_P1.Enabled = false;
                    break;
                case 90:
                    txtFull_Start1J_P1.Visible = true;
                    txtPoker_Start1J_P1.Enabled = false;
                    break;
                case 91:
                    txtPoker_Start1J_P1.Visible = true;
                    txtJamb_Start1J_P1.Enabled = false;
                    break;
                #endregion

                #region Kolona Racna za Player 1
                case 92:
                    txtRacna_01_P1.Enabled = false;
                    break;
                case 93:
                    txtRacna_02_P1.Enabled = false;
                    break;
                case 94:
                    txtRacna_03_P1.Enabled = false;
                    break;
                case 95:
                    txtRacna_04_P1.Enabled = false;
                    break;
                case 96:
                    txtRacna_05_P1.Enabled = false;
                    break;
                case 97:
                    txtRacna_06_P1.Enabled = false;
                    break;
                case 98:
                    txtMax_Racna_P1.Enabled = false;
                    break;
                case 99:
                    txtMin_Racna_P1.Enabled = false;
                    break;
                case 100:
                    txtTriling_Racna_P1.Enabled = false;
                    break;
                case 101:
                    txtSkala_Racna_P1.Enabled = false;
                    break;
                case 102:
                    txtFull_Racna_P1.Enabled = false;
                    break;
                case 103:
                    txtPoker_Racna_P1.Enabled = false;
                    break;
                case 104:
                    txtJamb_Racna_P1.Enabled = false;
                    break;
                #endregion


                //Koloni za Player 2
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

                #region Kolona Najava za Player 2
                case 173:
                    txtNajava_01_P2.Enabled = false;
                    break;
                case 174:
                    txtNajava_02_P2.Enabled = false;
                    break;
                case 175:
                    txtNajava_03_P2.Enabled = false;
                    break;
                case 176:
                    txtNajava_04_P2.Enabled = false;
                    break;
                case 177:
                    txtNajava_05_P2.Enabled = false;
                    break;
                case 178:
                    txtNajava_06_P2.Enabled = false;
                    break;
                case 179:
                    txtMax_Najava_P2.Enabled = false;
                    break;
                case 180:
                    txtMin_Najava_P2.Enabled = false;
                    break;
                case 181:
                    txtTriling_Najava_P2.Enabled = false;
                    break;
                case 182:
                    txtSkala_Najava_P2.Enabled = false;
                    break;
                case 183:
                    txtFull_Najava_P2.Enabled = false;
                    break;
                case 184:
                    txtPoker_Najava_P2.Enabled = false;
                    break;
                case 185:
                    txtJamb_Najava_P2.Enabled = false;
                    break;
                #endregion

                #region Kolona Odjava za Player 2
                case 186:
                    txtOdjava_01_P2.Enabled = false;
                    break;
                case 187:
                    txtOdjava_02_P2.Enabled = false;
                    break;
                case 188:
                    txtOdjava_03_P2.Enabled = false;
                    break;
                case 189:
                    txtOdjava_04_P2.Enabled = false;
                    break;
                case 190:
                    txtOdjava_05_P2.Enabled = false;
                    break;
                case 191:
                    txtOdjava_06_P2.Enabled = false;
                    break;
                case 192:
                    txtMax_Odjava_P2.Enabled = false;
                    break;
                case 193:
                    txtMin_Odjava_P2.Enabled = false;
                    break;
                case 194:
                    txtTriling_Odjava_P2.Enabled = false;
                    break;
                case 195:
                    txtSkala_Odjava_P2.Enabled = false;
                    break;
                case 196:
                    txtFull_Odjava_P2.Enabled = false;
                    break;
                case 197:
                    txtPoker_Odjava_P2.Enabled = false;
                    break;
                case 198:
                    txtJamb_Odjava_P2.Enabled = false;
                    break;
                #endregion

                #region Kolona Start1J za Player 2
                case 199:
                    txtStart1J_01_P2.Enabled = false;
                    txtStart1J_02_P2.Visible = true;
                    break;
                case 200:
                    txtStart1J_02_P2.Enabled = false;
                    txtStart1J_03_P2.Visible = true;
                    break;
                case 201:
                    txtStart1J_03_P2.Enabled = false;
                    txtStart1J_04_P2.Visible = true;
                    break;
                case 202:
                    txtStart1J_04_P2.Enabled = false;
                    txtStart1J_05_P2.Visible = true;
                    break;
                case 203:
                    txtStart1J_05_P2.Enabled = false;
                    txtStart1J_06_P2.Visible = true;
                    break;
                case 204:
                    txtStart1J_06_P2.Enabled = false;
                    txtMax_Start1J_P2.Visible = true;
                    break;
                case 205:
                    txtMax_Start1J_P2.Enabled = false;
                    break;
                case 206:
                    txtMin_Start1J_P2.Enabled = false;
                    break;
                case 207:
                    txtMin_Start1J_P2.Visible = true;
                    txtTriling_Start1J_P2.Enabled = false;
                    break;
                case 208:
                    txtTriling_Start1J_P2.Visible = true;
                    txtSkala_Start1J_P2.Enabled = false;
                    break;
                case 209:
                    txtSkala_Start1J_P2.Visible = true;
                    txtFull_Start1J_P2.Enabled = false;
                    break;
                case 210:
                    txtFull_Start1J_P2.Visible = true;
                    txtPoker_Start1J_P2.Enabled = false;
                    break;
                case 211:
                    txtPoker_Start1J_P2.Visible = true;
                    txtJamb_Start1J_P2.Enabled = false;
                    break;
                #endregion

                #region Kolona Racna za Player 2
                case 212:
                    txtRacna_01_P2.Enabled = false;
                    break;
                case 213:
                    txtRacna_02_P2.Enabled = false;
                    break;
                case 214:
                    txtRacna_03_P2.Enabled = false;
                    break;
                case 215:
                    txtRacna_04_P2.Enabled = false;
                    break;
                case 216:
                    txtRacna_05_P2.Enabled = false;
                    break;
                case 217:
                    txtRacna_06_P2.Enabled = false;
                    break;
                case 218:
                    txtMax_Racna_P2.Enabled = false;
                    break;
                case 219:
                    txtMin_Racna_P2.Enabled = false;
                    break;
                case 220:
                    txtTriling_Racna_P2.Enabled = false;
                    break;
                case 221:
                    txtSkala_Racna_P2.Enabled = false;
                    break;
                case 222:
                    txtFull_Racna_P2.Enabled = false;
                    break;
                case 223:
                    txtPoker_Racna_P2.Enabled = false;
                    break;
                case 224:
                    txtJamb_Racna_P2.Enabled = false;
                    break;
                #endregion

            }
        }

        public void TotalCalculate()
        {
            int SumColl1P1 = 0, SumColl2P1 = 0, SumColl3P1 = 0, SumColl4P1 = 0, SumColl5P1 = 0, SumColl6P1 = 0, SumColl7P1 = 0, SumColl8P1 = 0, SumColl1P2 = 0, SumColl2P2 = 0, SumColl3P2 = 0, SumColl4P2 = 0, SumColl5P2 = 0, SumColl6P2 = 0, SumColl7P2 = 0, SumColl8P2 = 0;

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

            txtZbir_01_Najava_P1.Text = (CalculateNumber(NotStr(txtNajava_01_P1.Text), NotStr(txtNajava_02_P1.Text), NotStr(txtNajava_03_P1.Text), NotStr(txtNajava_04_P1.Text), NotStr(txtNajava_05_P1.Text), NotStr(txtNajava_06_P1.Text), NotStr(txtMax_Najava_P1.Text), NotStr(txtMin_Najava_P1.Text))).ToString();
            txtZbir_02_Max_Min_Najava_P1.Text = (NotStr(txtMax_Najava_P1.Text) + NotStr(txtMin_Najava_P1.Text)).ToString();
            txtZbir_03_Najava_P1.Text = (NotStr(txtTriling_Najava_P1.Text) + NotStr(txtSkala_Najava_P1.Text) + NotStr(txtFull_Najava_P1.Text) + NotStr(txtPoker_Najava_P1.Text) + NotStr(txtJamb_Najava_P1.Text)).ToString();

            txtZbir_01_Odjava_P1.Text = (CalculateNumber(NotStr(txtOdjava_01_P1.Text), NotStr(txtOdjava_02_P1.Text), NotStr(txtOdjava_03_P1.Text), NotStr(txtOdjava_04_P1.Text), NotStr(txtOdjava_05_P1.Text), NotStr(txtOdjava_06_P1.Text), NotStr(txtMax_Odjava_P1.Text), NotStr(txtMin_Odjava_P1.Text))).ToString();
            txtZbir_02_Max_Min_Odjava_P1.Text = (NotStr(txtMax_Odjava_P1.Text) + NotStr(txtMin_Odjava_P1.Text)).ToString();
            txtZbir_03_Odjava_P1.Text = (NotStr(txtTriling_Odjava_P1.Text) + NotStr(txtSkala_Odjava_P1.Text) + NotStr(txtFull_Odjava_P1.Text) + NotStr(txtPoker_Odjava_P1.Text) + NotStr(txtJamb_Odjava_P1.Text)).ToString();

            txtZbir_01_Start1J_P1.Text = (CalculateNumber(NotStr(txtStart1J_01_P1.Text), NotStr(txtStart1J_02_P1.Text), NotStr(txtStart1J_03_P1.Text), NotStr(txtStart1J_04_P1.Text), NotStr(txtStart1J_05_P1.Text), NotStr(txtStart1J_06_P1.Text), NotStr(txtMax_Start1J_P1.Text), NotStr(txtMin_Start1J_P1.Text))).ToString();
            txtZbir_02_Max_Min_Start1J_P1.Text = (NotStr(txtMax_Start1J_P1.Text) + NotStr(txtMin_Start1J_P1.Text)).ToString();
            txtZbir_03_Start1J_P1.Text = (NotStr(txtTriling_Start1J_P1.Text) + NotStr(txtSkala_Start1J_P1.Text) + NotStr(txtFull_Start1J_P1.Text) + NotStr(txtPoker_Start1J_P1.Text) + NotStr(txtJamb_Start1J_P1.Text)).ToString();

            txtZbir_01_Racna_P1.Text = (CalculateNumber(NotStr(txtRacna_01_P1.Text), NotStr(txtRacna_02_P1.Text), NotStr(txtRacna_03_P1.Text), NotStr(txtRacna_04_P1.Text), NotStr(txtRacna_05_P1.Text), NotStr(txtRacna_06_P1.Text), NotStr(txtMax_Racna_P1.Text), NotStr(txtMin_Racna_P1.Text))).ToString();
            txtZbir_02_Max_Min_Racna_P1.Text = (NotStr(txtMax_Racna_P1.Text) + NotStr(txtMin_Racna_P1.Text)).ToString();
            txtZbir_03_Racna_P1.Text = (NotStr(txtTriling_Racna_P1.Text) + NotStr(txtSkala_Racna_P1.Text) + NotStr(txtFull_Racna_P1.Text) + NotStr(txtPoker_Racna_P1.Text) + NotStr(txtJamb_Racna_P1.Text)).ToString();

            SumColl1P1 = (CalculateSumaColl(NotStr(txtZbir_01_Nadolu_P1.Text), NotStr(txtZbir_02_Max_Min_Nadolu_P1.Text), NotStr(txtZbir_03_Nadolu_P1.Text)));
            SumColl2P1 = (CalculateSumaColl(NotStr(txtZbir_01_Slobodna_P1.Text), NotStr(txtZbir_02_Max_Min_Slobodna_P1.Text), NotStr(txtZbir_03_Slobodna_P1.Text)));
            SumColl3P1 = (CalculateSumaColl(NotStr(txtZbir_01_Nagore_P1.Text), NotStr(txtZbir_02_Max_Min_Nagore_P1.Text), NotStr(txtZbir_03_Nagore_P1.Text)));
            SumColl4P1 = (CalculateSumaColl(NotStr(txtZbir_01_StartMinMax_P1.Text), NotStr(txtZbir_02_Max_Min_StartMinMax_P1.Text), NotStr(txtZbir_03_StartMinMax_P1.Text)));
            SumColl5P1 = (CalculateSumaColl(NotStr(txtZbir_01_Najava_P1.Text), NotStr(txtZbir_02_Max_Min_Najava_P1.Text), NotStr(txtZbir_03_Najava_P1.Text)));
            SumColl6P1 = (CalculateSumaColl(NotStr(txtZbir_01_Odjava_P1.Text), NotStr(txtZbir_02_Max_Min_Odjava_P1.Text), NotStr(txtZbir_03_Odjava_P1.Text)));
            SumColl7P1 = (CalculateSumaColl(NotStr(txtZbir_01_Start1J_P1.Text), NotStr(txtZbir_02_Max_Min_Start1J_P1.Text), NotStr(txtZbir_03_Start1J_P1.Text)));
            SumColl8P1 = (CalculateSumaColl(NotStr(txtZbir_01_Racna_P1.Text), NotStr(txtZbir_02_Max_Min_Racna_P1.Text), NotStr(txtZbir_03_Racna_P1.Text)));

            lblRezP1.Text = (SumColl1P1 + SumColl2P1 + SumColl3P1 + SumColl4P1 + SumColl5P1 + SumColl6P1 + SumColl7P1 + SumColl8P1).ToString();
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


            txtZbir_01_Najava_P2.Text = (CalculateNumber(NotStr(txtNajava_01_P2.Text), NotStr(txtNajava_02_P2.Text), NotStr(txtNajava_03_P2.Text), NotStr(txtNajava_04_P2.Text), NotStr(txtNajava_05_P2.Text), NotStr(txtNajava_06_P2.Text), NotStr(txtMax_Najava_P2.Text), NotStr(txtMin_Najava_P2.Text))).ToString();
            txtZbir_02_Max_Min_Najava_P2.Text = (NotStr(txtMax_Najava_P2.Text) + NotStr(txtMin_Najava_P2.Text)).ToString();
            txtZbir_03_Najava_P2.Text = (NotStr(txtTriling_Najava_P2.Text) + NotStr(txtSkala_Najava_P2.Text) + NotStr(txtFull_Najava_P2.Text) + NotStr(txtPoker_Najava_P2.Text) + NotStr(txtJamb_Najava_P2.Text)).ToString();

            txtZbir_01_Odjava_P2.Text = (CalculateNumber(NotStr(txtOdjava_01_P2.Text), NotStr(txtOdjava_02_P2.Text), NotStr(txtOdjava_03_P2.Text), NotStr(txtOdjava_04_P2.Text), NotStr(txtOdjava_05_P2.Text), NotStr(txtOdjava_06_P2.Text), NotStr(txtMax_Odjava_P2.Text), NotStr(txtMin_Odjava_P2.Text))).ToString();
            txtZbir_02_Max_Min_Odjava_P2.Text = (NotStr(txtMax_Odjava_P2.Text) + NotStr(txtMin_Odjava_P2.Text)).ToString();
            txtZbir_03_Odjava_P2.Text = (NotStr(txtTriling_Odjava_P2.Text) + NotStr(txtSkala_Odjava_P2.Text) + NotStr(txtFull_Odjava_P2.Text) + NotStr(txtPoker_Odjava_P2.Text) + NotStr(txtJamb_Odjava_P2.Text)).ToString();

            txtZbir_01_Start1J_P2.Text = (CalculateNumber(NotStr(txtStart1J_01_P2.Text), NotStr(txtStart1J_02_P2.Text), NotStr(txtStart1J_03_P2.Text), NotStr(txtStart1J_04_P2.Text), NotStr(txtStart1J_05_P2.Text), NotStr(txtStart1J_06_P2.Text), NotStr(txtMax_Start1J_P2.Text), NotStr(txtMin_Start1J_P2.Text))).ToString();
            txtZbir_02_Max_Min_Start1J_P2.Text = (NotStr(txtMax_Start1J_P2.Text) + NotStr(txtMin_Start1J_P2.Text)).ToString();
            txtZbir_03_Start1J_P2.Text = (NotStr(txtTriling_Start1J_P2.Text) + NotStr(txtSkala_Start1J_P2.Text) + NotStr(txtFull_Start1J_P2.Text) + NotStr(txtPoker_Start1J_P2.Text) + NotStr(txtJamb_Start1J_P2.Text)).ToString();

            txtZbir_01_Racna_P2.Text = (CalculateNumber(NotStr(txtRacna_01_P2.Text), NotStr(txtRacna_02_P2.Text), NotStr(txtRacna_03_P2.Text), NotStr(txtRacna_04_P2.Text), NotStr(txtRacna_05_P2.Text), NotStr(txtRacna_06_P2.Text), NotStr(txtMax_Racna_P2.Text), NotStr(txtMin_Racna_P2.Text))).ToString();
            txtZbir_02_Max_Min_Racna_P2.Text = (NotStr(txtMax_Racna_P2.Text) + NotStr(txtMin_Racna_P2.Text)).ToString();
            txtZbir_03_Racna_P2.Text = (NotStr(txtTriling_Racna_P2.Text) + NotStr(txtSkala_Racna_P2.Text) + NotStr(txtFull_Racna_P2.Text) + NotStr(txtPoker_Racna_P2.Text) + NotStr(txtJamb_Racna_P2.Text)).ToString();

            SumColl1P2 = (CalculateSumaColl(NotStr(txtZbir_01_Nadolu_P2.Text), NotStr(txtZbir_02_Max_Min_Nadolu_P2.Text), NotStr(txtZbir_03_Nadolu_P2.Text)));
            SumColl2P2 = (CalculateSumaColl(NotStr(txtZbir_01_Slobodna_P2.Text), NotStr(txtZbir_02_Max_Min_Slobodna_P2.Text), NotStr(txtZbir_03_Slobodna_P2.Text)));
            SumColl3P2 = (CalculateSumaColl(NotStr(txtZbir_01_Nagore_P2.Text), NotStr(txtZbir_02_Max_Min_Nagore_P2.Text), NotStr(txtZbir_03_Nagore_P2.Text)));
            SumColl4P2 = (CalculateSumaColl(NotStr(txtZbir_01_StartMinMax_P2.Text), NotStr(txtZbir_02_Max_Min_StartMinMax_P2.Text), NotStr(txtZbir_03_StartMinMax_P2.Text)));
            SumColl5P2 = (CalculateSumaColl(NotStr(txtZbir_01_Najava_P2.Text), NotStr(txtZbir_02_Max_Min_Najava_P2.Text), NotStr(txtZbir_03_Najava_P2.Text)));
            SumColl6P2 = (CalculateSumaColl(NotStr(txtZbir_01_Odjava_P2.Text), NotStr(txtZbir_02_Max_Min_Odjava_P2.Text), NotStr(txtZbir_03_Odjava_P2.Text)));
            SumColl7P2 = (CalculateSumaColl(NotStr(txtZbir_01_Start1J_P2.Text), NotStr(txtZbir_02_Max_Min_Start1J_P2.Text), NotStr(txtZbir_03_Start1J_P2.Text)));
            SumColl8P2 = (CalculateSumaColl(NotStr(txtZbir_01_Racna_P2.Text), NotStr(txtZbir_02_Max_Min_Racna_P2.Text), NotStr(txtZbir_03_Racna_P2.Text)));

            lblRezP2.Text = (SumColl1P2 + SumColl2P2 + SumColl3P2 + SumColl4P2 + SumColl5P2 + SumColl6P2 + SumColl7P2 + SumColl8P2).ToString();
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
            txtNagore_01_P1.Clear();
        }

        private void txtNagore_02_P1_Leave(object sender, EventArgs e)
        {
            txtNagore_02_P1.Clear();
        }

        private void txtNagore_03_P1_Leave(object sender, EventArgs e)
        {
            txtNagore_03_P1.Clear();
        }

        private void txtNagore_04_P1_Leave(object sender, EventArgs e)
        {
            txtNagore_04_P1.Clear();
        }

        private void txtNagore_05_P1_Leave(object sender, EventArgs e)
        {
            txtNagore_05_P1.Clear();
        }

        private void txtNagore_06_P1_Leave(object sender, EventArgs e)
        {
            txtNagore_06_P1.Clear();
        }

        private void txtMax_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Nagore_P1.Clear();
        }

        private void txtMin_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Nagore_P1.Clear();
        }

        private void txtTriling_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Nagore_P1.Clear();
        }

        private void txtSkala_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Nagore_P1.Clear();
        }

        private void txtFull_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Nagore_P1.Clear();
        }

        private void txtPoker_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Nagore_P1.Clear();
        }

        private void txtJamb_Nagore_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_Nagore_P1.Clear();
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

        #region Textbox Event Najava za Player 1
        private void txtNajava_01_P1_Click(object sender, EventArgs e)
        {
            here = txtNajava_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtNajava_02_P1_Click(object sender, EventArgs e)
        {
            here = txtNajava_02_P1.TabIndex;
            GetContent(here);
        }

        private void txtNajava_03_P1_Click(object sender, EventArgs e)
        {
            here = txtNajava_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtNajava_04_P1_Click(object sender, EventArgs e)
        {
            here = txtNajava_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtNajava_05_P1_Click(object sender, EventArgs e)
        {
            here = txtNajava_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtNajava_06_P1_Click(object sender, EventArgs e)
        {
            here = txtNajava_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Najava_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Najava_P1.TabIndex;
            GetContent(here);
        }

        private void txtNajava_01_P1_Leave(object sender, EventArgs e)
        {
            txtNajava_01_P1.Clear();
        }

        private void txtNajava_02_P1_Leave(object sender, EventArgs e)
        {
            txtNajava_02_P1.Clear();
        }

        private void txtNajava_03_P1_Leave(object sender, EventArgs e)
        {
            txtNajava_03_P1.Clear();
        }

        private void txtNajava_04_P1_Leave(object sender, EventArgs e)
        {
            txtNajava_04_P1.Clear();
        }

        private void txtNajava_05_P1_Leave(object sender, EventArgs e)
        {
            txtNajava_05_P1.Clear();
        }

        private void txtNajava_06_P1_Leave(object sender, EventArgs e)
        {
            txtNajava_06_P1.Clear();
        }

        private void txtMax_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Najava_P1.Clear();
        }

        private void txtMin_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Najava_P1.Clear();
        }

        private void txtTriling_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Najava_P1.Clear();
        }

        private void txtSkala_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Najava_P1.Clear();
        }

        private void txtFull_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Najava_P1.Clear();
        }

        private void txtPoker_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Najava_P1.Clear();
        }

        private void txtJamb_Najava_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_Najava_P1.Clear();
        }
        #endregion

        #region Textbox Event Odjava Event za Player 1
        private void txtOdjava_01_P1_Click(object sender, EventArgs e)
        {
            here = txtOdjava_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_02_P1_Click(object sender, EventArgs e)
        {
            here = txtOdjava_02_P1.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_03_P1_Click(object sender, EventArgs e)
        {
            here = txtOdjava_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_04_P1_Click(object sender, EventArgs e)
        {
            here = txtOdjava_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_05_P1_Click(object sender, EventArgs e)
        {
            here = txtOdjava_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_06_P1_Click(object sender, EventArgs e)
        {
            here = txtOdjava_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Odjava_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Odjava_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_Odjava_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Odjava_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Odjava_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Odjava_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Odjava_P1.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_01_P1_Leave(object sender, EventArgs e)
        {
            txtOdjava_01_P1.Clear();
        }

        private void txtOdjava_02_P1_Leave(object sender, EventArgs e)
        {
            txtOdjava_02_P1.Clear();
        }

        private void txtOdjava_03_P1_Leave(object sender, EventArgs e)
        {
            txtOdjava_03_P1.Clear();
        }

        private void txtOdjava_04_P1_Leave(object sender, EventArgs e)
        {
            txtOdjava_04_P1.Clear();
        }

        private void txtOdjava_05_P1_Leave(object sender, EventArgs e)
        {
            txtOdjava_05_P1.Clear();
        }

        private void txtOdjava_06_P1_Leave(object sender, EventArgs e)
        {
            txtOdjava_06_P1.Clear();
        }

        private void txtMax_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Odjava_P1.Clear();
        }

        private void txtMin_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Odjava_P1.Clear();
        }

        private void txtTriling_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Odjava_P1.Clear();
        }

        private void txtSkala_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Odjava_P1.Clear();
        }

        private void txtFull_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Odjava_P1.Clear();
        }

        private void txtPoker_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Odjava_P1.Clear();
        }

        private void txtJamb_Odjava_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_Odjava_P1.Clear();
        }
        #endregion

        #region Textbox Event Start 1J Event za Player 1
        private void txtStart1J_01_P1_Click(object sender, EventArgs e)
        {
            here = txtStart1J_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_02_P1_Click(object sender, EventArgs e)
        {
            here = txtStart1J_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_03_P1_Click(object sender, EventArgs e)
        {
            here = txtStart1J_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_04_P1_Click(object sender, EventArgs e)
        {
            here = txtStart1J_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_05_P1_Click(object sender, EventArgs e)
        {
            here = txtStart1J_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_06_P1_Click(object sender, EventArgs e)
        {
            here = txtStart1J_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtSkala_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Start1J_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Start1J_P1.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_01_P1_Leave(object sender, EventArgs e)
        {
            txtStart1J_01_P1.Clear();
        }

        private void txtStart1J_02_P1_Leave(object sender, EventArgs e)
        {
            txtStart1J_01_P2.Clear();
        }

        private void txtStart1J_03_P1_Leave(object sender, EventArgs e)
        {
            txtStart1J_03_P1.Clear();
        }

        private void txtStart1J_04_P1_Leave(object sender, EventArgs e)
        {
            txtStart1J_04_P1.Clear();
        }

        private void txtStart1J_05_P1_Leave(object sender, EventArgs e)
        {
            txtStart1J_05_P1.Clear();
        }

        private void txtStart1J_06_P1_Leave(object sender, EventArgs e)
        {
            txtStart1J_06_P1.Clear();
        }

        private void txtMax_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Start1J_P1.Clear();
        }

        private void txtMin_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Start1J_P1.Clear();
        }

        private void txtTriling_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Start1J_P1.Clear();
        }

        private void txtSkala_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Start1J_P1.Clear();
        }

        private void txtFull_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Start1J_P1.Clear();
        }

        private void txtPoker_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Start1J_P1.Clear();
        }

        private void txtJamb_Start1J_P1_Leave(object sender, EventArgs e)
        {
            txtJamb_Start1J_P1.Clear();
        }
        #endregion

        #region Textbox Event Racna za Player 1
        private void txtRacna_01_P1_Click(object sender, EventArgs e)
        {
            here = txtRacna_01_P1.TabIndex;
            GetContent(here);
        }

        private void txtRacna_02_P1_Click(object sender, EventArgs e)
        {
            here = txtRacna_02_P1.TabIndex;
            GetContent(here);
        }

        private void txtRacna_03_P1_Click(object sender, EventArgs e)
        {
            here = txtRacna_03_P1.TabIndex;
            GetContent(here);
        }

        private void txtRacna_04_P1_Click(object sender, EventArgs e)
        {
            here = txtRacna_04_P1.TabIndex;
            GetContent(here);
        }

        private void txtRacna_05_P1_Click(object sender, EventArgs e)
        {
            here = txtRacna_05_P1.TabIndex;
            GetContent(here);
        }

        private void txtRacna_06_P1_Click(object sender, EventArgs e)
        {
            here = txtRacna_06_P1.TabIndex;
            GetContent(here);
        }

        private void txtMax_Racna_P1_Click(object sender, EventArgs e)
        {
            here = txtMax_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtMin_Racna_P1_Click(object sender, EventArgs e)
        {
            here = txtMin_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Racna_P1_Click(object sender, EventArgs e)
        {
            here = txtTriling_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Racna_P1_Enter(object sender, EventArgs e)
        {
            here = txtSkala_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtFull_Racna_P1_Click(object sender, EventArgs e)
        {
            here = txtFull_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Racna_P1_Click(object sender, EventArgs e)
        {
            here = txtPoker_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Racna_P1_Click(object sender, EventArgs e)
        {
            here = txtJamb_Racna_P1.TabIndex;
            GetContent(here);
        }

        private void txtRacna_01_P1_Leave(object sender, EventArgs e)
        {
            txtRacna_01_P1.Clear();
        }

        private void txtRacna_02_P1_Leave(object sender, EventArgs e)
        {
            txtRacna_02_P1.Clear();
        }

        private void txtRacna_03_P1_Leave(object sender, EventArgs e)
        {
            txtRacna_03_P1.Clear();
        }

        private void txtRacna_04_P1_Leave(object sender, EventArgs e)
        {
            txtRacna_04_P1.Clear();
        }

        private void txtRacna_05_P1_Leave(object sender, EventArgs e)
        {
            txtRacna_05_P1.Clear();
        }

        private void txtRacna_06_P1_Leave(object sender, EventArgs e)
        {
            txtRacna_06_P1.Clear();
        }

        private void txtMax_Racna_P1_Leave(object sender, EventArgs e)
        {
            txtMax_Racna_P1.Clear();
        }

        private void txtMin_Racna_P1_Leave(object sender, EventArgs e)
        {
            txtMin_Racna_P1.Clear();
        }

        private void txtTriling_Racna_P1_Leave(object sender, EventArgs e)
        {
            txtTriling_Racna_P1.Clear();
        }

        private void txtSkala_Racna_P1_Leave(object sender, EventArgs e)
        {
            txtSkala_Racna_P1.Clear();
        }

        private void txtFull_Racna_P1_Leave(object sender, EventArgs e)
        {
            txtFull_Racna_P1.Clear();
        }

        private void txtPoker_Racna_P1_Leave(object sender, EventArgs e)
        {
            txtPoker_Racna_P1.Clear();
        }

        private void txtJamb_Racna_P1_Leave(object sender, EventArgs e)
        {

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

        #region Textbox Event Najava za Player 2
        private void txtNajava_01_P2_Click(object sender, EventArgs e)
        {
            here = txtNajava_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtNajava_02_P2_Click(object sender, EventArgs e)
        {
            here = txtNajava_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtNajava_03_P2_Click(object sender, EventArgs e)
        {
            here = txtNajava_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtNajava_04_P2_Click(object sender, EventArgs e)
        {
            here = txtNajava_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtNajava_05_P2_Click(object sender, EventArgs e)
        {
            here = txtNajava_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtNajava_06_P2_Click(object sender, EventArgs e)
        {
            here = txtNajava_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Najava_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Najava_P2.TabIndex;
            GetContent(here);
        }

        private void txtNajava_01_P2_Leave(object sender, EventArgs e)
        {
            txtNajava_01_P2.Clear();
        }

        private void txtNajava_02_P2_Leave(object sender, EventArgs e)
        {
            txtNajava_02_P2.Clear();
        }

        private void txtNajava_03_P2_Leave(object sender, EventArgs e)
        {
            txtNajava_03_P2.Clear();
        }

        private void txtNajava_04_P2_Leave(object sender, EventArgs e)
        {
            txtNajava_04_P2.Clear();
        }

        private void txtNajava_05_P2_Leave(object sender, EventArgs e)
        {
            txtNajava_05_P2.Clear();
        }

        private void txtNajava_06_P2_Leave(object sender, EventArgs e)
        {
            txtNajava_06_P2.Clear();
        }

        private void txtMax_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Najava_P2.Clear();
        }

        private void txtMin_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Najava_P2.Clear();
        }

        private void txtTriling_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Najava_P2.Clear();
        }

        private void txtSkala_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Najava_P2.Clear();
        }

        private void txtFull_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Najava_P2.Clear();
        }

        private void txtPoker_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Najava_P2.Clear();
        }

        private void txtJamb_Najava_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Najava_P2.Clear();
        }
        #endregion

        #region Textbox Event Odjava za Player 2
        private void txtOdjava_01_P2_Click(object sender, EventArgs e)
        {
            here = txtOdjava_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_02_P2_Click(object sender, EventArgs e)
        {
            here = txtOdjava_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_03_P2_Click(object sender, EventArgs e)
        {
            here = txtOdjava_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_04_P2_Click(object sender, EventArgs e)
        {
            here = txtOdjava_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_05_P2_Click(object sender, EventArgs e)
        {
            here = txtOdjava_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_06_P2_Click(object sender, EventArgs e)
        {
            here = txtOdjava_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtStartMinMax_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Odjava_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Odjava_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Odjava_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Odjava_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Odjava_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Odjava_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Odjava_P2.TabIndex;
            GetContent(here);
        }

        private void txtOdjava_01_P2_Leave(object sender, EventArgs e)
        {
            txtOdjava_01_P2.Clear();
        }

        private void txtOdjava_02_P2_Leave(object sender, EventArgs e)
        {
            txtOdjava_02_P2.Clear();
        }

        private void txtOdjava_03_P2_Leave(object sender, EventArgs e)
        {
            txtOdjava_03_P2.Clear();
        }

        private void txtOdjava_04_P2_Leave(object sender, EventArgs e)
        {
            txtOdjava_04_P2.Clear();
        }

        private void txtOdjava_05_P2_Leave(object sender, EventArgs e)
        {
            txtOdjava_05_P2.Clear();
        }

        private void txtOdjava_06_P2_Leave(object sender, EventArgs e)
        {
            txtOdjava_06_P2.Clear();
        }

        private void txtMax_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Odjava_P2.Clear();
        }

        private void txtMin_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Odjava_P2.Clear();
        }

        private void txtTriling_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Odjava_P2.Clear();
        }

        private void txtSkala_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Odjava_P2.Clear();
        }

        private void txtFull_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Odjava_P2.Clear();
        }

        private void txtPoker_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Odjava_P2.Clear();
        }

        private void txtJamb_Odjava_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Odjava_P2.Clear();
        }

        #endregion
        
        #region Textbox Event Start 1J Event za Player 2
        private void txtStart1J_01_P2_Click(object sender, EventArgs e)
        {
            here = txtStart1J_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_02_P2_Click(object sender, EventArgs e)
        {
            here = txtStart1J_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_03_P2_Click(object sender, EventArgs e)
        {
            here = txtStart1J_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_04_P2_Click(object sender, EventArgs e)
        {
            here = txtStart1J_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_05_P2_Click(object sender, EventArgs e)
        {
            here = txtStart1J_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_06_P2_Click(object sender, EventArgs e)
        {
            here = txtStart1J_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Start1J_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Start1J_P2.TabIndex;
            GetContent(here);
        }

        private void txtStart1J_01_P2_Leave(object sender, EventArgs e)
        {
            txtStart1J_01_P2.Clear();
        }

        private void txtStart1J_02_P2_Leave(object sender, EventArgs e)
        {
            txtStart1J_01_P2.Clear();
        }

        private void txtStart1J_03_P2_Leave(object sender, EventArgs e)
        {
            txtStart1J_03_P2.Clear();
        }

        private void txtStart1J_04_P2_Leave(object sender, EventArgs e)
        {
            txtStart1J_04_P2.Clear();
        }

        private void txtStart1J_05_P2_Leave(object sender, EventArgs e)
        {
            txtStart1J_05_P2.Clear();
        }

        private void txtStart1J_06_P2_Leave(object sender, EventArgs e)
        {
            txtStart1J_06_P2.Clear();
        }

        private void txtMax_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Start1J_P2.Clear();
        }

        private void txtMin_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Start1J_P2.Clear();
        }

        private void txtTriling_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Start1J_P2.Clear();
        }

        private void txtSkala_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Start1J_P2.Clear();
        }

        private void txtFull_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Start1J_P2.Clear();
        }

        private void txtPoker_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Start1J_P2.Clear();
        }

        private void txtJamb_Start1J_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Start1J_P2.Clear();
        }
        #endregion

        #region Textbox Event Racna za Player 2
        private void txtRacna_01_P2_Click(object sender, EventArgs e)
        {
            here = txtRacna_01_P2.TabIndex;
            GetContent(here);
        }

        private void txtRacna_02_P2_Click(object sender, EventArgs e)
        {
            here = txtRacna_02_P2.TabIndex;
            GetContent(here);
        }

        private void txtRacna_03_P2_Click(object sender, EventArgs e)
        {
            here = txtRacna_03_P2.TabIndex;
            GetContent(here);
        }

        private void txtRacna_04_P2_Click(object sender, EventArgs e)
        {
            here = txtRacna_04_P2.TabIndex;
            GetContent(here);
        }

        private void txtRacna_05_P2_Click(object sender, EventArgs e)
        {
            here = txtRacna_05_P2.TabIndex;
            GetContent(here);
        }

        private void txtRacna_06_P2_Click(object sender, EventArgs e)
        {
            here = txtRacna_06_P2.TabIndex;
            GetContent(here);
        }

        private void txtMax_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtMax_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtMin_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtMin_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtTriling_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtTriling_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtSkala_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtSkala_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtFull_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtFull_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtPoker_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtPoker_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtJamb_Racna_P2_Click(object sender, EventArgs e)
        {
            here = txtJamb_Racna_P2.TabIndex;
            GetContent(here);
        }

        private void txtRacna_01_P2_Leave(object sender, EventArgs e)
        {
            txtRacna_01_P2.Clear();
        }

        private void txtRacna_02_P2_Leave(object sender, EventArgs e)
        {
            txtRacna_02_P2.Clear();
        }

        private void txtRacna_03_P2_Leave(object sender, EventArgs e)
        {
            txtRacna_03_P2.Clear();
        }

        private void txtRacna_04_P2_Leave(object sender, EventArgs e)
        {
            txtRacna_04_P2.Clear();
        }

        private void txtRacna_05_P2_Leave(object sender, EventArgs e)
        {
            txtRacna_05_P2.Clear();
        }

        private void txtRacna_06_P2_Leave(object sender, EventArgs e)
        {
            txtRacna_06_P2.Clear();
        }

        private void txtMax_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtMax_Racna_P2.Clear();
        }

        private void txtMin_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtMin_Racna_P2.Clear();
        }

        private void txtTriling_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtTriling_Racna_P2.Clear();
        }

        private void txtSkala_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtSkala_Racna_P2.Clear();
        }

        private void txtFull_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtFull_Racna_P2.Clear();
        }

        private void txtPoker_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtPoker_Racna_P2.Clear();
        }

        private void txtJamb_Racna_P2_Leave(object sender, EventArgs e)
        {
            txtJamb_Racna_P2.Clear();
        }
        #endregion
        
        #endregion END za PLAYER 2
        

        public void SetNajavaEnableP1()
        {
            txtNajava_01_P1.Enabled = NajavaP1[1];
            txtNajava_02_P1.Enabled = NajavaP1[2];
            txtNajava_03_P1.Enabled = NajavaP1[3];
            txtNajava_04_P1.Enabled = NajavaP1[4];
            txtNajava_05_P1.Enabled = NajavaP1[5];
            txtNajava_06_P1.Enabled = NajavaP1[6];
            txtMax_Najava_P1.Enabled = NajavaP1[7];
            txtMin_Najava_P1.Enabled = NajavaP1[8];
            txtTriling_Najava_P1.Enabled = NajavaP1[9];
            txtSkala_Najava_P1.Enabled = NajavaP1[10];
            txtFull_Najava_P1.Enabled = NajavaP1[11];
            txtPoker_Najava_P1.Enabled = NajavaP1[12];
            txtJamb_Najava_P1.Enabled = NajavaP1[13];
        }

        public void SetOdjavaEnableP1()
        {
            txtOdjava_01_P1.Enabled = OdjavaP1[1];
            txtOdjava_02_P1.Enabled = OdjavaP1[2];
            txtOdjava_03_P1.Enabled = OdjavaP1[3];
            txtOdjava_04_P1.Enabled = OdjavaP1[4];
            txtOdjava_05_P1.Enabled = OdjavaP1[5];
            txtOdjava_06_P1.Enabled = OdjavaP1[6];
            txtMax_Odjava_P1.Enabled = OdjavaP1[7];
            txtMin_Odjava_P1.Enabled = OdjavaP1[8];
            txtTriling_Odjava_P1.Enabled = OdjavaP1[9];
            txtSkala_Odjava_P1.Enabled = OdjavaP1[10];
            txtFull_Odjava_P1.Enabled = OdjavaP1[11];
            txtPoker_Odjava_P1.Enabled = OdjavaP1[12];
            txtJamb_Odjava_P1.Enabled = OdjavaP1[13];
        }

        public void SetNajavaEnableP2()
        {
            txtNajava_01_P2.Enabled = NajavaP2[1];
            txtNajava_02_P2.Enabled = NajavaP2[2];
            txtNajava_03_P2.Enabled = NajavaP2[3];
            txtNajava_04_P2.Enabled = NajavaP2[4];
            txtNajava_05_P2.Enabled = NajavaP2[5];
            txtNajava_06_P2.Enabled = NajavaP2[6];
            txtMax_Najava_P2.Enabled = NajavaP2[7];
            txtMin_Najava_P2.Enabled = NajavaP2[8];
            txtTriling_Najava_P2.Enabled = NajavaP2[9];
            txtSkala_Najava_P2.Enabled = NajavaP2[10];
            txtFull_Najava_P2.Enabled = NajavaP2[11];
            txtPoker_Najava_P2.Enabled = NajavaP2[12];
            txtJamb_Najava_P2.Enabled = NajavaP2[13];
        }

        public void SetOdjavaEnableP2()
        {
            txtOdjava_01_P2.Enabled = OdjavaP2[1];
            txtOdjava_02_P2.Enabled = OdjavaP2[2];
            txtOdjava_03_P2.Enabled = OdjavaP2[3];
            txtOdjava_04_P2.Enabled = OdjavaP2[4];
            txtOdjava_05_P2.Enabled = OdjavaP2[5];
            txtOdjava_06_P2.Enabled = OdjavaP2[6];
            txtMax_Odjava_P2.Enabled = OdjavaP2[7];
            txtMin_Odjava_P2.Enabled = OdjavaP2[8];
            txtTriling_Odjava_P2.Enabled = OdjavaP2[9];
            txtSkala_Odjava_P2.Enabled = OdjavaP2[10];
            txtFull_Odjava_P2.Enabled = OdjavaP2[11];
            txtPoker_Odjava_P2.Enabled = OdjavaP2[12];
            txtJamb_Odjava_P2.Enabled = OdjavaP2[13];
        }

        public void ResetO()
        {
            for (int i = 0; i < OdjavaP1.Length; i++)
                OdjavaP1[i] = false;

            for (int i = 0; i < OdjavaP2.Length; i++)
                OdjavaP2[i] = false;

        }

        public void SetRacnaEnableP1()
        {
            txtRacna_01_P1.Enabled = RacnaP1[1];
            txtRacna_02_P1.Enabled = RacnaP1[2];
            txtRacna_03_P1.Enabled = RacnaP1[3];
            txtRacna_04_P1.Enabled = RacnaP1[4];
            txtRacna_05_P1.Enabled = RacnaP1[5];
            txtRacna_06_P1.Enabled = RacnaP1[6];
            txtMax_Racna_P1.Enabled = RacnaP1[7];
            txtMin_Racna_P1.Enabled = RacnaP1[8];
            txtTriling_Racna_P1.Enabled = RacnaP1[9];
            txtSkala_Racna_P1.Enabled = RacnaP1[10];
            txtFull_Racna_P1.Enabled = RacnaP1[11];
            txtPoker_Racna_P1.Enabled = RacnaP1[12];
            txtJamb_Racna_P1.Enabled = RacnaP1[13];
        }

        public void SetRacnaEnableP2()
        {
            txtRacna_01_P2.Enabled = RacnaP2[1];
            txtRacna_02_P2.Enabled = RacnaP2[2];
            txtRacna_03_P2.Enabled = RacnaP2[3];
            txtRacna_04_P2.Enabled = RacnaP2[4];
            txtRacna_05_P2.Enabled = RacnaP2[5];
            txtRacna_06_P2.Enabled = RacnaP2[6];
            txtMax_Racna_P2.Enabled = RacnaP2[7];
            txtMin_Racna_P2.Enabled = RacnaP2[8];
            txtTriling_Racna_P2.Enabled = RacnaP2[9];
            txtSkala_Racna_P2.Enabled = RacnaP2[10];
            txtFull_Racna_P2.Enabled = RacnaP2[11];
            txtPoker_Racna_P2.Enabled = RacnaP2[12];
            txtJamb_Racna_P2.Enabled = RacnaP2[13];
        }


        private void cbNajava_P1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNajava_P1.SelectedIndex != 0)
            {
                najava1 = true;
                odjava2 = true;
                NajavaP1[lNajavaP1[cbNajava_P1.SelectedIndex].Value] = true;

                gbMod1_P1.Enabled = false;
                gbMod2_P1.Enabled = false;
                gbMod3_P1.Enabled = false;

                for (int i = 0; i < NajavaP1.Length; i++)
                {
                    if (i != lNajavaP1[cbNajava_P1.SelectedIndex].Value)
                        NajavaP1[i] = false;

                }
                SetNajavaEnableP1();
                SetOdjavaEnableP2();
            }
            else if (cbNajava_P1.SelectedIndex == 0)
            {
                gbMod1_P1.Enabled = true;
                gbMod2_P1.Enabled = true;
                gbMod3_P1.Enabled = true;

                for (int i = 0; i < NajavaP1.Length; i++)
                    NajavaP1[i] = false;

                for (int i = 0; i < OdjavaP2.Length; i++)
                    OdjavaP2[i] = false;

                SetNajavaEnableP1();
                najava1 = false;
                odjava2 = false;
            }

        }

        private void cbNajava_P2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNajava_P2.SelectedIndex != 0)
            {
                najava2 = true;
                odjava1 = true;
                NajavaP2[lNajavaP2[cbNajava_P2.SelectedIndex].Value] = true;

                gbMod1_P2.Enabled = false;
                gbMod2_P2.Enabled = false;
                gbMod3_P2.Enabled = false;

                for (int i = 0; i < NajavaP2.Length; i++)
                {
                    if (i != lNajavaP2[cbNajava_P2.SelectedIndex].Value)
                        NajavaP2[i] = false;

                }
                SetNajavaEnableP2();

            }
            else if (cbNajava_P2.SelectedIndex == 0)
            {
                for (int i = 0; i < NajavaP2.Length; i++)
                    NajavaP2[i] = false;

                for (int i = 0; i < OdjavaP1.Length; i++)
                    OdjavaP1[i] = false;

                SetNajavaEnableP2();
                SetOdjavaEnableP1();
                najava2 = false;
                odjava1 = false;
                gbMod1_P2.Enabled = true;
                gbMod2_P2.Enabled = true;
                gbMod3_P2.Enabled = true;
            }
        }

        

                
    }
}
