using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement
        : MonoBehaviour
    {
        public float Speed = 3;
        public GameObject Parent = null;

        private void Update()
        {
            switch (GameState.Instance.CurrentMode)
            {
                case GameMode.ThirdPersonShooter:
                    Parent.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * Speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * Speed), this.transform);
                    break;
                case GameMode.Sidescroller:
                    Parent.transform.Translate(new Vector3(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * Speed), Space.World);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Parent.transform.Translate(0, 2, 0);
                    }
                    break;
                case GameMode.Puzzler:
                    break;
                default:
                    break;
            }
        }
    }
}
