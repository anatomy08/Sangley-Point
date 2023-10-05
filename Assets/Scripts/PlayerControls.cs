using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("MovementControls")]
    [Tooltip("Setup the movement of the gameobject")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yTopRange = 5f;
    [SerializeField] float yLowrange = -0.7f;

    [Header("Pitch Control")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 2f;

    [Header("Yaw Control")]
    [SerializeField] float positionYawFactor = 2f;

    [Header("Roll Control")]

    [SerializeField] float controlRollFactor = 2f;

    [Header("GameObject Array List")]
    [SerializeField] GameObject[] machineGun;
    

    float xThrow , yThrow;

    public bool isCrashed = false;
    
   
    void Update()
    {
       if(isCrashed) {return;} 
       MovementControls();
       RotationControls();
       ProcessFiring();
       
    }

    void RotationControls()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
       

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDuetoControlThrow = xThrow * controlRollFactor;
        

        float Pitch = pitchDueToPosition + pitchDueToControlThrow;
        float Yaw = yawDueToPosition;
        float Roll = rollDuetoControlThrow;
        
        transform.localRotation = Quaternion.Euler(Pitch, Yaw, Roll);
    }

    void MovementControls()
    {
        

       float horizontalThrow = Input.GetAxis("Horizontal"); 
       float verticalThrow = Input.GetAxis("Vertical");

       xThrow = horizontalThrow * moveSpeed * Time.deltaTime;
       yThrow = verticalThrow * moveSpeed * Time.deltaTime;

       float newXPos = transform.localPosition.x + xThrow;
       float newYPos = transform.localPosition.y + yThrow;

       float clampedXpos = Mathf.Clamp(newXPos, -xRange, xRange);
       float clampedYpos = Mathf.Clamp(newYPos, -yLowrange, yTopRange);


       transform.localPosition = new Vector3(clampedXpos,clampedYpos,transform.localPosition.z);
    }

    public void ProcessFiring()
    {
        

        if(Input.GetButton("Fire1"))
        {
            SetGunToActive(true);
        } 
        else 
        {
            SetGunToActive(false);
        }
    }

     void SetGunToActive(bool isActive)
    {
        
           foreach(GameObject fire in machineGun)
           {
                var emissionModule = fire.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = isActive;
           }
    }

}

/*  or this code 
    void StartFiring()
    {
           foreach(GameObject fire in machineGun)
           {
                var emissionModule = fire.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = true;
           }
    }

    void StopFiring()
    {
        foreach(GameObject fire in machineGun)
           {
                var emissionModule = fire.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = false;
           }
    } 
    
*/