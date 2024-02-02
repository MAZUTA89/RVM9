using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Gun
{
    [CreateAssetMenu(fileName = "TankGunSO", menuName = "ScriptableObjects/TanhGunSO")]
    public class TankGunSO : ScriptableObject
    {
        public float Speed;
        public float ShootOffset;
        public float Delay;
    }
}
