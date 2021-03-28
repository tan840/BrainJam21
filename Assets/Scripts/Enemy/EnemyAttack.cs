using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float range = 3f;
    [SerializeField] private float timeBetweenAttacks = 1f;

    [SerializeField] private Animator anim;
    private GameObject player;
    private bool playerInRange;
    [SerializeField] private BoxCollider[] weaponColliders;
    void Start()
    {
        weaponColliders = GetComponentsInChildren<BoxCollider>();
        player = GameManager.instance.Player;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            playerInRange = true;
            StartCoroutine(Attack());
        }else
        {
            playerInRange = false;
        }
        print(playerInRange);
    }
    IEnumerator Attack()
    {
        if (playerInRange && !GameManager.instance.GameOver)
        {
            anim.Play("Zombie Attack");
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
        yield return null;
    }
}
