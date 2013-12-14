using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    public class GameState
        : MonoBehaviour
    {
        private static GameState instance;

        public static GameState Instance
        {
            get
            {
                if (instance == null)
                {
                    var controllerObject = GameObject.FindGameObjectWithTag("GameController");

                    if (controllerObject != null)
                    {
                        instance = controllerObject.GetComponent<GameState>();
                    }

                    if (instance == null)
                    {
                        var newControllerObject = new GameObject("GameState", typeof(GameState));
                        newControllerObject.tag = "GameController";

                        instance = newControllerObject.GetComponent<GameState>();
                    }
                }

                return instance;
            }
        }

        private void Start()
        {
            if (instance != this)
            {
                instance = this;
            }
        }

        public GameMode CurrentMode;

        public bool CanChangeGameMode = true;
    }
}
