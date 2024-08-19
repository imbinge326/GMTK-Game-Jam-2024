using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : ShootingModes
{
    [Header("Settings")]
    [SerializeField] private float baseShrinkSize = 0.9f;

    private bool shrink;
    public GameObject muzzleFlash;

    protected override void InitState()
    {
        base.InitState();
    }
    
    public override void ExecuteMode()
    {
        ShrinkObject();
    }

    private void ShrinkObject()
    {
        if (shrink && canShoot && playerController.magazine > 0 && !reloading)
        {
            muzzleFlash.SetActive(true);
            playerController.ShrinkShoot(baseShrinkSize);
            canShoot = false;
            StartCoroutine(DeactivateMuzzleFlash());
            StartCoroutine(StartCooldown());

            soundManager.EmitSound(4, transform);
            playerController.magazine--;
        }
        
        if(playerController.magazine <= 0 && !reloading)
        {
            Reload(reloadTime);
        }
    }

    protected override void GetInput()
    {
        shrink = rightMouseClick;
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
