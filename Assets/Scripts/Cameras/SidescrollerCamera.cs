using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Cameras
{
    public class SidescrollerCamera
        : MonoBehaviour
    {
        private Camera cameraInstance;

        private void Start()
        {
            this.cameraInstance = this.GetComponent<Camera>();
        }

        private void Update()
        {
            this.cameraInstance.enabled = GameState.Instance.CurrentMode == GameMode.Sidescroller;
        }
    }
}
