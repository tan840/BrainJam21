using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform target;


    [SerializeField] private NavMeshAgent navMesh;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (target!=null)
        {
            
            navMesh.SetDestination(target.position);
        }
    }
}
