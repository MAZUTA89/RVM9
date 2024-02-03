using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.MoveTerritores
{
    public class MoveTerritoryProvider
    {
        int iStart = 1;
        int jStart = 10;
        public List<MoveTerritory> MoveTerritories { get; private set; }
        MoveTerritory[,] _moveTerritories;
        int _lengthHorizontal;
        int _lengthVertical;

        public MoveTerritoryProvider()
        {
            MoveTerritories = new List<MoveTerritory>();
        }
        public MoveTerritoryProvider(int lenghtHorizontal, int lenghtVertical,
            List<MoveTerritory> moveTerritories)
        {
            _lengthHorizontal = lenghtHorizontal;
            _lengthVertical = lenghtVertical;
            MoveTerritories = moveTerritories;
        }

        public void Initialize()
        {
            _moveTerritories = new MoveTerritory[_lengthVertical, _lengthHorizontal];
            int step = 0;
            int j = 0;
            for (int i = 0; i < _moveTerritories.GetLength(0); i++)
            {
                for (j = 0; j < _moveTerritories.GetLength(1); j++)
                {
                    MoveTerritoryIndex moveTerritoryIndex = new MoveTerritoryIndex()
                    {
                        Index = i,
                        Jndex = j
                    };

                    _moveTerritories[i, j] = MoveTerritories[j + step];
                    _moveTerritories[i, j].SetIndex(moveTerritoryIndex);
                }
                step += j;
            }
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
        public MoveTerritory GetRandomMoveTerritory(MoveTerritoryIndex moveTerritoryIndex)
        {
            iStart = moveTerritoryIndex.Index;
            jStart = moveTerritoryIndex.Jndex;
            Side randomSide = Side.Down;
            //Side randomSide = (Side)Random.Range(1, 5);
            switch (randomSide)
            {
                case Side.Left:
                    {
                        return GetRandomMoveTerritoryByLeftSide();
                    }
                case Side.Right:
                    {
                        return GetRandomMoveTerritoryByRightSide();
                    }
                case Side.Up:
                    {
                        return GetRandomMoveTerritoryByUpSide();
                    }
                case Side.Down:
                    {
                        return GetRandomMoveTerritoryByDownSide();
                    }
                default:
                    return null;
            }

        }

        MoveTerritory GetRandomMoveTerritoryByLeftSide()
        {
            List<MoveTerritory> emptyMoveTerritoriesByLeftSide = new List<MoveTerritory>();
            for (int j = jStart; j > -1; j--)
            {
                MoveTerritory moveTerritory = _moveTerritories[iStart, j];
                if (moveTerritory.IsEmptyTerritory)
                {
                    moveTerritory.gameObject.SetActive(false);
                    emptyMoveTerritoriesByLeftSide.Add(moveTerritory);
                }
                else
                {
                    break;
                }
            }

            return GetRandomMoveTerritoryBySide(emptyMoveTerritoriesByLeftSide);

        }
        MoveTerritory GetRandomMoveTerritoryByRightSide()
        {
            List<MoveTerritory> emptyMoveTerritoriesByRightSide = new List<MoveTerritory>();
            for (int j = jStart; j < _moveTerritories.GetLength(1); j++)
            {
                MoveTerritory moveTerritory = _moveTerritories[iStart, j];
                if (moveTerritory.IsEmptyTerritory)
                {
                    moveTerritory.gameObject.SetActive(false);
                    emptyMoveTerritoriesByRightSide.Add(moveTerritory);
                }
                else
                {
                    break;
                }
            }
            return GetRandomMoveTerritoryBySide(emptyMoveTerritoriesByRightSide);
        }

        MoveTerritory GetRandomMoveTerritoryByUpSide()
        {
            List<MoveTerritory> emptyMoveTerritoriesByUpSide = new List<MoveTerritory>();
            for (int i = iStart; i < _moveTerritories.GetLength(0); i++)
            {
                MoveTerritory moveTerritory = _moveTerritories[i, jStart];
                if (moveTerritory.IsEmptyTerritory)
                {
                    moveTerritory.gameObject.SetActive(false);
                    emptyMoveTerritoriesByUpSide.Add(moveTerritory);
                }
                else
                    break;
            }

            return GetRandomMoveTerritoryBySide(emptyMoveTerritoriesByUpSide);
        }

        MoveTerritory GetRandomMoveTerritoryByDownSide()
        {
            List<MoveTerritory> emptyMoveTerritoriesByDownSide = new List<MoveTerritory>();
            for (int i = iStart; i < _moveTerritories.GetLength(0); i++)
            {
                MoveTerritory moveTerritory = _moveTerritories[i, jStart];
                if (moveTerritory.IsEmptyTerritory)
                {
                    moveTerritory.gameObject.SetActive(false);
                    emptyMoveTerritoriesByDownSide.Add(moveTerritory);
                }
                else
                    break;
            }

            return GetRandomMoveTerritoryBySide(emptyMoveTerritoriesByDownSide);
        }

        MoveTerritory GetRandomMoveTerritoryBySide(List<MoveTerritory> moveTerritories)
        {
            if (moveTerritories == null)
            {
                Debug.LogError($"{moveTerritories} is null");
                return null;
            }
            else if (moveTerritories.Count < 1)
            {
                Debug.LogError($"{moveTerritories} is empty");
                return null;
            }
            else
            {
                int randomIndex = Random.Range(0, moveTerritories.Count);
                return moveTerritories[randomIndex];
            }

        }
        public enum Side
        {
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4,
        }

    }
}
