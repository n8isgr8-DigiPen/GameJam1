using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingPowerup : PowerupBase
{
    //add homing effect for 3 seconds
    public override void Pickup()
    {
        PlayerManager.HomingEndTime = 3f;
    }
}
