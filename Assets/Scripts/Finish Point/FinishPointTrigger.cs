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
        if (other.CompareTag("Player"))
        {
            cameraScript.canFollow = false;
        }
    }
}
