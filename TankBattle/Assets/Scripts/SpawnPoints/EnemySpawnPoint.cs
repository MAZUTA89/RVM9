using Assets.Scripts.Enemy.MoveTerritores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpawnPoints
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] MoveTerritory SpawnTerritory;
        public MoveTerritory GetSpawnTerritory()
        {
            return SpawnTerritory;
        }
    }
}
