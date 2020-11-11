using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
Date: 11/8/2020
Desc: Powerup Dropping
*/
public class Drop : MonoBehaviour
{
    [Tooltip("What powerups can spawn?")]
    public GameObject[] Powerups;
    [Tooltip("Percent chance to drop")]
    public float ChanceToDrop = 20;
    [Tooltip("How long should it exist? (0 for infinite)")]
    public float PowerUpLifeSpan;

    public void dropPowerUp()
    {
        if(Random.value > 1.0 - (ChanceToDrop / 100))
        {
            GameObject g = Instantiate(Powerups[Random.Range(0, Powerups.Length - 1)], transform.position, Quaternion.identity);
            if(PowerUpLifeSpan > 0)
            {
                Destroy(g, PowerUpLifeSpan);
            }

        }
    }
}
