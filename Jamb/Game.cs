using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jamb
{
    class Game
    {
        public List<Player> players;
        public List<Player> playersFinished;
        int whoTurn;
        Random rand = new Random();

        public List<Player> Players
        {
            get { return players; }
        }
        public int WhoTurn
        {
            get { return whoTurn; }
        }
        public List<Player> PlayerFinished
        {
            get { return playersFinished; }
        }

        public Game(int pCount)
        {
            players = new List<Player>(pCount);
            playersFinished = new List<Player>(pCount);

            for (int i = 0; i < pCount; i++)
                players.Add(new Player());

        }
        

        public bool NextTurn()
        {
            players[whoTurn].EndTurn();
            
            if (players[whoTurn].Finished)
            {
                playersFinished.Add(players[whoTurn]);
            }

            if (playersFinished.Count == players.Count)
                return false;

            if (whoTurn + 1 >= Players.Count)
            {
                whoTurn = 0;
            }
            else
            {
                whoTurn += 1;
            }
            players[whoTurn].ReserDiceNumb();
            return true;


        }
    }

}
