using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    public GameObject tagetPosition;

    private void Update()
    {
        //Invoke("MovetoTarget",4f);

        if (gameObject.GetComponent<NavMeshAgent>().velocity.magnitude > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("isWalking",true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isWalking",false);
        }
    }

    public void MovetoTarget()
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(tagetPosition.transform.position);
    }
}
