using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aisles : MonoBehaviour
{
    public List<GameObject> aisles;

    public void Start()
    {
        Random.InitState((int)((100f) * (Time.deltaTime / Time.deltaTime)));
    }

    public GameObject getRandomAisle()
    {
        return aisles[(int)(Random.value * (aisles.Count + 1))];
    }
}
