using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR.InteractionSystem.Sample;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;

    [SerializeField] private List<MeshRenderer> placeHolders;
    
    private Dictionary<int, MeshRenderer> freePlaceHolderDico;
    private Dictionary<int, MeshRenderer> occupiedPlaceHolderDico;
    public static Dictionary<int, Token> tokens;
    [SerializeField] private List<SnapCollision> snapCollisions;
    
    [SerializeField] private List<GameObject> _boardToken;
        
    [SerializeField] private List<GameObject> _boardHouse;

    [SerializeField] private GameObject _housePrefab;
    
    [SerializeField] private Color baseMat;
    [SerializeField] private Color freePlace;
    [SerializeField] private Color occupied;
    
    public GameObject GetBoardHousePosition(int index)
    {
        return _boardHouse[index].gameObject;
    }
        
    public int GetIndexBoardHousePosition(SnapCollision snapCollision)
    {
        return _boardHouse.IndexOf(snapCollision.transform.parent.gameObject);
    }
        
    public int GetIndexBoardTokenPosition(SnapCollision snapCollision)
    {
        return _boardToken.IndexOf(snapCollision.transform.parent.gameObject);
    }

    public void BuildHouse(Vector3 position)
    {
        Instantiate(_housePrefab, position, Quaternion.identity);
    }
    
    void Awake()
    {
        instance = this;
        freePlaceHolderDico = new Dictionary<int, MeshRenderer>();
        occupiedPlaceHolderDico = new Dictionary<int, MeshRenderer>();
        tokens = new Dictionary<int, Token>();
        
        for (int i = 0; i < placeHolders.Count; i++)
        {
            snapCollisions[i] = placeHolders[i].transform.GetChild(0).GetComponent<SnapCollision>();
            snapCollisions[i].id = i;
            freePlaceHolderDico.Add(i,placeHolders[i]);
        }
        //baseMat = placeHolders[0].material;
    }

    public void SeePlacesAvailability()
    {
        
        foreach (KeyValuePair<int, MeshRenderer> entry in freePlaceHolderDico)
        {
            //Debug.Log("Free : " + entry.Key );
            entry.Value.material.color = freePlace;
        }
        
        foreach (KeyValuePair<int, MeshRenderer> entry in occupiedPlaceHolderDico)
        {
            Debug.Log("Occupied : " + entry.Key);
            entry.Value.material.color = occupied;
        }
    }

    public void ResetPlacesColor()
    {
        foreach (KeyValuePair<int, MeshRenderer> entry in freePlaceHolderDico)
        {
            entry.Value.material.color = baseMat;
        }

        foreach (KeyValuePair<int, MeshRenderer> entry in occupiedPlaceHolderDico)
        {
            entry.Value.material.color = baseMat;
        }
    }
    
    public void GetTheSnapOfTheToken(LockToPoint ltp)
    {
        if (ltp.snapTo && ltp.snapTo.GetComponent<SnapCollision>())
        {
            var idx = GetIndexBoardTokenPosition(ltp.snapTo.GetComponent<SnapCollision>());
            Debug.Log(idx);
            var goBoard = GetBoardHousePosition(idx);
            Debug.Log(goBoard);
            var goBoardPosition = goBoard.transform.GetChild(0).transform.position;
            Debug.Log(goBoardPosition);
            goBoardPosition.y += 20;
            BuildHouse(goBoardPosition);
                
            Debug.Log("oui c'est dedans");
            int id = ltp.snapTo.GetComponent<SnapCollision>().id;
            Debug.Log("mon id : " + id);
            
            occupiedPlaceHolderDico.Add(id,placeHolders[id]);
            Debug.Log(occupiedPlaceHolderDico[id]);
            if (freePlaceHolderDico.ContainsKey(id))
            {
                freePlaceHolderDico.Remove(id);
            }
        }
        else
        {
            Destroy(ltp.gameObject);
        }
    }

    public void FreeTheSnaoOfTheToken(LockToPoint ltp)
    {
        if (ltp.snapTo.GetComponent<SnapCollision>())
        {
            int id = ltp.snapTo.GetComponent<SnapCollision>().id;
            freePlaceHolderDico.Add(id,placeHolders[id]);
            if (occupiedPlaceHolderDico.ContainsKey(id))
            {
                occupiedPlaceHolderDico.Remove(id);
            }

            ltp.snapTo = null;
        }

    }
}
