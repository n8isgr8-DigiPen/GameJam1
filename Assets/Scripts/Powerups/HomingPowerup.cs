using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingPowerup : PowerupBase
{
    public override void Pickup()
    {
        PlayerManager.HomingEndTime = 3f;
    }
}
