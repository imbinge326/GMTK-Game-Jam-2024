using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : ShootingModes
{
    [Header("Settings")]
    [SerializeField] private float shrinkSize;
    
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float shotCooldown = 0.25f;

    private bool shoot;

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
        if (shoot && canShoot)
        {
            playerController.ShrinkShoot();
            canShoot = false;
            StartCoroutine(StartCooldown());
        }
    }

    protected override void GetInput()
    {
        shoot = rightMouseClick;
    }

        IEnumerator StartCooldown()
    {
        //cooldown between each shot
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }
}
