using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class BrickObstacle : Obstacle
    {
        [SerializeField] float Armor = 5f;

        
        public void Damage()
        {
            Armor -= 1;
            if(Armor < 1)
            {
                Destroy(gameObject);
            }
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            var go  = collision.gameObject;
            if (go.CompareTag("Bullet"))
            {
                Damage();
                Destroy(go);
            }
        }
        
    }
}
