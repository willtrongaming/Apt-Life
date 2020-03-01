using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When an onject is assumed to need a certain component, it's good practice to make that a required Component 
[RequireComponent (typeof(Controller2D))]

public class NewPlayer : Controller2D
{
    //Values as of 5:20 pm on 2/28/2020
    /*public float maxJumpHeight = 3f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = 0.45f;
    float accelerationTimeAirborne = 0.4f;
    float accelerationTimeGrounded = 0.025f;*/
    /*[HideInInspector]*/
    /*public float maxJumpHeight = 2.6f;*/
    public float maxJumpHeight = 2.4f;
    /*[HideInInspector]*/
    public float minJumpHeight = 1.3f;
    /*[HideInInspector]*/
    /*public float timeToJumpApex = 0.375f;*/
    public float timeToJumpApex = 0.35f;
    float accelerationTimeAirborne = 0.25f;
    float accelerationTimeGrounded = 0.035f;
    /*float moveSpeed = 6;*/
    float moveSpeed = 5.85f;
    float climbSpeed = 4;

    /*public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;
    public float wallSlideSpeedMax = 3;
    public float wallStickTime = 0.25f;
    float timeToWallUnstick;*/

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    /*float bufferCounter = 0f;
    float bufferMax = 15f;*/

    Controller2D controller;
    Animator myAnimator;
    BoxCollider2D myBoxCollider;

    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;

    bool isAlive = true;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + " Jump Velocity: " + maxJumpVelocity);
    }

    void Update()
    {
        if (!isAlive) { return; }

        CalculateVelocity();
        /*HandleWallSliding();*/
        RunAnimation();
        FlipSprite();
        ClimbLadderAnimation();
        Death();

        // bufferCounter increments each frame - can be incrementing in a separate method > just called up here in the Update()
        /*bufferCounter++;*/

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        /*if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
        }*/

        /*if (controller.collisions.below) // && bufferCounter < bufferMax --> proceed (to jump)
        {
            velocity.y = maxJumpVelocity;
        }*/

        //Sebastian Structure
        velocity.y = maxJumpVelocity;
    }

    public void OnJumpInputUp()
    {
        // New Structure
        /*if (velocity.y > 0)
        {
            velocity.y = maxJumpVelocity * 0.5f;
        }*/
        
        // Sebastian structure
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    private void RunAnimation()
    {
        // if user is pressing "A" || "D" || Left || Right && NewPlayer is touching the ground
        // > bool playerIsRunning = true
        // *translating above into a bool statement:*
        bool playerIsRunning = (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))
            || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow));
            //&& controller.VerticalCollisions().hit.distance == 0;
            /*&& (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))));*/
            /*&& collisions.below*/;
        // For now, I'm ignoring the clarifier of "&& touching the ground" 
        // - player looks like he's running through the air, but I'm ok with it for now

        myAnimator.SetBool("Running", playerIsRunning);
    }

    private void FlipSprite()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    private void ClimbLadderAnimation()
    {
        bool playerIsClimbingLadder = (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) 
            || (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow));
        myAnimator.SetBool("Climbing", playerIsClimbingLadder);
    }

    public void Death()
    {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Hazards1", "RisingWater1")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Death");
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    /*void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        // wallSliding is true when player is colliding w/ wall to left or right, not touching the ground, and moving downward
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
    }*/
    
    void CalculateVelocity()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ladder1")))
        {
            float targetVelocityX = directionalInput.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing,
                (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Old Structure
            /*float targetVelocityX = directionalInput.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing,
                (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);*/
            // New Structure
            velocity.x = directionalInput.x * moveSpeed;
            velocity.y = directionalInput.y * climbSpeed;
        }
    }
}
