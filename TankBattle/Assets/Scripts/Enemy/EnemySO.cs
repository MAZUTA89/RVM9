using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public float DistanceToChangePoint;
        public float Speed;
    }
}
