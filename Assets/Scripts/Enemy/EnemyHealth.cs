 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingEnemyHealth = 50;
    [SerializeField] float timeBetweenAttack = 1f;
    public HealthSystem plrHealth;
    float timer = 0f;
    Animator anim;
    EnemyAttack enemyAttack;
    NavMeshAgent navMesh;
    Rigidbody rigidbody;
    [SerializeField] CapsuleCollider enemyCollider;
    [SerializeField] SphereCollider territory;
    [SerializeField] CapsuleCollider deadCollider;
    [SerializeField] BoxCollider[] weaponHand;
    [SerializeField] float currentHealth;


    bool isAlive;
    public bool IsAlive
    {
        get { return isAlive; }
    }

    /// <summary>
    /// Enemy health System 
    /// </summary>
    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        anim = GetComponentInChildren<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = startingEnemyHealth;
        enemyCollider = GetComponent<CapsuleCollider>();
        territory = GetComponentInChildren<SphereCollider>();
        

        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (timer >= timeBetweenAttack && !GameManager.instance.GameOver)
        {
            if (other.tag == "PlayerWeapon" && enemyAttack.playerInRange)
            {
                print("playerweapon");
                timer = 0f;
                TakeHit();
            }
        }
    }
    void TakeHit()
    {
        if (currentHealth > 0)
        {
            isAlive = false;
            //anim.Play("Big Hit To Head");
            currentHealth -= 10;
        }
        if (currentHealth <= 0)
        {
            
            KillEnemy();
            isAlive = false;
            
        }
    }
    void KillEnemy()
    {
        SoundManager.instance.Play("Dead");
        enemyCollider.enabled = false;
        territory.enabled = false;
        
        Invoke("ColliderAfterDeathEnable", 2f);

        //navMesh.enabled = false;
        // enemy dead animation
        anim.SetBool("isDead",true);
        //print("dead");
        navMesh.enabled = false;
        WeaponColliderAfterDeathEnable();


    }
    public void ColliderAfterDeathEnable()
    {
        deadCollider.enabled = true;
    }

    public void WeaponColliderAfterDeathEnable()
    {
        foreach (BoxCollider item in weaponHand)
        {
            item.enabled = false;
            //print("collider off");
        }
    }
}
