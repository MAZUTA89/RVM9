using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.MoveTerritores
{
    public class MoveTerritoryProvider
    {
        public List<MoveTerritory> MoveTerritories { get; private set; }
        int _lengthHorizontal;
        int _lengthVertical;

        public MoveTerritoryProvider() 
        {
            MoveTerritories = new List<MoveTerritory>();
        }
        public MoveTerritoryProvider(int lenghtHorizontal, int lenghtVertical)
        {
            _lengthHorizontal = lenghtHorizontal;
            _lengthVertical = lenghtVertical;
        }

        public void AddTerritory(MoveTerritory moveTerritory)
        {
            MoveTerritories.Add(moveTerritory);
        }

        public Vector3 GetRandomMoveTerritorypPosition()
        {
            int randomIndex = Random.Range(0, MoveTerritories.Count);

            return MoveTerritories[randomIndex].transform.position;
        }
        //public V GetRandomMoveTerritory()
        //{

        //}
    }
}
