using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

    Transform start, end;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.GetChild(0);
        end = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
