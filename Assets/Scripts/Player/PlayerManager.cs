/*
Name: Nate Stern
Date: 11/5/20
Desc: Manages The Powerups through a static class with calculations and accessors.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
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
        if (homingTimeLeft < 0)
        {
            homingTimeLeft = 0;
        }
        lastHomingCheckTime = Time.time;
        return homingTimeLeft;
    }

    /// <summary>
    /// should the player shoot a homing bullet or not
    /// </summary>
    public static bool UseHomingBullets
    {
        get => HomingEndTime > Time.time;
    }
    #endregion

    #region SpeedBoost

    //Time in seconds until speed effect wears off
    private static float speedTimeLeft;

    //Last Time that speed was checked for manual calculation of time
    private static float lastSpeedCheckTime = 0;

    /// <summary>
    /// gets and sets the time the speed powerup will end.
    /// <para>GET: gets the time that speed will run out from beginning of game </para>
    /// <para>(calculated from beginning of game use Time.time to find seconds since beginning of game)</para>
    /// <para>SET: additional seconds to add to the speed timer</para>
    /// </summary>
    public static float SpeedEndTime
    {
        set => speedTimeLeft += value;
        get => GetSpeedTimeLeft() + Time.time;
    }

    /// <summary>
    /// Calculates the time remaining on the speed powerup
    /// </summary>
    public static float GetSpeedTimeLeft()
    {
        if (lastSpeedCheckTime == 0)
        {
            lastSpeedCheckTime = Time.time;
        }
        speedTimeLeft -= (Time.time - lastSpeedCheckTime);
        if (speedTimeLeft < 0)
        {
            speedTimeLeft = 0;
        }
        lastSpeedCheckTime = Time.time;
        return speedTimeLeft;
    }

    public static float PlayerSpeed
    {
        get => SpeedEndTime > Time.time ? 16 : 10;
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
        int count = 1;
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
