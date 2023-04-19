using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aisle : MonoBehaviour
{

    public GameObject left, right;

    public GameObject start;

    public void Start()
    {
        start = transform.GetChild(1).gameObject;
    }

    public GameObject getNextAisle(LANE lane)
    {
        if (lane == LANE.LEFT)
        {
            return left;
        }
        else return right;
    }

}
