using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class GameEvents
    {
        public static event Action OnGameOverEvent;
        public static void InvokeGameoVerAction()
        {
            OnGameOverEvent?.Invoke();
        }
    }
}
