using GGGeralt.Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum Focus
{
    Player,
    Crystal,
}

[RequireComponent(typeof(NavMeshAgent))]
public class CreatureAI : MonoBehaviour
{
    [SerializeField] int sightRange;
    [SerializeField] int attackRange;

    [SerializeField] bool focusInSightRange = false;
    [SerializeField] bool focusInAttackRange = false;
    [SerializeField] Focus focus;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask crystalLayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int walkPointRange;
    [SerializeField] bool walkPointSet = false;

    Vector3 walkPoint;

    NavMeshAgent agent;
    LayerMask focusLayer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        switch (focus)
        {
            case Focus.Player:
                focusLayer = playerLayer;
                break;
            case Focus.Crystal:
                focusLayer = crystalLayer;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        focusInSightRange = Physics.CheckSphere(transform.position, sightRange, focusLayer);
        focusInAttackRange = Physics.CheckSphere(transform.position, attackRange, focusLayer);
    }

    private void FixedUpdate()
    {
        if (focusInSightRange == false && focusInAttackRange == false)
        {
            Patrolling();
        }
        if (focusInSightRange && focusInAttackRange == false)
        {
            Chase();
        }
        if (focusInSightRange && focusInAttackRange)
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
        switch (focus)
        {
            case Focus.Player:
                agent.SetDestination(Player.Instance.transform.position);
                break;
            case Focus.Crystal:
                agent.SetDestination(NexusCrystal.Instance.transform.position);
                break;
            default:
                break;
        }
    }
    void Attack()
    {
        agent.SetDestination(transform.position);
        switch (focus)
        {
            case Focus.Player:
                transform.LookAt(Player.Instance.transform.position);
                break;
            case Focus.Crystal:
                transform.LookAt(NexusCrystal.Instance.transform.position);
                break;
            default:
                break;
        }
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
