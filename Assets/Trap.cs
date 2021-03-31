using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trap : MonoBehaviour
{

    public int SoulCount = 0;
    public int maxSoulCount = 0;
    [SerializeField] GameObject particleEffectSplash;
    /// <summary>
    /// This class is used to count the number of body sacrificed in the circle
    /// </summary>

    private void Update()
    {
        if (SoulCount >= maxSoulCount) {
          //  SceneManager.instance.LoadNextScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy") {

            Destroy(col.gameObject);
            SoulCount++;
            particleEffectSplash.SetActive(true);
            Invoke("ParticleSlashDeactive", 3);


        }
        else if (col.gameObject.tag == "Player")
        {
           GameObject temp = col.gameObject.GetComponent<PlayerController>().deadBody;
            if (temp != null)
            {
                Destroy(temp);
                col.gameObject.GetComponent<PlayerController>().deadBody = null;
                col.gameObject.GetComponent<PlayerController>().enemy.text = "";
                particleEffectSplash.SetActive(true);
                Invoke("ParticleSlashDeactive", 3);
            }
            
        }
    }
    void ParticleSlashDeactive()
    {
        particleEffectSplash.SetActive(false);
    }
}
