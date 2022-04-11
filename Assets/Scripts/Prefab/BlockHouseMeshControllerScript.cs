using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prefab
{
    public class BlockHouseMeshControllerScript : MonoBehaviour
    {
        public GameObject _door;
        
        public GameObject _MeshController;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BlockHouse"))
            {
                _door.SetActive(false);
                _MeshController.SetActive(false);
            }
        }
    }
}
