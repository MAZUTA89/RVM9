using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy.MoveTerritores
{
    public class MoveTerritory : MonoBehaviour
    {
        [SerializeField] bool IsEmpty;
        [Inject]
        public void Construct(MoveTerritoryProvider moveTerritoryProvider)
        {
            moveTerritoryProvider.AddTerritory(this);
        }

        public void SetEmpty(bool isEmpty)
        {
            IsEmpty = isEmpty;
        }
    }
}
