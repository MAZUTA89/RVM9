using Assets.Scripts.Gun;
using Assets.Scripts.Obstacles;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankBullet : MonoBehaviour
    {
        [SerializeField] ParticleSystem BlowParticle;
        [SerializeField] TankGunSO TankGunSO;
        Rigidbody2D _rb;
        Vector2 _direction;
        public string particleSortingLayerName = "Particles"; // Имя слоя сортировки ParticleSystem
        public int particleSortingOrder = 9; // Порядок сортировки ParticleSystem

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {

        }

        private void FixedUpdate()
        {
            float step = TankGunSO.Speed * Time.fixedDeltaTime;
            Vector2 newPos = Vector2.MoveTowards(_rb.position, _rb.position + _direction, step);
            _rb.MovePosition(newPos);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var go = collider.gameObject;
            if (go.CompareTag("MapWall"))
            {
                Destroy(gameObject);
            }
        }
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
        private void OnDestroy()
        {
            //BlowParticle.gameObject.transform.position = transform.position;
            //BlowParticle.Play(false);
            var go = Instantiate(BlowParticle, transform.position, Quaternion.identity, null);
            // Настройка слоя сортировки ParticleSystem
            // Настройка слоя сортировки SpriteRenderer
            SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingLayerName = particleSortingLayerName;
                spriteRenderer.sortingOrder = particleSortingOrder;
            }
        }
    }
}
