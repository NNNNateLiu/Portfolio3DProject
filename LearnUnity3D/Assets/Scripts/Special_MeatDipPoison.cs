using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_MeatDipPoison : MonoBehaviour
{
    public GameObject poisonedMeat;
    
    public void additionalTriggerEvent()
    {
        poisonedMeat.SetActive(true);
    }
}
