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
        /// <summary>
        /// true, если территория пустая, false - занята
        /// </summary>
        public bool IsEmptyTerritory => IsEmpty;

        public MoveTerritoryIndex MoveTerritoryIndex { get; private set; }
        
        public void SetEmpty(bool isEmpty)
        {
            IsEmpty = isEmpty;
        }

        public void SetIndex(MoveTerritoryIndex moveTerritoryIndex)
        {
            MoveTerritoryIndex = moveTerritoryIndex;
        }
        
    }
    public struct MoveTerritoryIndex
    {
        public int Index;
        public int Jndex;
    }
}
