using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableMovementState : StateMachineBehaviour
{

    private Player player;
    private float laneOffset;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.GetComponent<Player>();
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        handleLaneSwitching(animator);
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public void handleLaneSwitching(Animator animator)
    {
        player.transform.position = new Vector3(player.currentIsle.transform.position.x + GetLanePosition(laneOffset), animator.transform.position.y, animator.transform.position.z);
    }

    private float GetLanePosition(float x)
    {
        laneOffset = Mathf.Lerp(x, (float)player.lane * 1.25f, player.laneSwitchingLerpSpeed);
        return laneOffset;
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {

    }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {

    }
}
