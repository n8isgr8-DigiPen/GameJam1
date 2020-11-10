using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : PowerupBase
{
    //adds 15 health on pickup
    public override void Pickup()
    {
        PlayerManager.PlayerHealth.updateHealth(15);
    }
}
