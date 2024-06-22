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
        bool isHarvesting = animator.GetBool("isHarvesting");
        bool isPunching = animator.GetBool("isPunching");
        bool isBlocking = animator.GetBool("isBlocking");
        bool isJumping = animator.GetBool("isJumping");

        bool forwardPressed = Input.GetKey("w");
        bool rightPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("a");
        bool backwardsPressed = Input.GetKey("s");
        bool ePressed = Input.GetKey("e");
        bool leftClicked = Input.GetKey(KeyCode.Mouse0);

        bool runPressed = Input.GetKey("left shift");

        // If left mouse button is clicked, stop all movements and punch
        if (leftClicked)
        {
            // Stop all movements
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingBackwards", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isRunningLeft", false);
            animator.SetBool("isRunningRight", false);
            animator.SetBool("isRunningBackwards", false);

            // Start punching
            if (!isPunching)
            {
                animator.SetBool("isPunching", true);
            }
        }
        else
        {
            // Stop punching when left mouse button is released
            if (isPunching)
            {
                animator.SetBool("isPunching", false);
            }

            // Set walking bool in animator / turn off walking forward
            if (!isWalking && forwardPressed)
            {
                animator.SetBool("isWalking", true);
            }
            if (isWalking && !forwardPressed)
            {
                animator.SetBool("isWalking", false);
            }

            // Set walking left bool in animator / turn off walking left
            if (!isWalkingLeft && leftPressed)
            {
                animator.SetBool("isWalkingLeft", true);
            }
            if (isWalkingLeft && !leftPressed)
            {
                animator.SetBool("isWalkingLeft", false);
            }

            // Set walking right bool in animator / turn off walking right
            if (!isWalkingRight && rightPressed)
            {
                animator.SetBool("isWalkingRight", true);
            }
            if (isWalkingRight && !rightPressed)
            {
                animator.SetBool("isWalkingRight", false);
            }

            // Set walking backwards bool in animator / turn off walking backwards
            if (!isWalkingBackwards && backwardsPressed)
            {
                animator.SetBool("isWalkingBackwards", true);
            }
            if (isWalkingBackwards && !backwardsPressed)
            {
                animator.SetBool("isWalkingBackwards", false);
            }

            // Sprint forward
            if (!isRunning && (forwardPressed && runPressed))
            {
                animator.SetBool("isRunning", true);
            }
            if (isRunning && (!forwardPressed || !runPressed))
            {
                animator.SetBool("isRunning", false);
            }

            // Sprint left
            if (!isRunningLeft && (leftPressed && runPressed))
            {
                animator.SetBool("isRunningLeft", true);
            }
            if (isRunningLeft && (!leftPressed || !runPressed))
            {
                animator.SetBool("isRunningLeft", false);
            }

            // Sprint right
            if (!isRunningRight && (rightPressed && runPressed))
            {
                animator.SetBool("isRunningRight", true);
            }
            if (isRunningRight && (!rightPressed || !runPressed))
            {
                animator.SetBool("isRunningRight", false);
            }

            // Sprint backwards
            if (!isRunningBackwards && (backwardsPressed && runPressed))
            {
                animator.SetBool("isRunningBackwards", true);
            }
            if (isRunningBackwards && (!backwardsPressed || !runPressed))
            {
                animator.SetBool("isRunningBackwards", false);
            }

            // Harvesting
            if (!isHarvesting && (ePressed))
            {
                animator.SetBool("isHarvesting", true);
            }
            if (isHarvesting && (!ePressed))
            {
                animator.SetBool("isHarvesting", false);
            }

            // Blocking
            bool rightClicked = Input.GetMouseButtonDown(1);
            bool rightHeld = Input.GetMouseButton(1);

            if (rightClicked || rightHeld)
            {
                animator.SetBool("isBlocking", true);
            }
            else
            {
                animator.SetBool("isBlocking", false);
            }

            // Jumping
            bool spaceClicked = Input.GetKeyDown(KeyCode.Space);
            bool spaceHeld = Input.GetKey(KeyCode.Space);

            if (spaceClicked || spaceHeld)
            {
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
    }
}
