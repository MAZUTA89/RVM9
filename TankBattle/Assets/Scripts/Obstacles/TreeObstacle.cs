using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class TreeObstacle : Obstacle
    {
        public override void OnTriggerEnter2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if(go.CompareTag("Bullet"))
            {
                Destroy(go);
                Destroy(gameObject);
            }
            if(go.CompareTag("Tank"))
            {

            }
        }
    }
}
