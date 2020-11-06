using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager
{
    #region HomingBullets

    //Time in seconds until homing effect wears off
    private static float homingTimeLeft;

    //Last Time that homing was checked for manual calculation of time
    private static float lastHomingCheckTime = 0;

    /// <summary>
    /// gets and sets the time the homing powerup will end.
    /// <para>GET: gets the time that homing will run out from beginning of game </para>
    /// <para>(calculated from beginning of game use Time.time to find seconds since beginning of game)</para>
    /// <para>SET: additional seconds to add to the homing timer</para>
    /// </summary>
    public static float HomingEndTime
    {
        set => homingTimeLeft += value;
        get => GetHomingTimeLeft() + Time.time;
    }

    /// <summary>
    /// Calculates the time remaining on the homing powerup
    /// </summary>
    public static float GetHomingTimeLeft()
    {
        if(lastHomingCheckTime == 0)
        {
            lastHomingCheckTime = Time.time;
        }
        homingTimeLeft -= (Time.time - lastHomingCheckTime);
        lastHomingCheckTime = Time.time;
        return homingTimeLeft;
    }

    /// <summary>
    /// should the player shoot a homing bullet or not
    /// </summary>
    public static bool UseHomingBullets
    {
        get => Time.time > HomingEndTime ? false : true;
    }
    #endregion

    #region PlayerStats

    /// <summary>
    /// Static Reference to the player's health script
    /// </summary>
    public static Health PlayerHealth { get; set; }

    /// <summary>
    /// The player's current light level upgrade
    /// </summary>
    public static float PlayerLightLevel { get; set; }

    #endregion

    #region BulletCount

    /// <summary>
    /// A List of all the bullet's times to wear off
    /// </summary>
    private static List<float> bulletEndTimes = new List<float>();

    /// <summary>
    /// Get the bullet count for shooting a number of bullets
    /// </summary>
    public static int BulletCount
    {
        get => GetBulletCount();
    }

    /// <summary>
    /// Adds 1 bullet for a number of seconds
    /// </summary>
    /// <param name="seconds">Adds 1 bullet lasting for this amount of seconds</param>
    public static void AddBullet(float seconds)
    {
        bulletEndTimes.Add(Time.deltaTime + seconds);
    }

    /// <summary>
    /// Calculates the bullet count and removes any past time bullets from the bullet powerup end time list
    /// </summary>
    /// <returns>
    /// Returns current calculated bullet count
    /// </returns>
    private static int GetBulletCount()
    {
        int count = 0;
        foreach (float t in bulletEndTimes)
        {
            if (t > Time.deltaTime)
            {
                bulletEndTimes.Remove(t);
            }
            else
            {
                count++;
            }
        }
        return count;
    }
    #endregion

}
