using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float turnSmoothTime= 0.1f;
    [SerializeField] float turnSmoothVelocity;


    CharacterController characterController;
    [SerializeField]Animator anim;

    public GameObject ParticleSlashEffect;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            MovePlayer();
            if (Input.GetMouseButton(0))
            {
                Attack();
            }
        }
        
    }

    void GrabEnemyBody()
    {

    }

    private void Attack()
    {
        anim.Play("SwordAttack_1");


    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal,0f, vertical).normalized;

        if (direction.magnitude>0.2)
        {
            anim.SetBool("isRunning", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle,0f);
            characterController.SimpleMove(direction * moveSpeed );
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void SlashParticleBegin()
    {
        ParticleSlashEffect.SetActive(true);
    }
    void SlashParticleEnd()
    {
        ParticleSlashEffect.SetActive(false);
    }
}
