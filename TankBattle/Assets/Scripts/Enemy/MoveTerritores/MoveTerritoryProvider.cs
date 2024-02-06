using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Newtonsoft.Json.Linq;
using static Cinemachine.CinemachineImpulseManager.ImpulseEvent;

namespace Assets.Scripts.Enemy.MoveTerritores
{
    public class MoveTerritoryProvider
    {
        int iStart = 2;
        int jStart = 10;
        public List<MoveTerritory> MoveTerritorie { get; private set; }
        MoveTerritory[][] _moveTerritories;
        int _lengthHorizontal;
        int _lengthVertical;

        public MoveTerritoryProvider()
        {
            MoveTerritorie = new List<MoveTerritory>();
        }
        public MoveTerritoryProvider(int lenghtHorizontal, int lenghtVertical,
            List<MoveTerritory> moveTerritories)
        {
            _lengthHorizontal = lenghtHorizontal;
            _lengthVertical = lenghtVertical;
            MoveTerritorie = moveTerritories;
        }

        public void Initialize()
        {
            _moveTerritories = new MoveTerritory[_lengthVertical][];


            for (int i = 0; i < _moveTerritories.Length; i++)
            {
                _moveTerritories[i] = new MoveTerritory[_lengthHorizontal];
            }

            int sourceIndex = 0;
            for (int i = 0; i < _moveTerritories.Length; i++)
            {
                for (int j = 0; j < _moveTerritories[i].Length; j++)
                {

                    if (sourceIndex == MoveTerritorie.Count)
                        break;

                    _moveTerritories[i][j] = MoveTerritorie[sourceIndex];
                    sourceIndex++;

                }
            }
            SortArrayInEachRowX(_moveTerritories);
            InitializeIndexes();
            //PrintArray(_moveTerritories);

        }
        void InitializeIndexes()
        {
            for (int i = 0; i < _moveTerritories.Length; i++)
            {
                for (int j = 0; j < _moveTerritories[i].Length; j++)
                {
                    MoveTerritoryIndex moveTerritoryIndex = new MoveTerritoryIndex()
                    {
                        Index = i,
                        Jndex = j
                    };

                    _moveTerritories[i][j].SetIndex(moveTerritoryIndex);
                }
            }
        }
        void SortArrayInEachRowX(MoveTerritory[][] moveTerritores)
        {
            for (int i = 0; i < moveTerritores.GetLength(0); i++)
            {
                SortArrayX(moveTerritores[i]);
            }
        }
        void SortArrayX(MoveTerritory[] moveTerritories)
        {
            int n = moveTerritories.Length;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < n; i++)
                {
                    if (moveTerritories[i - 1].transform.position.x > moveTerritories[i].transform.position.x)
                    {
                        // Меняем местами элементы, если нужно
                        MoveTerritory temp = moveTerritories[i - 1];
                        moveTerritories[i - 1] = moveTerritories[i];
                        moveTerritories[i] = temp;

                        swapped = true;
                    }
                }

            } while (swapped);
        }

        public IEnumerator DeleteObjectsWithDelay()
        {
            float deletionDelay = 0.2f;
            int rows = _moveTerritories.GetLength(0);
            int columns = _moveTerritories[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    GameObject currentObject = _moveTerritories[i][j].gameObject;

                    // Удаление объекта с задержкой
                    yield return new WaitForSeconds(deletionDelay);

                    if (currentObject != null)
                    {
                        //Debug.Log($"Deactivate: {i} {j} X: {_moveTerritories[i][j].transform.position.x}");
                        currentObject.SetActive(false);
                    }
                }
            }

            // Конец корутины
            Debug.Log("Удаление завершено");
        }


        void PrintArray(MoveTerritory[][] array)
        {
            int rows = array.Length;
            int columns = array[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Вывод координат X каждого объекта в массиве
                    Debug.Log($"{array[i][j].transform.position.x} [{i}] [{j}]");
                }
            }
        }
        void SortObjectsInEachRow(MoveTerritory[][] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                // Преобразование строки в одномерный массив для сортировки
                MoveTerritory[] rowArray = new MoveTerritory[columns];
                for (int j = 0; j < columns; j++)
                {
                    rowArray[j] = array[i][j];
                }

                // Сортировка объектов в строке по координате X
                Array.Sort(rowArray, (obj1, obj2) =>
                {
                    float x1 = obj1.transform.position.x;
                    float x2 = obj2.transform.position.x;
                    return x1.CompareTo(x2);
                });

                // Обновление двумерного массива отсортированными объектами
                for (int j = 0; j < columns; j++)
                {
                    array[i][j] = rowArray[j];
                }
            }
        }
       
        public MoveTerritory GetMoveTerritory(MoveTerritoryIndex moveTerritoryIndex, Side side)
        {
            iStart = moveTerritoryIndex.Index;
            jStart = moveTerritoryIndex.Jndex;
            Side randomSide = Side.Down;
            //Side randomSide = (Side)Random.Range(1, 5);
            //DirectionSide = randomSide;
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
        public MoveTerritory GetRandomMoveTerritory(MoveTerritoryIndex moveTerritoryIndex, out Side DirectionSide)
        {
            iStart = moveTerritoryIndex.Index;
            jStart = moveTerritoryIndex.Jndex;
            //Side randomSide = Side.Down;
            Side randomSide = (Side)Random.Range(1, 5);
            DirectionSide = randomSide;
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
            for (int j = jStart - 1; j > -1; j--)
            {
                MoveTerritory moveTerritory = _moveTerritories[iStart][j];
                if (moveTerritory.IsEmptyTerritory)
                {
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
            for (int j = jStart + 1; j < _moveTerritories[0].Length; j++)
            {
                MoveTerritory moveTerritory = _moveTerritories[iStart][j];
                if (moveTerritory.IsEmptyTerritory)
                {
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
            for (int i = iStart - 1; i > -1; i--)
            {
                MoveTerritory moveTerritory = _moveTerritories[i][jStart];
                if (moveTerritory.IsEmptyTerritory)
                {
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

            for (int i = iStart + 1; i < _moveTerritories.GetLength(0); i++)
            {
                MoveTerritory moveTerritory = _moveTerritories[i][jStart];
                if (moveTerritory.IsEmptyTerritory)
                {
                    emptyMoveTerritoriesByDownSide.Add(moveTerritory);
                }
                else
                    break;
            }

            return GetRandomMoveTerritoryBySide(emptyMoveTerritoriesByDownSide);
        }

        MoveTerritory GetRandomMoveTerritoryBySide(List<MoveTerritory> moveTerritories)
        {
            if (moveTerritories.Count < 1)
            {
                //Debug.LogError($"{moveTerritories} is empty");
                //Debug.LogError($"Choose: {iStart} {jStart}---------------------------------------------------");
                return _moveTerritories[iStart][jStart];
            }
            else
            {
                int randomIndex = Random.Range(0, moveTerritories.Count);
                //Debug.LogError($"Choose: {iStart} {randomIndex} ---------------------------------------------------");
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
