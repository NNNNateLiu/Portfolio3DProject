using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_HangRope : MonoBehaviour
{
    public GameObject rope;
    public GameObject readableObject_Act1Finish;
    
    public void additionalTriggerEvent()
    {
        rope.SetActive(true);
        readableObject_Act1Finish.SetActive(true);
    }
}
