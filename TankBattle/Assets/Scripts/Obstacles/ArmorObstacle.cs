using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class ArmorObstacle : Obstacle
    {
        [SerializeField] protected int Armor;
        protected event Action<int> OnObstacleTakeDamage;
        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            if(go.CompareTag("Bullet"))
            {
                Damage();
            }
        }
        public virtual void Damage()
        {
            Armor -= 1;
            OnObstacleTakeDamage?.Invoke(Armor);
            if (Armor < 1)
            {
                OnArmorZero();    
                Destroy(gameObject);
            }
        }
        public virtual void OnArmorZero()
        {
            Debug.Log($"Destroy {go.name}");
        }

    }
}
