using Assets.Scripts.Bullet;
using Assets.Scripts.Input;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Gun
{
    public class PlayerTankGun : MonoBehaviour
    {
        #region Injected
        GameObject _bulletPrefab;
        PlayerDirection _playerDirection;
        TankGunSO _tankGunSO;
        InputService _inputService;
        #endregion

        float _currentTimeDelay;
        [Inject]
        public void Construct([Inject(Id = "BulletPrefab")]GameObject bulletPrefab,
            PlayerDirection playerDirection,
            TankGunSO tankGunSO,
            InputService inputService)
        {
            _bulletPrefab = bulletPrefab;
            _playerDirection = playerDirection;
            _tankGunSO = tankGunSO;
            _inputService = inputService;
        }
        private void Start()
        {
            
        }
        private void Update()
        {
            if(_inputService.IsShoot())
            {
                Shoot();
            }
        }

        
        void Shoot()
        {
            Vector2 offset = (_tankGunSO.ShootOffset * _playerDirection.Direction);
            Vector3 position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);

            var go = Instantiate(_bulletPrefab, position, Quaternion.identity, null);

            go.GetComponent<TankBullet>().SetDirection(_playerDirection.Direction);
        }
    }
}
