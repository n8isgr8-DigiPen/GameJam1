using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerup : PowerupBase
{
    //adds a new bullet spawn for 5 seconds
    public override void Pickup()
    {
        PlayerManager.AddBullet(5f);
    }
}
