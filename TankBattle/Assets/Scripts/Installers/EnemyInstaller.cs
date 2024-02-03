using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.MoveTerritores;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] int MaxLengthHorizontal = 18;
        [SerializeField] int MaxLenghtVertical = 16;
        [SerializeField] List<MoveTerritory> MoveTerritores;
        [SerializeField] EnemySO EnemySO;
        public override void InstallBindings()
        {
            BindMoveTerritiryProvider();
            Container.BindInstance(EnemySO).AsSingle();
            Container.Bind<SimpleTank>().AsSingle();
        }
        void BindMoveTerritiryProvider()
        {
            MoveTerritoryProvider moveTerritoryProvider =
                new MoveTerritoryProvider(MaxLengthHorizontal, MaxLenghtVertical,
                MoveTerritores);
            Container.BindInstance(moveTerritoryProvider).AsSingle();
        }
    }
}
