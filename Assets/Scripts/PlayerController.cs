using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float turnSmoothTime= 0.1f;
    [SerializeField] float turnSmoothVelocity;


    CharacterController characterController;
    [SerializeField]Animator anim;
    [SerializeField] float rayCastRange = 100f;
    [SerializeField] BoxCollider swordCollider;

    public GameObject ParticleSlashEffect;
    public GameObject rayCastPoint;
    public bool grabbedEnemy;
    public GameObject deadBody;
    public Transform cam;

    [SerializeField] Text enemy;

    private void Start()
    {
        enemy.enabled = false;
        characterController = GetComponent<CharacterController>();
        swordCollider = GetComponentInChildren<BoxCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
              
        if (!GameManager.instance.GameOver)
        {
            MovePlayer();
            if (Input.GetMouseButton(0) )
            {
                    Attack();
                
               
                
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                GrabEnemyBody();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReleaseEnemy();
            }
        }
        
    }

    void ReleaseEnemy()
    {
        deadBody.transform.SetParent(null);
    }

    void GrabEnemyBody()
    {
        Ray ray = new Ray(rayCastPoint.transform.position, rayCastPoint.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayCastRange))
        {
            if (hit.collider.tag == "Enemy")
            {
                enemy.enabled = true;
                deadBody = hit.transform.gameObject;
                grabbedEnemy = true;
                deadBody.transform.SetParent(this.transform);
                deadBody.GetComponent<Rigidbody>().isKinematic = true;
                deadBody.GetComponent<Rigidbody>().useGravity = false;
            }
            else {


                enemy.enabled = false;
            
            }
            
        }

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
            float targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle,0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.SimpleMove(moveDir.normalized * moveSpeed );
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

    void SwordColliderOn()
    {
        swordCollider.enabled = true;
    }
    void SwordColliderOff()
    {
        swordCollider.enabled = false;
    }
 
}
