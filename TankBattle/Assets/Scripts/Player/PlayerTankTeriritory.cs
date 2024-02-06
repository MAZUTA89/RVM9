using Assets.Scripts.Enemy.MoveTerritores;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerTankTerritory : MonoBehaviour
    {
        public MoveTerritory Territory {  get; private set; }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out MoveTerritory territory))
            {
                Territory = territory;
            }
        }
    }
}