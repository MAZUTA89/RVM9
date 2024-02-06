using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Obstacles
{
    public class BossObstacle : ArmorObstacle
    {
        public TextMeshProUGUI BossHealthText;
        private void OnEnable()
        {
            BossHealthText.text = Armor.ToString();
            OnObstacleTakeDamage += OnTakeDamage;
        }
        private void OnDisable()
        {
            OnObstacleTakeDamage -= OnTakeDamage;
        }
        public override void OnArmorZero()
        {
            base.OnArmorZero();
            GameEvents.InvokeGameoVerAction();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        void OnTakeDamage(int armor)
        {
            BossHealthText.text = armor.ToString(); 
        }
    }
}
