using Assets.Scripts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player
{
    public class TankHealth : MonoBehaviour
    {
        [SerializeField] int Health;
        public TextMeshProUGUI HealthText;
        InputService _inputService;
        [Inject]
        public void Construct(InputService inputService)
        {
            _inputService = inputService;
        }
        private void Start()
        {
            
        }
        private void Update()
        {
            HealthText.text = Health.ToString();
            if (_inputService.IncHealth())
            {
                Health++;
            }
            if(_inputService.DecrHealth())
            {
                Health--;
            }
            if(Health < 1)
            {
                GameEvents.InvokeGameoVerAction();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Health--;
                HealthText.text = Health.ToString();
                if (Health < 1)
                {
                    Destroy(gameObject);
                    GameEvents.InvokeGameoVerAction();
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
