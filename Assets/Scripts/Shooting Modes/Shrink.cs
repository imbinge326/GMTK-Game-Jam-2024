using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : ShootingModes
{
    [Header("Settings")]
    [SerializeField] private float baseShrinkSize = 0.9f;

    private bool shrink;

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
            playerController.ShrinkShoot(baseShrinkSize);
            canShoot = false;
            StartCoroutine(StartCooldown());
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
}
