using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    public class ModeSwitch
        : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                GameState.Instance.CurrentMode++;
                if (GameState.Instance.CurrentMode > GameMode.Sidescroller)
                {
                    GameState.Instance.CurrentMode = GameMode.ThirdPersonShooter;
                }
            }
        }
    }
}
