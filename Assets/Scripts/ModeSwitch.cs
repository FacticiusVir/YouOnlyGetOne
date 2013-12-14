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
            if (GameState.Instance.CanChangeGameMode && Input.GetKeyDown(KeyCode.Tab))
            {
                GameState.Instance.CurrentMode++;
                if (GameState.Instance.CurrentMode > GameMode.Puzzler)
                {
                    GameState.Instance.CurrentMode = GameMode.ThirdPersonShooter;
                }
            }

            Screen.lockCursor = true;
            Screen.showCursor = GameState.Instance.CurrentMode == GameMode.Puzzler;
        }
    }
}
