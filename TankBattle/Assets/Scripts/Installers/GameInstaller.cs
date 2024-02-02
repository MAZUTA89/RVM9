using Assets.Scripts.Input;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputService>().AsSingle();
            Container.Bind<Movement>().AsSingle();
        }
    }
}
