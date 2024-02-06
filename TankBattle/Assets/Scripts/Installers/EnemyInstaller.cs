using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.MoveTerritores;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] int MaxLengthHorizontal;
        [SerializeField] int MaxLenghtVertical;
        [SerializeField] List<MoveTerritory> MoveTerritores;
        [SerializeField] EnemySO EnemySO;
        public override void InstallBindings()
        {
            BindMoveTerritiryProvider();
            Container.BindInstance(EnemySO).AsTransient();
            Container.Bind<SimpleTank>().AsTransient();
            Container.Bind<HuntTank>().AsTransient();
        }
        void BindMoveTerritiryProvider()
        {
            MoveTerritoryProvider moveTerritoryProvider =
                new MoveTerritoryProvider(MaxLengthHorizontal, MaxLenghtVertical,
                MoveTerritores);
            moveTerritoryProvider.Initialize();
            Container.BindInstance(moveTerritoryProvider).AsTransient();
        }
    }
}
