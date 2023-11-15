using UnityEngine;
public class Player : MonoBehaviour
{
    public WheelCollider WheelForwardLeft, WheelForwardRight, WheelRearLeft, WheelRearRight;
    public float maxForwardSpeed, maxBrakeTorque, steerSpeed;
    public Rigidbody rb;
    public Transform centerOfMass;

    bool braked;
    float horizontalInput, verticalInput;

    private void Start()
    {
        rb.centerOfMass = centerOfMass.transform.localPosition;
        
    }//Start

    void FixedUpdate()
    {
        InputManager();
    }//FixedUpdate

    void InputManager()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        braked = Input.GetKey(KeyCode.Space);

        Brake();
        Move();
        Steering();
    }//InputManager

    void Brake()
    {
        if (braked)
        {
            WheelRearLeft.brakeTorque = maxBrakeTorque * 20f;
            WheelRearRight.brakeTorque = maxBrakeTorque * 20f;

            WheelRearLeft.motorTorque = 0f;
            WheelRearRight.motorTorque = 0f;
        }
        else
        {
            WheelForwardLeft.brakeTorque = 0f;
            WheelForwardRight.brakeTorque = 0f;
            WheelRearLeft.brakeTorque = 0f;
            WheelRearRight.brakeTorque = 0f;
        }
    }//Brake

    void Move()
    {
            WheelRearRight.motorTorque = maxForwardSpeed * verticalInput;
            WheelRearLeft.motorTorque = maxForwardSpeed * verticalInput;


    }//Move

    void Steering()
    {
        WheelForwardLeft.steerAngle = steerSpeed * horizontalInput;
        WheelForwardRight.steerAngle = steerSpeed * horizontalInput;
    }//Steering

}//class

/* i did'nt worry to make wheel rotations with car rotation
  * because of time limitation and it did'nt appear in third person camera to 
  * other things is car drift and slip is too much i try to fix it but i failed*/