using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointTrigger : MonoBehaviour
{
    CameraFollow cameraScript;
    public Camera mainCamera;

    private void Start()
    {
        cameraScript = mainCamera.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gay1");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gay2");
            cameraScript.canFollow = false;
        }
    }
}
