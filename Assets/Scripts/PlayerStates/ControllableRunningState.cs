using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableRunningState : StateMachineBehaviour
{

    private Player player;
    private float laneOffset;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.GetComponent<Player>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //controls lane switching
        player.lane = (Input.GetAxis("Horizontal") > player.laneSwitchThreshold) ? LANE.RIGHT : Input.GetAxis("Horizontal") < -player.laneSwitchThreshold ? LANE.LEFT : player.lane;

        if(Input.GetButtonDown("Grab"))
        {
            animator.SetBool("Grabbing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
