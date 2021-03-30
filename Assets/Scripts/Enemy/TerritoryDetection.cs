using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryDetection : MonoBehaviour
{
    private EnemyMove enemyParent;


    private void Start()
    {
        enemyParent = GetComponentInParent<EnemyMove>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            enemyParent.target = other.transform;

        }
    }
 


}