using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameController : MonoBehaviour
{

    [SerializeField] private CanvasFader canvasFader;

    public static GameController Instance;

    // Optional: Awake method to initialize the singleton
    private void Awake()
    {
        // If the instance does not exist, set it to this object
        if (Instance == null)
        {
            Instance = this;
            // Make sure the singleton persists between scene changes
        }
        else
        {
            // If an instance already exists and it's not this one, destroy this one
            Destroy(gameObject);
        }
    }

    public async void EndGame()
    {
        await canvasFader.FadeToBlack();
    }
}