using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void LateUpdate()
    {
        // 让 UI 始终背对相机（即正对镜头）
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}
