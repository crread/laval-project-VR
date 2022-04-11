using System.Collections.Generic;
using UnityEngine;

namespace Scene
{
    public class SceneManager : MonoBehaviour
    {

        [SerializeField] private List<GameObject> _boardToken;
        
        [SerializeField] public List<GameObject> _boardHouse;

        [SerializeField] private GameObject _housePrefab;

        void Update()
        {
        
        }

        private void BuildHouse(Vector3 position)
        {
            Instantiate(_housePrefab, position, Quaternion.identity);
        }
    }
}
