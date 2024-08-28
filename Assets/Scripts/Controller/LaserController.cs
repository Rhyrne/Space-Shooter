using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    Rigidbody physic;

    [SerializeField] private float laserSpeed;
    

    void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.velocity = transform.forward * laserSpeed;
    }
}
