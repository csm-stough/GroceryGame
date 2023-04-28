using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAisleController : MonoBehaviour
{

    public GameObject AisleSegment;

    public List<GameObject> Segments;

    // Start is called before the first frame update
    void Start()
    {
        //Begin with 2 segments
        //Constantly move each segment backwards
        //When any segment gets to a certain z position
        //move segment back to front


        Segments = new List<GameObject>();

        AddSegment();
        AddSegment();
        AddSegment();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Segments.Count; i++)
        {
            Segments[i].transform.Translate(new Vector3(0f, 0f, -15f) * Time.deltaTime);
            if (Segments[i].transform.position.z < -5f)
            {
                Destroy(Segments[i].gameObject);
                Segments.Remove(Segments[i]);
                AddSegment();
            }
        }
    }

    private void AddSegment()
    {
        if(Segments.Count == 0)
        {
            Segments.Add(Instantiate(AisleSegment, this.transform, false));
        }
        else
        {
            //Calculate the proper z value based on most forward segments position and z-scale
            GameObject forward = GetFront();
            float forwardZ = GetForwardZ(forward);
            GameObject newSegment = Instantiate(AisleSegment, this.transform, false);
            newSegment.transform.localPosition = new Vector3(0, 0, forwardZ);
            Segments.Add(newSegment);
        }
    }

    /**
     * Returns the front aisle segment
     */
    private GameObject GetFront()
    {
        return Segments[Segments.Count - 1].transform.GetChild(0).gameObject;
    }

    private float GetForwardZ(GameObject segment)
    {
        return segment.transform.position.z + (segment.transform.localScale.z * 10f);
    }
}
