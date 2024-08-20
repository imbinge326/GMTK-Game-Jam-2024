using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enlarge : ShootingModes
{
    [Header("Settings")]
    [SerializeField] private float baseEnlargeSize = 1.1f;

    private bool enlarge;
    public GameObject muzzleFlash;

    protected override void InitState()
    {
        base.InitState();
    }

    public override void ExecuteMode()
    {
        base.ExecuteMode();
        EnlargeObject();
    }

    private void EnlargeObject()
    {
        if (enlarge && canShoot && playerController.magazine > 0 && !reloading)
        {
            muzzleFlash.SetActive(true);
            playerController.EnlargeShoot(baseEnlargeSize);
            canShoot = false;
            StartCoroutine(DeactivateMuzzleFlash());
            StartCoroutine(StartCooldown());

            soundManager.EmitSound(4, transform);
            playerController.magazine--;
        }  
            
        
        if(playerController.magazine <= 0 && !reloading)
        {
            Reload(3, autoReloadTime);
        }
    }

    protected override void GetInput()
    {
        enlarge = leftMouseClick;
    }

    IEnumerator StartCooldown()
    {
        //cooldown between each shot
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }

    IEnumerator DeactivateMuzzleFlash()
    {
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.SetActive(false);
    }

}
