﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    [SerializeField] float timeDelayHit = 2f;

    private float timer;
    private CharacterController characterController;
    private Animator anim;
    [SerializeField] int currentHealth;

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
        timer += Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer>= timeDelayHit && !GameManager.instance.GameOver)
        {
            if (other.tag =="Weapon")
            {
                TakeHit();
                timer = 0f;
            }
        }
    }
    void TakeHit()
    {
        if (currentHealth>0)
        {
            currentHealth -= 10;
            GameManager.instance.PlayerHit(currentHealth);
            //TODO::play player take hit animation
            
        }
        else if (currentHealth<=0)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        GameManager.instance.PlayerHit(0f);
        //play death animation
        characterController.enabled = false;
    }

}