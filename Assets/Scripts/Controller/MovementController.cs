using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    public Vector3 DriveShip(float moveHorizontal, float moveVertical, int speed)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        return movement * speed;
    }

    public Quaternion TiltShip(Rigidbody physic, int rotationSpeed)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, physic.velocity.x * rotationSpeed);

        return rotation;
    }
}
