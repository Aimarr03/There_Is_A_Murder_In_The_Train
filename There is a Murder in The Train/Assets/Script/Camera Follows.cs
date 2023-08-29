using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform player;            // Reference to the player's transform
    public float xPositiveThreshold = 0.8f; // Percentage of screen width to trigger camera movement
    public float xNegativeThreshold= 0.1f;
    public float followSpeed = 0.8f;      // Speed at which the camera follows the player
    public float smoothTime = 0.3f;

    private Camera mainCamera;
    private float targetXPosition;
    private Vector3 velocity;
    private void Start()
    {
        mainCamera = Camera.main;
        targetXPosition = transform.position.x;
    }

    private void FixedUpdate()
    {
        Vector3 playerViewportPosition = mainCamera.WorldToViewportPoint(player.position);
        Debug.Log(playerViewportPosition);
        bool moveable = playerViewportPosition.x > xPositiveThreshold || playerViewportPosition.x < xNegativeThreshold;
        // Check if the player is close to the corner on the x-axis
        if (moveable)
        {
            // Calculate the target position for the camera
            targetXPosition = player.position.x;
        }

        // Smoothly move the camera towards the target position
        float newXPosition = Mathf.SmoothDamp(transform.position.x, targetXPosition, ref velocity.x, smoothTime);
        Vector3 newPosition = new Vector3(newXPosition, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
