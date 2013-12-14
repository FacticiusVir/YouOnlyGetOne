using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class GameState
    {
        private static GameState instance;

        private GameState()
        {
            CurrentMode = GameMode.ThirdPersonShooter;
        }

        public static GameState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameState();
                }

                return instance;
            }
        }

        public GameMode CurrentMode
        {
            get;
            set;
        }
    }
}
