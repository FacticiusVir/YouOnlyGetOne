using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tile
        : MonoBehaviour
    {
        private float totalRotation = 0;

        private Quaternion? initialRotation = null;

        private Quaternion? finalRotation = null;

        private float startTime = 0;

        public float Speed = 45;

        private void Start()
        {
        }

        private void Update()
        {
            if (GameState.Instance.CurrentMode == GameMode.Puzzler && Input.GetMouseButtonDown(0) && this.initialRotation == null)
            {
                this.totalRotation += 90;

                if (this.initialRotation == null)
                {
                    this.initialRotation = this.rigidbody.rotation;
                    this.startTime = Time.time;
                }

                this.finalRotation = this.initialRotation * Quaternion.AngleAxis(this.totalRotation, Vector3.up);
            }

            if (this.initialRotation.HasValue)
            {
                float totalTime = this.totalRotation / this.Speed;

                float proportion = (Time.time - startTime) / totalTime;

                bool isComplete = false;

                if (proportion >= 1f)
                {
                    proportion = 1f;
                    isComplete = true;
                }

                this.rigidbody.MoveRotation(Quaternion.Lerp(this.initialRotation.Value, this.finalRotation.Value, proportion));

                if (isComplete)
                {
                    this.initialRotation = null;
                    this.finalRotation = null;
                    this.totalRotation = 0;
                }
            }
        }
    }
}
