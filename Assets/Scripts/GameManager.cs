using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] GameObject player;
    private bool gameOver = false;

    //public float maxSoulCount;
    public bool GameOver
    {
        get { return gameOver; }
    }
    public GameObject Player
    {
        get { return player; }
    }



    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayerHit(float currentHealth)
    {
        if (currentHealth>0)
        {
            gameOver = false;

        }
        else
        {
            gameOver = true;
        }
    }
}
