using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Aula10
{
    public class Player : MonoBehaviour
    {
        public MouseManager1 mouseManager;

        NavMeshAgent agent;
        Animator animator;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            mouseManager.OnMouseClickInteractable.AddListener(Move);
        }

        private void Update()
        {
            animator.SetFloat("Speed", agent.velocity.magnitude); 
        }

        private void OnDestroy()
        {
            mouseManager.OnMouseClickInteractable.RemoveListener(Move);
        }

        public void Move(Vector3 point)
        {
            agent.SetDestination(point);
        }
    }
}