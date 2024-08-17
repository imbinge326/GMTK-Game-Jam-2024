using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private ShootingModes[] shootingModes;

    private void Start()
    {
        shootingModes = GetComponents<ShootingModes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingModes.Length != 0)
        {
            foreach (ShootingModes mode in  shootingModes)
            {
                mode.LocalInput();
                mode.ExecuteMode();
            }
        }
    }
}
