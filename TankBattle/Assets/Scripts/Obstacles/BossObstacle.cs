using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Obstacles
{
    public class BossObstacle : ArmorObstacle
    {
        public override void OnArmorZero()
        {
            base.OnArmorZero();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
