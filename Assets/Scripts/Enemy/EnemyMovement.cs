using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f; 
    public float detectionRange = 10.0f; 
    public float stoppingDistance = 2.0f; 

    private Transform target; 
    private bool playerDetected = false; 

    private Animator animator;

    private NavMeshAgent agent;


    //private Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
     {
         
         float distanceToTarget = Vector3.Distance(transform.position, target.position);
         animator.SetFloat("Velocity", 1);

        
        if (distanceToTarget < detectionRange)
         {
             playerDetected = true;

            
             if (distanceToTarget > stoppingDistance)
             {
                 transform.LookAt(target); 
                
                 agent.SetDestination(target.position);
            }
         }
         else
         {
             playerDetected = false;
         }

        
     }

}
