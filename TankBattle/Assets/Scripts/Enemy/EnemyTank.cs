using Assets.Scripts.Bullet;
using Assets.Scripts.Enemy.MoveTerritores;
using Assets.Scripts.Enemy.StateMachine;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class EnemyTank : MonoBehaviour
    {
        [SerializeField] int Health;
        [SerializeField] LayerMask EnemyViewPlayerIgnoreLayer;
        [SerializeField] LayerMask EnemyViewBossIgnoreLayer;
        [SerializeField] protected MoveTerritory SpawnTerritory;
        public NavMeshAgent Agent { get; protected set; }
        public Animator Animator { get; protected set; }
        public MoveTerritoryProvider MoveTerritoryProvider { get; protected set; }
        public EnemySO EnemySO { get; protected set; }
        protected TankStateMachine TankStateMachine;
        public Vector2 NormalizedDirection { get; set; }
        public GameObject BulletPrefab { get; protected set; }
        /// <summary>
        /// ����� ������
        /// </summary>
        public bool IsVeiw { get; protected set; }
        /// <summary>
        /// ����� �����
        /// </summary>
        public bool IsVeiwBoss { get; protected set; }
        Vector2 _offset;
        Vector2 _origin;
        float _currentTimeBeforDelay;

        // Start is called before the first frame update
        void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.updateRotation = false;
            Agent.updateUpAxis = false;
            Animator = GetComponent<Animator>();
            OnStart();
            InitializeStateMachine();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            TankStateMachine.UpdateLoop();
            _offset = (EnemySO.ShootOffset * NormalizedDirection);

            _origin = new Vector2(transform.position.x + _offset.x, transform.position.y + _offset.y);
            IsVeiw = IsViewPlayer();
            IsVeiwBoss = IsViewBoss();
        }

        protected virtual void FixedUpdate()
        {
            TankStateMachine.FixedUpdate();
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            TankStateMachine.OnTriggerEnter(other);
        }
        protected virtual void OnTriggerStay(Collider other)
        {
            TankStateMachine.OnTriggerStay(other);
        }
        protected virtual void OnTriggerExit(Collider other)
        {
            TankStateMachine.OnTriggerExit(other);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if(go.CompareTag("Bullet"))
            {
                Health--;
                if(Health < 1)
                {
                    Destroy(gameObject);
                }
                Destroy(go);
            }
        }

        public abstract void OnStart();
        public abstract void InitializeStateMachine();

        bool IsViewPlayer()
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(_origin, NormalizedDirection,
                EnemySO.ViewDistance, ~EnemyViewPlayerIgnoreLayer);

            Debug.DrawRay(_origin, NormalizedDirection * 10, Color.yellow);
            if (raycastHit2D.collider == null)
                return false;

            if (raycastHit2D.collider.gameObject.TryGetComponent(out Movement movement))
            {
                Debug.Log($"���� {raycastHit2D.collider.name}");
                return true;
            }
            else
            {
                return false;
            }
        }
        bool IsViewBoss()
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(_origin, NormalizedDirection,
                EnemySO.ViewDistance, ~EnemyViewBossIgnoreLayer);
            if (raycastHit2D.collider == null)
                return false;
            
            if (raycastHit2D.collider.gameObject.CompareTag("Boss"))
            {
                return true;
            }
            else return false;
        }
        public virtual void ShootingWithDelay()
        {
            _currentTimeBeforDelay += Time.deltaTime;
            if (_currentTimeBeforDelay > EnemySO.ShootDelay)
            {
                _currentTimeBeforDelay = 0f;
                Shoot();
            }
        }
        public void Shoot()
        {
            Vector2 offset = (EnemySO.ShootOffset * NormalizedDirection);
            Vector3 position = new Vector3(transform.position.x + offset.x,
                transform.position.y + offset.y, transform.position.z);
            var go = UnityEngine.Object.Instantiate(BulletPrefab, position, Quaternion.identity, null);

            go.GetComponent<TankBullet>().SetDirection(NormalizedDirection);
        }
        public void InitializeSpawnTerritory(MoveTerritory moveTerritory)
        {
            SpawnTerritory = moveTerritory;
        }
    }
}