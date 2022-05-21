using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    private GenerationManager generationManager;
    void OnEnable()
    {
        generationManager = GetComponent<GenerationManager>();
        InvokeRepeating("IncrementGeneration", 1f, 0.5f);
    }
    
    void OnDisable() {
        CancelInvoke("IncrementGeneration");
    }

    void IncrementGeneration()
    {
        StartCoroutine(generationManager.NextGeneration());    
        foreach(Transform child in transform) {
            child.GetComponent<CellManager>().StatusCheck();
        }
        generationManager.currentGeneration++;
    }

}
