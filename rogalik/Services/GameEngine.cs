using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rogalik.Models;

namespace rogalik.Services
{
    public class GameEngine
    {
        public Player Player { get; private set; }
        public int Turn {  get; private set; }
        public GameState State { get; private set; }

        public List<string> Log { get; } = new();

        public void StartGame()
        {
            Player = new Player();
            Turn = 0;
            State = GameState.Exploration;

            AddLog("Игра началась");
        }

        public void AddLog(string message)
        {
            Log.Add(message);
        }
    }
}
