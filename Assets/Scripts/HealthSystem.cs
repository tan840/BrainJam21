using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    [SerializeField] float timeDelayHit = 2f;

    private float timer;
    private CharacterController characterController;
    private Animator anim;
    [SerializeField] int currentHealth;

    [SerializeField] Image uiHealthPReivew;


    private void OnEnable()
    {
        anim.SetBool("Dead", false);
        currentHealth += startingHealth;
    }
    private void Start()
    {
        
        uiHealthPReivew.GetComponent<Image>();
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

       
    }
    
    private void Update()
    {
        timer += Time.deltaTime;


       
        uiHealthPReivew.fillAmount = currentHealth / 100f;
        

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
            anim.Play("Big Hit To Head");
        }
        if (currentHealth<=0)
        {
            Debug.Log("LOL");
            
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        
        
        GameManager.instance.PlayerHit(0f);
        //play death animation
       
        Debug.Log("THE PLAYER HAS DIED!!!");
        //anim.Play("Head Hit");
        anim.SetBool("Dead", true);
        characterController.enabled = false;
    }

}
