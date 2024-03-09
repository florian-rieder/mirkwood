using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StelaManager : MonoBehaviour
{

    [SerializeField] private List<Stela> stelas;
    private Stela currentStela;

    // Start is called before the first frame update
    void Start()
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

        return stelas[0];
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
