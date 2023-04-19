using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{

    public GameObject LeftPanel;
    public Vector3 LeftPanelDelta;
    public GameObject RightPanel;
    public Vector3 RightPanelDelta;
    public float TransitionTime;

    private Vector3 originalPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionLeft()
    {
        StartCoroutine(MovePanel(LeftPanel, LeftPanel.transform.localPosition + LeftPanelDelta));
    }

    public void TransitionRight()
    {
        StartCoroutine(MovePanel(RightPanel, RightPanel.transform.localPosition + RightPanelDelta));
    }

    private IEnumerator MovePanel(GameObject panel, Vector3 destination)
    {
        originalPosition = panel.transform.localPosition;

        float elapsedTime = 0f;

        while(elapsedTime < TransitionTime)
        {

            elapsedTime += Time.deltaTime;

            panel.transform.localPosition = Vector3.Lerp(originalPosition, destination, elapsedTime / TransitionTime);

            yield return null;

        }

        panel.transform.localPosition = originalPosition;

        yield return null;
    }

}
