/*
Name: Nate Stern
Date: 11/6/20
Desc: Powerup that adds 15 health on pickup
*/
public class HealthPowerup : PowerupBase
{
    //adds 15 health on pickup
    public override void Pickup()
    {
        PlayerManager.PlayerHealth.updateHealth(15);
    }
}
