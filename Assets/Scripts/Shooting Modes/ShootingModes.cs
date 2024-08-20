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
    protected bool reload;

    protected float autoReloadTime = 2.5f;
    protected float manualReloadTime = 1.5f;
    protected float shotCooldown = 0.25f;

    void Start()
    {
        InitState();
        soundManager = GameObject.Find("Sound Emitter").GetComponent<SoundManager>();
    }

    protected virtual void InitState()
    {
        playerController = GetComponent<PlayerController>();
        autoReloadTime = 2.5f;
        manualReloadTime = 1.5f;
        shotCooldown = 0.25f;
        canShoot = true;
    }
    // Override to execute current mode
    public virtual void ExecuteMode()
    {
        if (reload && playerController.magazine != 7)
        {
            Reload(5, manualReloadTime);
        }
    }

    public virtual void LocalInput()
    {
        leftMouseClick = Input.GetMouseButtonDown(0);
        rightMouseClick = Input.GetMouseButtonDown(1);
        reload = Input.GetKey(KeyCode.R);

        GetInput();
    }

    // Override to support other Inputs
    protected virtual void GetInput()
    {

    }

    protected virtual void Reload(int reloadSoundNum, float reloadTime)
    {
        reloading = true;
        soundManager.EmitSound(reloadSoundNum, playerController.transform);
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
