using Assets.Scripts.Input;
using Assets.Scripts.Obstacles;
using ModestTree;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] float MovementSpeed;
        [SerializeField] float TreeMovementSpeed;
        float _currentMovementSpeed;
        InputService _inputService;
        PlayerDirection _playerDirection;

        protected int XKey;
        protected int YKey;

        Vector2 _input;
        Vector2 _newPos;
        Vector2 _velocity;
        Rigidbody2D _rb;
        SpriteRenderer _sr;
        Animator _animator;
        [Inject]
        public void Construct(InputService inputService, PlayerDirection playerDirection)
        {
            _inputService = inputService;
            _playerDirection = playerDirection;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            XKey = Animator.StringToHash("X");
            YKey = Animator.StringToHash("Y");

            _playerDirection.SetDirection(new Vector2(0, -1));
            _currentMovementSpeed = MovementSpeed;
        }
        private void Update()
        {
             _input = _inputService.GetMovement();
            if (_input.x > 0)
            {
                _input.y = 0;
                _animator.SetFloat(XKey, 1);
                _animator.SetFloat(YKey, 0);
            }
            else if (_input.x < 0)
            {

                _animator.SetFloat(XKey, -1);
                _animator.SetFloat(YKey, 0);
                _input.y = 0;
            }
            else if (_input.y > 0)
            {
                _animator.SetFloat(YKey, 1);
                _animator.SetFloat(XKey, 0);
                _input.x = 0;
            }
            else if(_input.y < 0)
            {
                _animator.SetFloat(YKey, -1);
                _animator.SetFloat(XKey, 0);
                _input.x = 0;
            }
            if(_input != Vector2.zero)
            {
                _playerDirection.SetDirection(_input);
            }
        }

        public void FixedUpdate()
        {
            _newPos = _rb.position + _input;
            _newPos += _input;
            _newPos = Vector2.SmoothDamp(_rb.position, _newPos, ref _velocity,
                Time.fixedDeltaTime, _currentMovementSpeed);
            _rb.MovePosition(_newPos);
            
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if(go.TryGetComponent(out TreeObstacle treeObstacle))
            {
                _currentMovementSpeed = TreeMovementSpeed;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if (go.TryGetComponent(out TreeObstacle treeObstacle))
            {
                _currentMovementSpeed = MovementSpeed;
            }
        }
    }
}
