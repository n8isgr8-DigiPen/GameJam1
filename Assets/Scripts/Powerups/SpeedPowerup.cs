/*
Name: Nate Stern
Date: 11/6/20
Desc: Powerup that adds a speed boost for 3 seconds on pickup
*/
public class SpeedPowerup : PowerupBase
{
    //add speed on pickup
    public override void Pickup()
    {
        PlayerManager.SpeedEndTime = 3f;
    }
}
