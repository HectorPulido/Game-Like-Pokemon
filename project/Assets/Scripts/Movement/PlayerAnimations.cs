using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public float offsetAnimationPause = 0.5f;
    private Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void SetDirection(string stateName)
    {
        if (stateName == currentState)
        {
            return;
        }

        currentState = stateName;

        animator.Play(stateName, 0, 0);
    }

    public void SetPauseAnimation(bool pause)
    {
        if (pause)
        {
            AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
            int stateName = currentState.fullPathHash;
            animator.Play(stateName, 0, offsetAnimationPause);
        }
        
        animator.SetFloat("speed_multiplier", pause ? 0 : 1);
    }
        
}
