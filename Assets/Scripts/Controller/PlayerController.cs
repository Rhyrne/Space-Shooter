using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boundary
{
    private float xMin, xMax, zMin, zMax;

    public Boundary(float xmin, float xmax, float zmin, float zmax) 
    {
        this.xMin = xmin;
        this.xMax = xmax;
        this.zMin = zmin;
        this.zMax = zmax;
    }

    public Vector3 GetPosition(Rigidbody physic)
    {
        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, xMin, xMax),
            0,
            Mathf.Clamp(physic.position.z, zMin, zMax)
        );

       return position;
    }
}

public class PlayerController : MonoBehaviour
{
    // Değişkenler
    private Rigidbody physic;
    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;

    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float zMin;
    [SerializeField] private float zMax;

    //Sınıflar
    public Boundary boundary ;
    public MovementController movementController;

    void Start()
    {
        physic = GetComponent<Rigidbody>();

        // Sınıflardan nesne oluşturma
        boundary = new Boundary(xMin, xMax, zMin, zMax);
        movementController = new MovementController();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        physic.velocity = movementController.DriveShip(moveHorizontal, moveVertical, speed);

        Vector3 position = boundary.GetPosition(physic);

        physic.position = position;

        physic.rotation = movementController.TiltShip(physic,rotationSpeed);

    }
}
