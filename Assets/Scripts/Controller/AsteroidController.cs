using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    Rigidbody physic;

    [SerializeField] private int rotateSpeed;
    [SerializeField] private float speed;

    void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.angularVelocity = Random.insideUnitSphere * rotateSpeed;
        physic.velocity = transform.forward * speed;
    }
}
