using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Tooltip("In m/s")] [SerializeField] float xSpeed = 30f, ySpeed = 30f;
    [SerializeField] float xRange = 12.5f;
    [SerializeField] float yRange = 8;
    float xThrow, yThrow;

    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlYawFactor = 10f;
    [SerializeField] float controlRollFactor = 25;


    // Update is called once per frame
    void Update()
    {
        ProcessTransition();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToControlThrow = controlPitchFactor * yThrow;
        float pitchDueToPosition = positionPitchFactor * transform.localPosition.y;
        float pitch = pitchDueToControlThrow + pitchDueToPosition;

        float yawDueThrow = controlYawFactor * xThrow;
        float yawByPosition = positionYawFactor * transform.localPosition.x;
        float yaw = yawDueThrow + yawByPosition;

        float roll = controlRollFactor * xThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }



    private void ProcessTransition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float yOffset = yThrow * Time.deltaTime * ySpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float yPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
