using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModes : MonoBehaviour
{
    protected SoundManager soundManager;
    protected PlayerController playerController;
    protected bool leftMouseClick;
    protected bool rightMouseClick;
    protected bool canShoot = true;
    protected bool reloading;

    protected float reloadTime = 1.5f;
    protected float shotCooldown = 0.25f;

    void Start()
    {
        InitState();
        soundManager = GameObject.Find("Sound Emitter").GetComponent<SoundManager>();
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

    protected virtual void Reload(float reloadTime)
    {
        reloading = true;
        soundManager.EmitSound(3, playerController.transform);
        StartCoroutine(StartCooldown(reloadTime));
    }

    IEnumerator StartCooldown(float reloadTime)
    {
        // Reload duration
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        playerController.magazine = 7;
    }
}
