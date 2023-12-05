using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

        transform.up = direction;
    }
}
