using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform target;


    [SerializeField] private NavMeshAgent navMesh;
    private Animator anim;

    /// <summary>
    /// Movement for the enemy zombies
    /// </summary>
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        navMesh = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (target == null)
        {
            anim.Play("Zombie Idle");
        }
        if (target!=null)
        {
            if (!GameManager.instance.GameOver && navMesh.enabled == true)
            {
                navMesh.SetDestination(target.position);
            }
            else
            {
                navMesh.enabled = false;
                // play Idle Animation
            }
            
        }
    }
}
