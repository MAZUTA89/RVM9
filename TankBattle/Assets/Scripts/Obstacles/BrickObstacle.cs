using Assets.Scripts.Enemy.MoveTerritores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class BrickObstacle : ArmorObstacle
    {
        [SerializeField] MoveTerritory MoveTerritoryUnderBrick;
        
        public override void OnArmorZero()
        {
            base.OnArmorZero();
            if (MoveTerritoryUnderBrick != null)
            {
                MoveTerritoryUnderBrick.SetEmpty(true);
            }
        }
    }
}
