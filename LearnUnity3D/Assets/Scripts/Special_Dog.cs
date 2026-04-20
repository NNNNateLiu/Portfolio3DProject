using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Dog : MonoBehaviour
{
    public GameObject poisonMeat_Model;
    public GameObject dog;
    
    public void additionalTriggerEvent()
    {
        poisonMeat_Model.SetActive(true);
        dog.GetComponent<Animator>().SetTrigger("eat");
        Invoke("finishEatting",10f);
    }

    private void finishEatting()
    {
       Destroy(poisonMeat_Model); 
    }
}
