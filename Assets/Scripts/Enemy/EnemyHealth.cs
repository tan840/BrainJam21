 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingEnemyHealth = 50;
    [SerializeField] float timeBetweenAttack = 1f;

    float timer = 0f;
    Animator anim;
    NavMeshAgent navMesh;
    Rigidbody rigidbody;
    
    bool isAlive;
    public bool IsAlive
    {
        get { return isAlive; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (timer >= timeBetweenAttack && !GameManager.instance.gameObject)
        {
            if (other.tag == "PlayerWeapon")
            {

            }
        }
    }
}
