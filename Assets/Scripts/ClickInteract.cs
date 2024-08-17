using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickInteract : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Camera mainCamera;
    public UnityEvent unityEvent;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        mainCamera = Camera.main;
    }

    public void Update()
    {
        var cursorPosition = mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}
