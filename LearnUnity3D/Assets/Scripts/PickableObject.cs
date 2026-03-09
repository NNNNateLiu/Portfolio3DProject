using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public GameObject uiPrompt; // 在 Inspector 中拖入你的 UI 面板或 Text

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
            Debug.Log("Player Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 检测离开的是否为玩家
        if (other.CompareTag("Player"))
        {
            if (uiPrompt != null) uiPrompt.SetActive(false);
            Debug.Log("Player Exit");
        }
    }
}