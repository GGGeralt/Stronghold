using GGGeralt.Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CreatureAI : MonoBehaviour
{
    [SerializeField] int sightRange;
    [SerializeField] int attackRange;

    [SerializeField] bool playerInSightRange = false;
    [SerializeField] bool playerInAttackRange = false;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int walkPointRange;
    [SerializeField] bool walkPointSet = false;

    Vector3 walkPoint;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
    }

    private void FixedUpdate()
    {
        if (playerInSightRange == false && playerInAttackRange == false)
        {
            Patrolling();
        }
        if (playerInSightRange && playerInAttackRange == false)
        {
            Chase();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            Attack();
        }
    }

    void Patrolling()
    {
        if (walkPointSet == false)
        {
            SearcgWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    void Chase()
    {
        agent.SetDestination(Player.Instance.transform.position);
    }
    void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(Player.Instance.transform.position);
    }


    void SearcgWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
        {
            walkPointSet = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
    }
}
