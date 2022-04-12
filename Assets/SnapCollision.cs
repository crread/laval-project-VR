using System;
using System.Collections;
using System.Collections.Generic;
using Scene;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class SnapCollision : MonoBehaviour
{
    public int id;
    public bool free;

    public SceneManager sceneManager;
        
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Token"))
        {
           // var idx = sceneManager.GetIndexBoardTokenPosition(other.gameObject);
            

            other.gameObject.GetComponent<LockToPoint>().snapTo = transform;
            Debug.Log("done");
            
            
        }
    }
}
