using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTriggerController : MonoBehaviour
{
    private int totalCubesCollected = 0;
    public AudioClip cubeCollectSound; // Assign the audio clip in the Unity Inspector.

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Cube triggered");
            other.GetComponent<CubeController>().GetCollected();
            totalCubesCollected += 1; // shorter, does the math.
            Debug.Log("We have collected " + totalCubesCollected + " cubes.");

            // Play the cube collect sound
            if (cubeCollectSound != null)
            {
                AudioSource.PlayClipAtPoint(cubeCollectSound, transform.position);
            }
        }
    }
}
