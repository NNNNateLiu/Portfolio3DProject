using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public bool canInteract = false;
    public GameObject currentInteractingObject;
    
    public BackpackUI backpackUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canInteract == true)
            {
                Debug.Log("pick up current pickable Object");
                InteractWithObject();
            }
            else
            {
                Debug.Log("there is nothing to be picked up");
            }
        }
    }

    void InteractWithObject()
    {
        if (currentInteractingObject.GetComponent<PickableObject>() != null)
        {
            for (int i = 0; i < backpackUI.itemSlots.Count; i++)
            {
                if (backpackUI.itemSlots[i].GetComponent<Image>().sprite == null)
                {
                    backpackUI.itemSlots[i].GetComponent<Image>().sprite =
                        currentInteractingObject.GetComponent<PickableObject>().itemUIImage;
                    Destroy(currentInteractingObject);
                    break;
                }
            }
        }

        if (currentInteractingObject.GetComponent<ReadableObject>() != null)
        {
            currentInteractingObject.GetComponent<ReadableObject>().uiReadableContent.SetActive(true);
            SetCursorState(false);
        }
    }
    
    public void SetCursorState(bool newState)
    {
        if (newState == true)
        {
            //Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            //Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
