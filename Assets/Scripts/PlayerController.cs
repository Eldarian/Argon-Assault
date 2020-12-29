using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m/s")] [SerializeField] float controlSpeed = 30f;
    [Tooltip("In meters")] [SerializeField] float xRange = 12.5f;
    [Tooltip("In meters")] [SerializeField] float yRange = 8;
    float xThrow, yThrow;

    [Header("Screen Position Parameters")]
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Control Parameters")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlYawFactor = 10f;
    [SerializeField] float controlRollFactor = 25;

    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProcessTransition();
            ProcessRotation();
        }
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

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float yPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    public void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
    }
   
}
