using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerup : PowerupBase
{
    public override void Pickup()
    {
        PlayerManager.AddBullet(5f);
    }
}
