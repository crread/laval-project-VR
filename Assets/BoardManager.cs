using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR.InteractionSystem.Sample;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> placeHolders;
    private Dictionary<int, MeshRenderer> freePlaceHolderDico;
    private Dictionary<int, MeshRenderer> occupiedPlaceHolderDico;
    [SerializeField] private List<SnapCollision> snapCollisions;
    [SerializeField] private Color baseMat;
    [SerializeField] private Color freePlace;
    [SerializeField] private Color occupied;
    
    void Awake()
    {
        freePlaceHolderDico = new Dictionary<int, MeshRenderer>();
        occupiedPlaceHolderDico = new Dictionary<int, MeshRenderer>();
        
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
            entry.Value.material.color = freePlace;
        }

        foreach (KeyValuePair<int, MeshRenderer> entry in occupiedPlaceHolderDico)
        {
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
        if (ltp.snapTo.GetComponent<SnapCollision>())
        {
            int id = ltp.snapTo.GetComponent<SnapCollision>().id;
            occupiedPlaceHolderDico.Add(id,placeHolders[id]);
            if (freePlaceHolderDico.ContainsKey(id))
            {
                freePlaceHolderDico.Remove(id);
            }
            
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
            
        }

    }
}
