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
                    var deltaPosition = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * Speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * Speed);

                    deltaPosition = this.transform.TransformDirection(deltaPosition);

                    Parent.rigidbody.MovePosition(Parent.rigidbody.position + deltaPosition);
                    break;
                case GameMode.Sidescroller:
                    Parent.rigidbody.MovePosition(Parent.rigidbody.position + new Vector3(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * Speed));

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Parent.rigidbody.velocity += new Vector3(0, 5, 0);
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
