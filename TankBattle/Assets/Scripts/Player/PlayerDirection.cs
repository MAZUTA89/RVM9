using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerDirection
    {
        public Vector2 Direction;

        public void SetDirection(Vector2 direction)
        {
            Direction = direction.normalized;
        }
    }
}
