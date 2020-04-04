using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DataAccessLayers;


public class GameFoundationManager : MonoBehaviour
{    
    void Awake()
    {
        GameFoundation.Initialize(new MemoryDataLayer());
    }
}
