using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
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
*/
public class PlayerInteraction : MonoBehaviour
{
    public List<GameObject> interactableObjects = new List<GameObject>();
    public GameObject currentInteractingObject;

    public BackpackUI backpackUI;

    void Update()
    {
        UpdateCurrentObject();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractingObject == null)
            {
                Debug.Log("there is nothing to be picked up");
                return;
            }

            InteractWithObject();
        }
    }

    // ===== ���ģ���̬ѡ��������� =====
    void UpdateCurrentObject()
    {
        float minDistance = float.MaxValue;
        GameObject closest = null;

        foreach (GameObject obj in interactableObjects)
        {
            if (obj == null) continue;

            float dist = Vector3.Distance(transform.position, obj.transform.position);

            if (dist < minDistance)
            {
                minDistance = dist;
                closest = obj;
            }
        }

        currentInteractingObject = closest;
    }

    void InteractWithObject()
    {
        if (currentInteractingObject == null) return;

        PickableObject pickable = currentInteractingObject.GetComponent<PickableObject>();
        ReadableObject readable = currentInteractingObject.GetComponent<ReadableObject>();
        SpecialObject special = currentInteractingObject.GetComponent<SpecialObject>();

        //handle pickable object interact event
        if (pickable != null)
        {
            for (int i = 0; i < backpackUI.itemSlots.Count; i++)
            {
                Image img = backpackUI.itemSlots[i].GetComponent<Image>();

                if (img.sprite == null)
                {
                    img.sprite = pickable.itemUIImage;
                    backpackUI.itemNames[i] = pickable.itemName;
                    

                    // ���б��Ƴ�
                    interactableObjects.Remove(currentInteractingObject);

                    Destroy(currentInteractingObject);

                    currentInteractingObject = null;

                    return;
                }
            }
        }

        //handle readable object interact event
        if (readable != null)
        {
            readable.uiReadableContent.SetActive(true);
            SetCursorState(false);
        }
        
        //handle special object interact event
        if (special != null)
        {
            special.specialObjectInteractEvent(backpackUI);
        }
    }

    // ===== ������ά���б� =====
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickableObject>() != null ||
            other.GetComponent<ReadableObject>() != null ||
            other.GetComponent<SpecialObject>() != null)
        {
            if (!interactableObjects.Contains(other.gameObject))
                interactableObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactableObjects.Contains(other.gameObject))
        {
            interactableObjects.Remove(other.gameObject);
        }
    }

    public void SetCursorState(bool newState)
    {
        if (newState)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}