using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using Assets.Scripts.SpawnPoints;
using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Enemy;
using UnityEngine.Rendering;

namespace Assets.Scripts.Installers
{
    public class EnemySpawnInstaller : MonoInstaller
    {
        [SerializeField] GameObject SimpleTankPrefab;
        [SerializeField] GameObject HuntTankPrefab;
        [SerializeField] List<EnemySpawnPoint> SimpleTankSpawnPoints;
        [SerializeField] List<EnemySpawnPoint> HuntTankSpawnPoints;


        public override void InstallBindings()
        {
            SpawnSimpleTanks();
            SpawnHuntTanks();
        }

        void SpawnSimpleTanks()
        {
            foreach (var spawnPoint in SimpleTankSpawnPoints)
            {
                SpawnTank(SimpleTankPrefab, spawnPoint);
            }
        }
        void SpawnHuntTanks()
        {
            foreach (var spawnPoint in HuntTankSpawnPoints)
            {
                SpawnTank(HuntTankPrefab, spawnPoint);
            }
        }

        void SpawnTank(GameObject prefab, EnemySpawnPoint enemySpawnPoint)
        {
            EnemyTank enemyTank = Container.InstantiatePrefabForComponent<EnemyTank>(prefab,
                enemySpawnPoint.transform.position, Quaternion.identity, null);

            enemyTank.InitializeSpawnTerritory(enemySpawnPoint.GetSpawnTerritory());
        }
    }
}
