using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class ReadableObject : MonoBehaviour
{
    public GameObject uiPrompt; // 在 Inspector 中拖入你的 UI 面板或 Text
    public GameObject uiReadableContent;

    private void Start()
    {
        if (uiPrompt != null) uiPrompt.SetActive(false); // 默认隐藏
    }

    private void OnTriggerEnter(Collider other)
    {
        // 检测进入的是否为玩家
        if (other.CompareTag("Player"))
        {
            if (uiPrompt != null) uiPrompt.SetActive(true);
            other.GetComponent<PlayerInteraction>().canInteract = true;
            other.GetComponent<PlayerInteraction>().currentInteractingObject = this.gameObject;
            Debug.Log("Player Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 检测离开的是否为玩家
        if (other.CompareTag("Player"))
        {
            if (uiPrompt != null) uiPrompt.SetActive(false);
            other.GetComponent<PlayerInteraction>().canInteract = false;
            other.GetComponent<PlayerInteraction>().currentInteractingObject = null;
            Debug.Log("Player Exit");
        }
    }
}
*/
public class ReadableObject : MonoBehaviour
{
    public GameObject uiPrompt; // UI 提示
    public GameObject uiReadableContent;

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
}