using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class Token : MonoBehaviour
{
    public static int count = 0;
    public InteractableHoverEvents interact;
    private bool isOk = false;

    private void Start()
    {
        BoardManager.tokens.Add(count, this);
        count++;
        
        interact.onAttachedToHand.AddListener(FreePlaceInBoard);
        interact.onAttachedToHand.AddListener(BoardManager.instance.SeePlacesAvailability);
        interact.onAttachedToHand.AddListener(TriggerTokenAction);
        
        
        interact.onDetachedFromHand.AddListener(TokenRemoveListenner);
        interact.onDetachedFromHand.AddListener(SetPlaceInBoard);
        interact.onDetachedFromHand.AddListener(BoardManager.instance.ResetPlacesColor);
        
        
    }

    public void SetPlaceInBoard()
    {
        BoardManager.instance.GetTheSnapOfTheToken(GetComponent<LockToPoint>());
    }
    
    public void FreePlaceInBoard()
    {
        BoardManager.instance.FreeTheSnaoOfTheToken(GetComponent<LockToPoint>());
    }
    public void TriggerTokenAction()
    {
        TokenSpawnPoint.TriggerGetToken();
    }

    public void TokenRemoveListenner()
    {
        interact.onAttachedToHand.RemoveListener(TriggerTokenAction);
    }
    
}
