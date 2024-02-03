using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.MoveTerritores;
using System;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] int MaxLengthHorizontal = 18;
        [SerializeField] int MaxLenghtVertical = 16;
        [SerializeField] EnemySO EnemySO;
        public override void InstallBindings()
        {
            BindMoveTerritiryProvider();
            Container.Bind<MoveTerritory>().FromComponentInHierarchy().AsTransient();
            Container.BindInstance(EnemySO).AsSingle();
            Container.Bind<SimpleTank>().AsSingle();
        }
        void BindMoveTerritiryProvider()
        {
            MoveTerritoryProvider moveTerritoryProvider =
                new MoveTerritoryProvider(MaxLengthHorizontal, MaxLenghtVertical);
            Container.BindInstance(moveTerritoryProvider).AsSingle();
        }
    }
}
