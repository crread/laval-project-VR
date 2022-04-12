using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class TokenSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject TokenPrefab;
    // Start is called before the first frame update
    public static event Action onGetToken;
    public Preset tokenPreset;

    public static void TriggerGetToken()
    {
        if (onGetToken != null)
        {
            onGetToken();
        }
        
    }
    
    
    void Start()
    {
        onGetToken += OnGetOneToken;
        OnGetOneToken();
    }

    private void OnGetOneToken()
    {
        GameObject go = Instantiate(TokenPrefab, transform.position, transform.rotation);
        go.GetComponent<LockToPoint>().snapTo = transform;
    }
}
