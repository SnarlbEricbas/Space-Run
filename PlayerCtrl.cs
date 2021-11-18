using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] float xSpeed = 30f;
    float xRange = 16f;
    [SerializeField] float ySpeed = 30f;
    float yRange = 4f;
    [SerializeField] float maxRoll = 30f;
    [SerializeField] float maxPitch = 30f;

    [SerializeField] GameObject leftGun;
    [SerializeField] GameObject rightGun;
    //[SerializeField] float maxYaw = 1f;
    public float TurnSpeed = 30f;
    float pitch = 0f;
    float yaw = 0f;
    float roll = 0f;
    float xVal = 0f;
    float yVal = 0f;
    void Start()
    {
        
    }
    void Update ()
    {
        xVal = CrossPlatformInputManager.GetAxis("Horizontal");
        yVal = CrossPlatformInputManager.GetAxis("Vertical");
        UpdatePosition();
        UpdateRotation();
        Fire();
    }
    void UpdatePosition()
    {
        float xOffset = transform.localPosition.x + xVal * xSpeed * Time.deltaTime;
        float xOffsetClamp = Mathf.Clamp(xOffset, -xRange, xRange);
        float yOffset = transform.localPosition.y + yVal * ySpeed * Time.deltaTime;
        float yOffsetClamp = Mathf.Clamp(yOffset, -4*yRange, yRange);
        transform.localPosition = new Vector3(xOffsetClamp, yOffsetClamp, transform.localPosition.z);
    }
    void UpdateRotation()
    {
        float newRoll = xVal * -maxRoll;
        float maxRollSpeed = maxRoll * 3 * Time.deltaTime;

        newRoll = Mathf.Clamp(newRoll, roll - maxRoll * 3 * Time.deltaTime, roll + maxRoll * 3 * Time.deltaTime);
        roll = newRoll;

        float newPitch = yVal * -maxPitch;
        float maxPitchSpeed = maxPitch * 3 * Time.deltaTime;
        newPitch = Mathf.Clamp(newPitch, pitch - maxPitchSpeed, pitch + maxPitchSpeed);
        pitch = newPitch;
        
        //yaw = gameObject.transform.position.x * maxYaw;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    //...
    void Fire()
    {
        //Bullet & Bullet (1)
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            leftGun.SetActive(true);
            rightGun.SetActive(true);
        }
        else
        {
            leftGun.SetActive(false);
            rightGun.SetActive(false);
        }
    }
}
