using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class SnapCollision : MonoBehaviour
{
    public int id;
    public bool free;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Token"))
        {
            other.gameObject.GetComponent<LockToPoint>().snapTo = transform;
            Debug.Log("done");
        }
    }
}
