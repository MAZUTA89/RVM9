using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class ParticlesCleaner : MonoBehaviour
    {
        public static ParticlesCleaner Instance;
        private void Start()
        {
            Instance = this;
        }
        public void CleanParticle(ParticleSystem particleSystem)
        {
            StartCoroutine(DeleteBulletParticleObject(particleSystem));
        }
        IEnumerator DeleteBulletParticleObject(ParticleSystem particle)
        {
            yield return new WaitForSeconds(particle.main.duration);
            particle.Stop();
            Destroy(particle.gameObject);
        }
    }
}
