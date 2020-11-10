using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerupBase
{
    public override void Pickup()
    {
        PlayerManager.PlayerHealth.updateHealth(50);
    }
}
