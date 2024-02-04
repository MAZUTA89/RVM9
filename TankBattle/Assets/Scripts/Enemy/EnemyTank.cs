using Assets.Scripts.Enemy.StateMachine;
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
        public NavMeshAgent Agent {  get; protected set; }
        public Animator Animator { get; private set; }
        protected TankStateMachine TankStateMachine;
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

        public abstract void OnStart();
        public abstract void InitializeStateMachine();
    }
}