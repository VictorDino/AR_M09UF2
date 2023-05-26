using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackAndMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    private GameObject target;
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float attackRange = 2f;
    [SerializeField]
    private float attackCooldown = 4f;

    private bool canAttack = true;
    private float attackTimer;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveAndAttackTarget();
    }

    private void MoveAndAttackTarget()
    {
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        agent.SetDestination(target.transform.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
        }

        if (canAttack && distanceToTarget <= attackRange)
        {
            anim.SetBool("IsAttacking", true);
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);

            canAttack = false;
            attackTimer = Time.time;
        }
        else if (Time.time - attackTimer >= attackCooldown)
        {
            canAttack = true;
            anim.SetBool("IsAttacking", false); 
        }
    }

    private void RotateToTarget()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = PlayerHealth.instance;
    }
}
