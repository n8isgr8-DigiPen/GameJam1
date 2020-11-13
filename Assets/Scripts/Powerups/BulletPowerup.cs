/*
Name: Nate Stern
Date: 11/6/20
Desc: Powerup that adds an additional bullet for 5 seconds on pickup
*/
public class BulletPowerup : PowerupBase
{
    //adds a new bullet spawn for 5 seconds
    public override void Pickup()
    {
        PlayerManager.AddBullet(5f);
    }
}
