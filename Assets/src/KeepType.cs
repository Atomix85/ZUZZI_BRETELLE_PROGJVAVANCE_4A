using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepType : MonoBehaviour
{
    public static KeepType Instance;

    public string Type;
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    
    }
}
