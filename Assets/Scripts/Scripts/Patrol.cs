using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform player;
    public float mindist = 2f;
    public List<Point> lstPoints;
    NavMeshAgent agent;
    Animator animator;
    public bool ispursuing = false;

    int indexSorteado = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


        agent.SetDestination(lstPoints[indexSorteado].transform.position);

        for (int x = 0; x < lstPoints.Count; x++)
        {
            lstPoints[x].index = x;
        }
        
    }
    private void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if(dist < mindist)
        {
            Pursuit();
        }
        else
        {
            Patrulha();
        }
    }


    private void Patrulha()
    {
        agent.SetDestination(lstPoints[indexSorteado].transform.position);
    }
    private void Pursuit()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        agent.SetDestination(player.position);
        ispursuing = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Points"))
        {
            
            while (other.GetComponent<Point>().index == indexSorteado)
            {
                indexSorteado++;
                if (indexSorteado >= lstPoints.Count)
                {
                    indexSorteado = 0;
                }
                agent.SetDestination(lstPoints[indexSorteado].transform.position);
                
            }
            
        }
        

    }
    
}
