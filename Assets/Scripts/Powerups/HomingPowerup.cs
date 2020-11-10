using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingPowerup : PowerupBase
{
    //add homing effect fof 3 seconds
    public override void Pickup()
    {
        PlayerManager.HomingEndTime = 3f;
    }
}
