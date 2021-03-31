using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float range = 3f;
    [SerializeField] private float timeBetweenAttacks = 1f;

    [SerializeField] private Animator anim;
    [SerializeField] private EnemyMove enemyMove;
    EnemyHealth enemyHealth;
    private GameObject player;
    public bool playerInRange;
    [SerializeField] private BoxCollider[] weaponColliders;
    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
        weaponColliders = GetComponentsInChildren<BoxCollider>();
        player = GameManager.instance.Player;
        anim = GetComponentInChildren<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyMove.target != null && enemyHealth.IsAlive)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < range)
            {
                StartCoroutine(Attack());
                playerInRange = true;
                anim.SetBool("isRunning", false);
                

            }
            else
            {
                anim.SetBool("isRunning", true);
                playerInRange = false;
            }
            //print(playerInRange);
        }
        
        
    }
    IEnumerator Attack()
    {
        if (!GameManager.instance.GameOver && playerInRange)
        {
            //print("zombie");
            anim.Play("Zombie Attack", 1);
            
            yield return new WaitForSeconds(timeBetweenAttacks);
            //print("hit");
        }
        else if (GameManager.instance.GameOver)
        {
            anim.Play("Zombie Idle");
        }
        yield return null;
    }
}
