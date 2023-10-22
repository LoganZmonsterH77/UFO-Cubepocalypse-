using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    int cubeSpeed; // Variable to store the random cube speed
    public int riseSpeed = 0;

    void Start()
    {
        cubeSpeed = Random.Range(1, 10); // Random range between 1 and 10 (inclusive)
        
    }

    void Update()
    {
        this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
    }

    public void GetCollected()
    {
        if (cubeSpeed > 6)                                                      // Check if speed is greater than 6 (7, 8, 9, or 10)
        {
            this.GetComponent<Renderer>().material.color = Color.green;         // Set color to green
            this.GetComponent<Rigidbody>().isKinematic = true;
            riseSpeed += 5;                                                     // Increase riseSpeed by 5
            this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
            Destroy(this.gameObject, 5);                                        // Destroy after 5 seconds.
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.red; // Set color to red
            Destroy(this.gameObject, 1); // Destroy self after 1 second
        }
    }
}
