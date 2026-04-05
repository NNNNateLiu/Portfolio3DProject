using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialObject : MonoBehaviour
{
    public GameObject uiPrompt; // 在 Inspector 中拖入你的 UI 面板或 Text
    public string requiredItemName;
    public GameObject additionalSpecialObject;

    private void Start()
    {
        if (uiPrompt != null) uiPrompt.SetActive(false); // 默认隐藏
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiPrompt != null) uiPrompt.SetActive(true);

            PlayerInteraction pi = other.GetComponent<PlayerInteraction>();
            if (pi != null && !pi.interactableObjects.Contains(this.gameObject))
            {
                pi.interactableObjects.Add(this.gameObject);
            }

            Debug.Log("Player Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiPrompt != null) uiPrompt.SetActive(false);

            PlayerInteraction pi = other.GetComponent<PlayerInteraction>();
            if (pi != null && pi.interactableObjects.Contains(this.gameObject))
            {
                pi.interactableObjects.Remove(this.gameObject);
            }

            Debug.Log("Player Exit");
        }
    }
    public void specialObjectInteractEvent(BackpackUI backpackUI)
    {
        if (backpackUI.itemNames.Count == 0)
        {
            Debug.Log("Do not have required item to interact with");
        }

        for (int i = 0; i < 5; i++)
        {
            if (backpackUI.itemNames[i] == requiredItemName)
            {
                Debug.Log("Special Object Interacted, item removed");
                backpackUI.itemNames.Remove(backpackUI.itemNames[i]);
                backpackUI.itemSlots[i].GetComponent<Image>().sprite = null;
                triggerAdditionalEvent();
                break;
            }
            else
            {
                Debug.Log("Do not have required item to interact with");
            }
        }
    }

    private void triggerAdditionalEvent()
    {
        switch (requiredItemName)
        {
            case "Torch":
                additionalSpecialObject.GetComponent<Special_TorchStrawPile>().additionalTriggerEvent();
                Destroy(gameObject);
                break;
            
            default:
                break;
        }
    }
}
