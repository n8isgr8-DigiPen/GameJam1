/*
Name: Nate Stern
Date: 11/6/20
Desc: Powerup that adds a speed boost for 3 seconds on pcikup
*/
public class HomingPowerup : PowerupBase
{
    //add homing effect for 3 seconds
    public override void Pickup()
    {
        PlayerManager.HomingEndTime = 3f;
    }
}
