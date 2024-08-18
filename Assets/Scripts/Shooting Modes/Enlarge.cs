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

    protected override void InitState()
    {
        base.InitState();
    }

    public override void ExecuteMode()
    {
        EnlargeObject();
    }

    private void EnlargeObject()
    {
        if (enlarge && canShoot && playerController.magazine > 0 && !reloading)
        {
            playerController.EnlargeShoot(baseEnlargeSize);
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
        enlarge = leftMouseClick;
    }

    IEnumerator StartCooldown()
    {
        //cooldown between each shot
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }

}
