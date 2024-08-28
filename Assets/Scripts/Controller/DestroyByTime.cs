using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private int lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
