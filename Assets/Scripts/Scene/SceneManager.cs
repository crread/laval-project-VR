using System.Collections.Generic;
using UnityEngine;

namespace Scene
{
    public class SceneManager : MonoBehaviour
    {

        [SerializeField] private List<GameObject> _boardToken;
        
        [SerializeField] private List<GameObject> _boardHouse;

        [SerializeField] private GameObject _housePrefab;

        void Update()
        {
        
        }
        
        public int GetIndexBoardHousePosition(GameObject go)
        {
            return _boardHouse.IndexOf(go);
        }
        
        public int GetIndexBoardTokenPosition(GameObject go)
        {
            return _boardToken.IndexOf(go);
        }

        private void BuildHouse(Vector3 position)
        {
            Instantiate(_housePrefab, position, Quaternion.identity);
        }
    }
}
