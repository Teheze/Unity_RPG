using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingLeft = animator.GetBool("isWalkingLeft");
        bool isWalkingRight = animator.GetBool("isWalkingRight");
        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool isRunning = animator.GetBool("isRunning");
        bool isRunningLeft = animator.GetBool("isRunningLeft");
        bool isRunningRight = animator.GetBool("isRunningRight");
        bool isRunningBackwards = animator.GetBool("isRunningBackwards");

        bool forwardPressed = Input.GetKey("w");
        bool rightPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");
        bool backwardsPressed = Input.GetKey("s");

        bool runPressed = Input.GetKey("left shift");

        //setowanie boola w animatorze na bieg/wylaczenie biegu przód
        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        //setowanie boola w animatorze na bieg/wylaczenie biegu lewo
        if (!isWalkingLeft && leftPressed)
        {
            animator.SetBool("isWalkingLeft", true);
        }
        if (isWalkingLeft && !leftPressed)
        {
            animator.SetBool("isWalkingLeft", false);
        }

        //setowanie boola w animatorze na bieg/wylaczenie biegu prawo
        if (!isWalkingRight && rightPressed)
        {
            animator.SetBool("isWalkingRight", true);
        }
        if (isWalkingRight && !rightPressed)
        {
            animator.SetBool("isWalkingRight", false);
        }

        //setowanie boola w animatorze na bieg/wylaczenie biegu ty³
        if (!isWalkingBackwards && backwardsPressed)
        {
            animator.SetBool("isWalkingBackwards", true);
        }
        if (isWalkingBackwards && !backwardsPressed)
        {
            animator.SetBool("isWalkingBackwards", false);
        }

        //sprint przód
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool("isRunning", true);
        }
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }

        //sprint lewo
        if (!isRunningLeft && (leftPressed && runPressed))
        {
            animator.SetBool("isRunningLeft", true);
        }
        if (isRunningLeft && (!leftPressed || !runPressed))
        {
            animator.SetBool("isRunningLeft", false);
        }

        //sprint prawo
        if (!isRunningRight && (rightPressed && runPressed))
        {
            animator.SetBool("isRunningRight", true);
        }
        if (isRunningRight && (!rightPressed || !runPressed))
        {
            animator.SetBool("isRunningRight", false);
        }

        //sprint ty³
        if (!isRunningBackwards && (backwardsPressed && runPressed))
        {
            animator.SetBool("isRunningBackwards", true);
        }
        if (isRunningBackwards && (!backwardsPressed || !runPressed))
        {
            animator.SetBool("isRunningBackwards", false);
        }
    }
}
