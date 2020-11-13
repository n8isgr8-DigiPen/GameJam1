using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : PowerupBase
{
    //add speed on pickup
    public override void Pickup()
    {
        PlayerManager.SpeedEndTime = 3f;
    }
}
