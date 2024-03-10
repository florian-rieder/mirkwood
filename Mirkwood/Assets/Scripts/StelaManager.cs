using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StelaManager : MonoBehaviour
{

    [SerializeField] private List<Stela> stelas;
    private Stela currentStela;

    public static StelaManager Instance;

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

    // Start is called before the first frame update
    void Start()
    {
        // Start with the first stela always
        currentStela = stelas[0];
        currentStela.Activate(true);
    }

    public void ActivateNextStela()
    {
        currentStela = ChooseNextStela();
        currentStela.Activate(true);
    }

    private Stela ChooseNextStela()
    {
        Shuffle<Stela>(stelas);
        foreach (Stela stela in stelas)
        {
            if (!stela.Active)
            {
                return stela;
            }
        }

        return null;
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T tempItem = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = tempItem;
        }
    }
}
