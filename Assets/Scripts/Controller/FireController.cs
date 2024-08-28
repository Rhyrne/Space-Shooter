using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    AudioSource audioPlayer;

    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private float fireRate;
    private float nextFire;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laser, firePoint.transform.position, firePoint.transform.rotation);
            audioPlayer.Play();
        }
    }
}
