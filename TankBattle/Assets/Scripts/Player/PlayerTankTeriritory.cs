using Assets.Scripts.Enemy.MoveTerritores;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerTankTerritory : MonoBehaviour
    {
        [SerializeField] int Health;
        public MoveTerritory Territory {  get; private set; }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out MoveTerritory territory))
            {
                Territory = territory;
            }
            //if (collision.gameObject.CompareTag("Bullet"))
            //{
            //    Health--;
            //    if (Health < 1)
            //    {
            //        Destroy(gameObject);
            //    }
            //    Destroy(collision.gameObject);
            //}
        }
    }
}