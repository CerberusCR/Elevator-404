using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCount : MonoBehaviour
{
    private BalloonManager balloonManager; // Reference to the BalloonManager script

    private void Start()
    {
        // Find the BalloonManager script in the scene
        balloonManager = FindObjectOfType<BalloonManager>();

        if (balloonManager == null)
        {
            Debug.LogError("No BalloonManager found in the scene!");
        }
    }

    private void OnDestroy()
    {
        if (balloonManager != null)
        {
            // Notify the BalloonManager that this balloon is destroyed
            balloonManager.BalloonDestroyed();
        }
    }
}
