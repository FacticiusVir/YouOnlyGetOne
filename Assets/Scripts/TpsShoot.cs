using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    public class TpsShoot
        : MonoBehaviour
    {
        public float ShotCooldown = 1;

        public Light MuzzleFlash;

        public GameObject GunFlare;

        private float lastShotTime = 0;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && this.lastShotTime + this.ShotCooldown < Time.time)
            {
                this.audio.Play();

                this.lastShotTime = Time.time;

                this.MuzzleFlash.intensity = 1;

                this.GunFlare.renderer.enabled = true;
            }
            else if (this.lastShotTime + 0.1f < Time.time)
            {
                this.MuzzleFlash.intensity = 0;

                this.GunFlare.renderer.enabled = false;
            }
        }
    }
}
