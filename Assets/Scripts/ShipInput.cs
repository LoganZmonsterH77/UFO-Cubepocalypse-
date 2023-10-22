using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private ShipCamera shipCamera;
    private ShipMovement shipMovement;
    public bool readyToLaunch;
    public WreckingBall wreckingBall;

    [SerializeField] private AudioClip launchSound; // Attach your launch sound effect in the Inspector

    private void Start()
    {
        // If shipCamera is not assigned, try to find it on the current GameObject.
        shipCamera ??= GetComponent<ShipCamera>();

        // Get the ShipMovement component on the current GameObject.
        shipMovement = GetComponent<ShipMovement>();
    }

    private void Update()
    {
        // Check for zoom in/out input.
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            shipCamera.ZoomOut();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            shipCamera.DefaultZoom();
        }

        // Check for launching input and whether the ship is ready to launch.
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToLaunch)
        {
            LaunchWreckingBall();
        }
    }

    public void LaunchWreckingBall()
    {
        // Check if the wreckingBall and launchSound are assigned.
        if (wreckingBall != null && launchSound != null)
        {
            // Launch the wreckingBall.
            wreckingBall.Launch();

            // Play the launch sound effect at the ship's position.
            AudioSource.PlayClipAtPoint(launchSound, transform.position);
        }
    }

    private void FixedUpdate()
    {
        // Move the ship based on input axes.
        shipMovement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
