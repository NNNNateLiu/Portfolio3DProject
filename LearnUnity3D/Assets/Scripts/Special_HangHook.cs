using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_HangHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hook_specialObject;
    
    public void additionalTriggerEvent()
    {
        hook.SetActive(true);
        hook_specialObject.SetActive(true);
    }
}
