using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModes : MonoBehaviour
{
    protected PlayerController playerController;
    protected bool leftMouseClick;
    protected bool rightMouseClick;
    // Start is called before the first frame update
    void Start()
    {
        InitState();
    }

    protected virtual void InitState()
    {
        playerController = GetComponent<PlayerController>();
    }
    // Override to execute current mode
    public virtual void ExecuteMode()
    {

    }

    public virtual void LocalInput()
    {
        leftMouseClick = Input.GetMouseButtonDown(0);
        rightMouseClick = Input.GetMouseButtonDown(1);

        GetInput();
    }

    // Override to support other Inputs
    protected virtual void GetInput()
    {

    }
}
