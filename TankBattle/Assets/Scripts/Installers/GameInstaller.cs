using Assets.Scripts.Input;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using Assets.Scripts.Gun;
using Assets.Scripts.Bullet;

namespace Assets.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] GameObject BulletPrefab;
        [SerializeField] TankGunSO TankGunSO;
        public override void InstallBindings()
        {
            Container.Bind<InputService>().AsSingle();
            Container.Bind<Movement>().AsSingle();
            Container.Bind<PlayerDirection>().AsSingle();
            Container.Bind<PlayerTankGun>().AsTransient();
            Container.BindInstance(BulletPrefab).WithId("BulletPrefab").AsTransient();
            Container.BindInstance(TankGunSO).AsTransient();
            Container.Bind<PlayerTankTerritory>().FromComponentInHierarchy().AsSingle();
        }
    }
}
