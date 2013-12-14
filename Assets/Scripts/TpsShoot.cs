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

        public Camera ViewCamera;

        private float lastShotTime = 0;

        private void Update()
        {
            if (GameState.Instance.CurrentMode == GameMode.ThirdPersonShooter && Input.GetButtonDown("Fire1") && this.lastShotTime + this.ShotCooldown < Time.time)
            {
                this.FireShot();
            }
            else if (this.lastShotTime + 0.1f < Time.time)
            {
                this.MuzzleFlash.intensity = 0;

                this.GunFlare.renderer.enabled = false;
            }
        }

        private void FireShot()
        {
            this.audio.Play();

            this.lastShotTime = Time.time;

            this.MuzzleFlash.intensity = 0.5f;

            this.GunFlare.renderer.enabled = true;

            var viewRay = this.ViewCamera.transform.TransformDirection(new Vector3(0, 0, 100));

            var end = this.ViewCamera.transform.position + viewRay;

            RaycastHit hitInfo;

            if (Physics.Linecast(this.ViewCamera.transform.position, end, out hitInfo))
            {
                var damageReceiver = hitInfo.collider.GetComponent<DamageReceiver>();

                if(damageReceiver!=null)
                {
                    var normalViewRay = Vector3.Normalize(viewRay);

                    damageReceiver.ReceiveDamage(0, normalViewRay);
                }
            }
        }
    }
}
