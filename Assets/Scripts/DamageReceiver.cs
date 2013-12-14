using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageReceiver
        : MonoBehaviour
    {
        public ParticleSystem ExplosionParticles;

        private bool isDestroyed;

        public void ReceiveDamage(float amount, Vector3 direction)
        {
            if (!this.isDestroyed)
            {
                this.isDestroyed = true;
                this.StartCoroutine(this.Explode(direction));
            }
        }

        private IEnumerator Explode(Vector3 direction)
        {
            this.GetComponent<MeshRenderer>().enabled = false; 

            if (this.ExplosionParticles != null)
            {
                this.ExplosionParticles.transform.rotation = Quaternion.LookRotation(direction);

                this.ExplosionParticles.Play();

                while (this.ExplosionParticles.isPlaying)
                {
                    yield return null;
                }
            }

            GameObject.Destroy(this.gameObject);
        }
    }
}
