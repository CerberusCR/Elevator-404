using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    public int totalBalloons = 10; // Total number of balloons in the scene
    public GameObject keyReward; // The key reward object
    public Transform prizeSpawnPoint; // The spawn point for the key reward

    private int balloonsDestroyed = 0; // Counter for destroyed balloons

    // This method is called when a balloon is destroyed
    public void BalloonDestroyed()
    {
        balloonsDestroyed++;

        if (balloonsDestroyed >= totalBalloons)
        {
            // All balloons are destroyed, grant the key reward
            GrantKeyReward();
            Debug.Log("You got it!");
        }
    }

    private void GrantKeyReward()
    {
        // Instantiate the key reward object at the prizeSpawnPoint position
        Instantiate(keyReward, prizeSpawnPoint.position, prizeSpawnPoint.rotation);

        // You can also perform additional actions here, like playing a sound or displaying a message

        // Disable this script to prevent further rewards if more balloons are destroyed
        enabled = false;
    }
}
