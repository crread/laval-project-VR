using System;
using UnityEngine;

namespace Prefab
{
    public class TileHouseScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Token"))
            {
                
            }
        }
    }
}
