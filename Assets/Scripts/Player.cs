using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float RunningSpeed = 10f;
    public LANE lane;
    public float laneSwitchingLerpSpeed = 0.05f;
    public float laneSwitchThreshold = 0.25f;
    public float grabDuration = 0.5f;
    public GameObject currentIsle;
    public GameController gc;
    public TransitionController transitionController;

    private Animator animator;

    public void Start()
    {
        animator = transform.gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AisleEnd")
        {
            gc.PlayerAtEndOfAisle();
        }
        else if(other.tag == "AisleTransition")
        {
            if(lane == LANE.LEFT)
            {
                transitionController.TransitionLeft();
            }
            else
            {
                transitionController.TransitionRight();
            }
        }
        else if(other.tag == "FreezeMove")
        {
            animator.SetBool("AllowMove", false);
        }
    }

    public GameObject GetNextAisle()
    {
        return currentIsle.GetComponent<Aisle>().getNextAisle(lane);
    }
}

public enum LANE
{
    LEFT = -1, RIGHT = 1
};
