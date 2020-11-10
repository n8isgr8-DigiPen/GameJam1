using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : PowerupBase
{
    
    public override void Pickup()
    {
        PlayerManager.SpeedEndTime = 4f;
    }
}
