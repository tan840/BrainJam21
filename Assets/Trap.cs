using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trap : MonoBehaviour
{

    public int SoalCount = 0;
    public int maxSoulCount = 0;

    private void Update()
    {
        if (SoalCount >= maxSoulCount) {
          //  SceneManager.instance.LoadNextScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy") {

            Destroy(col.gameObject);
            SoalCount++;
            Debug.Log(SoalCount);
        }
        else if (col.gameObject.tag == "Player")
        {
           GameObject temp = col.gameObject.GetComponent<PlayerController>().deadBody;
            Destroy(temp);
            col.gameObject.GetComponent<PlayerController>().deadBody = null;
            col.gameObject.GetComponent<PlayerController>().enemy.text = "";
        }
    }
}
