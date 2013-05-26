using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jamb
{
    public class Player
    {
        List<Dice> dice;
        int[] diceResult;
        static Random rnd;
        string name;
        int numPlayer;
        int sumaMax = 0, sumaMin = 0;
        int rollTurns;
        public int max = 0;
        string youHave, rDice = string.Empty;
        public int FullHouse = 0, Triling = 0, FullMax = 0, TriMax = 0;
        int gameTurns;
        bool finished;
        int score;
        List<Znak> znak;
        

        public Player()
        {
            name = " ";
            finished = false;
            dice = new List<Dice>();
            diceResult = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            rnd = new Random();
            rollTurns = 1;
            znak = new List<Znak>();
            for (int i = 0; i < 14; i++)
                znak.Insert(i, new Znak());
            
        }

        public Player(string playerName, int gameTurns)
        {
            name = playerName;
            this.gameTurns = gameTurns;
            finished = false;
            dice = new List<Dice>();
            diceResult = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            rnd = new Random();
            rollTurns = 1;
            znak = new List<Znak>();
            for (int i = 0; i < 14; i++)
                znak.Insert(i, new Znak());
            
        }

        public int[] DiceResult
        {
            get { return diceResult; }
        }
        public int SumaMax
        {
            get { return sumaMax; }
        }
        public int SumaMin
        {
            get { return sumaMin; }
        }
        public List<Dice> Dice
        {
            get { return dice; }
        }
        public List<Znak> Znak
        {
            get { return znak; }
        }

        public int RollTurns
        {
            get { return rollTurns; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int NumPlayer
        {
            get { return numPlayer; }
        }

        public int GameTurns
        {
            get { return gameTurns; }
        }

        public bool Finished
        {
            get { return finished; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void RollDice()
        {
            ReserDiceNumb();
            if (rollTurns == 1)
            {

                for (int i = 0; i < 6; i++)
                    dice.Add(new Dice(rnd.Next(1, 7)));
            }
            else
            {

                for (int i = 0; i < dice.Count; i++)
                    if (!dice[i].IsHeld)
                        dice[i].Value = rnd.Next(1, 7);
            }

            for (int i = 0; i < dice.Count; i++)
                dice[i].IsHeld = false;

            GetDiceNumb();
            rollTurns++;
            
        }

        public void ResetDice()
        {
            dice.Clear();
            for (int i = 0; i < 6; i++)
                dice.Add(new Dice(0));

        }
        public void EndTurn()
        {
            gameTurns--;
            rollTurns = 1;
            if (gameTurns == 0)
                finished = true;

            dice.Clear();


        }
        public void GetDiceNumb()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                switch (dice[i].Value)
                {
                    case 1:
                        diceResult[0]++;
                        break;
                    case 2:
                        diceResult[1]++;
                        break;
                    case 3:
                        diceResult[2]++;
                        break;
                    case 4:
                        diceResult[3]++;
                        break;
                    case 5:
                        diceResult[4]++;
                        break;
                    case 6:
                        diceResult[5]++;
                        break;
                }
            }
            GetResult();
        }

        public void ReserDiceNumb()
        {
            znak.Clear();
            diceResult[0] = 0;
            diceResult[1] = 0;
            diceResult[2] = 0;
            diceResult[3] = 0;
            diceResult[4] = 0;
            diceResult[5] = 0;
            
            for (int i = 0; i < 14; i++)
                znak.Insert(i, new Znak());
            sumaMax = sumaMin = 0;
        }

        private void GetResult()
        {
           
            int brMax = 0;
            znak.Clear();
            for (int i = 0; i < 10; i++)
                znak.Insert(i, new Znak(0, " "));

            sumaMax = 0;
            for (int i = 0; i < dice.Count; i++)
                sumaMax += dice[i].Value;


            sumaMin = 0;
            brMax = 0;

            for (int i = 0; i < dice.Count; i++)
            {
                if (brMax < dice[i].Value)
                    brMax = dice[i].Value;

                sumaMin += dice[i].Value;
            }
            sumaMin -= brMax;


            for (int i = 0; i < diceResult.Length; i++)
            {
                if (diceResult[i] >= 3)
                {
                    Triling = ((i + 1) * 3);
                    if (TriMax < Triling)
                        TriMax = Triling;
                    znak.Insert(0, new Znak(TriMax + 30, "Трилинг"));

                    for (int j = 0; j < diceResult.Length; j++)
                    {
                        if (diceResult[j] >= 2 && (j + 1) != (i + 1))
                        {
                            FullHouse = TriMax + ((j + 1) * 2) + 40;
                            if (FullMax < FullHouse)
                                FullMax = FullHouse;
                            znak.Insert(1, new Znak(FullMax, "Фулхаус"));
                            break;
                        }
                    }

                    if (diceResult[i] >= 4)
                    {
                        znak.Insert(2, new Znak(((i + 1) * 4) + 50, "Покер"));

                        if (diceResult[i] >= 5)
                        {
                            znak.Insert(3, new Znak(((i + 1) * 5) + 60, "Јамб од 5 (" + diceResult[i].ToString() + ")"));
                            if ((i + 1) == 1)
                                znak.Insert(4, new Znak(100, "Јамб од 5 (1)"));

                            if (diceResult[i] >= 6)
                            {
                                znak.Insert(5, new Znak(100, "Јамб од 6 (" + diceResult[i].ToString() + ")"));
                                if ((i + 1) == 1)
                                    znak.Insert(6, new Znak(150, "Јамб од 6 (1)"));
                            }
                        }
                    }
                }
                else if (diceResult[0] >= 1 && diceResult[1] >= 1 && diceResult[2] >= 1 && diceResult[3] >= 1 && diceResult[4] >= 1)
                {
                    znak.Insert(7, new Znak(45, "Скала од 1-5"));
                    if (diceResult[0] == 1 && diceResult[1] == 1 && diceResult[2] == 1 && diceResult[3] == 1 && diceResult[4] == 1 && diceResult[5] == 1)
                    {
                        znak.Insert(9, new Znak(100, "Скала од 1-6"));
                        break;
                    }
                }
                else if (diceResult[1] >= 1 && diceResult[2] >= 1 && diceResult[3] >= 1 && diceResult[4] >= 1 && diceResult[5] >= 1)
                {
                    znak.Insert(8, new Znak(50, "Скала од 2-6"));
                    if (diceResult[0] == 1 && diceResult[1] == 1 && diceResult[2] == 1 && diceResult[3] == 1 && diceResult[4] == 1 && diceResult[5] == 1)
                    {
                        znak.Insert(9, new Znak(100, "Скала од 1-6"));
                        break;
                    }
                }
            }

            Print();
        }

        public void Print()
        {
            string tmp = string.Empty;
            rDice = string.Empty;

            for (int i = 0; i < diceResult.Length; i++)
            {
                if (diceResult[i] != 0)
                {
                    switch (i)
                    {
                        case 0:
                            rDice += "\nЕдиници = " + diceResult[0].ToString();
                            break;
                        case 1:
                            rDice += "\nДвојќи = " + diceResult[1].ToString();
                            break;
                        case 2:
                            rDice += "\nТројќи = " + diceResult[2].ToString();
                            break;
                        case 3:
                            rDice += "\nЧетворки = " + diceResult[3].ToString();
                            break;
                        case 4:
                            rDice += "\nПеттки = " + diceResult[4].ToString();
                            break;
                        case 5:
                            rDice += "\nШески = " + diceResult[5].ToString();
                            break;
                    }
                }
            }

            for (int i = 0; i < znak.Count; i++)
            {
                if (znak[i].value != 0)
                {
                    if (znak[7].value == 0 && znak[8].value == 0 && znak[9].value == 0)
                        tmp += String.Format("\n{0} = {1}", znak[i].ime, znak[i].value);
                    else
                        tmp = String.Format("\n{0} = {1}", znak[i].ime, znak[i].value);
                }


            }
            youHave = tmp;
        }
        public override string ToString()
        {
            return String.Format("{0}\n----------------{1}\nМаксимум = {2}\nМинимум =  {3}\n",rDice,youHave, sumaMax, sumaMin);
        }
    }


}
