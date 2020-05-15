using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterExit : MonoBehaviour
{
    EnemyMoveOnTrigger enemyTrigger;

    private void Start()
    {
        enemyTrigger = GetComponentInParent<EnemyMoveOnTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if(other.gameObject.CompareTag("Player"))
        {
            enemyTrigger.SetShouldMove(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);

        if (other.gameObject.CompareTag("Player"))
        {
            enemyTrigger.SetShouldMove(true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);

        if (other.gameObject.CompareTag("Player"))
        {
            enemyTrigger.SetShouldMove(true);
        }
    }
}
