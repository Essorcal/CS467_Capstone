using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float runSpeedMultiplier = 1.05f;
    public float maxSpeed = .75f;
    float originSpeed;
    private bool playerMoving;
    new Rigidbody2D rigidbody2D;
    Vector2 move, lastMove;


    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        originSpeed = maxSpeed;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Vector2.zero;
        playerMoving = false;


        if (Input.GetKey("left shift") || Input.GetKey("right shift"))  //Add the running multiplier
        {
            maxSpeed = 4 * runSpeedMultiplier;
            anim.speed = 2F;                        //Increase the animation speed for running
        } else
        {
            anim.speed = 1;
        }

        lastMove.x = move.x = Mathf.Lerp(0, Input.GetAxis("Horizontal") * maxSpeed, 0.8f); //Get the horizontal axis, interpolate between 0 and the input by 0.8
        lastMove.y = move.y = Mathf.Lerp(0, Input.GetAxis("Vertical") * maxSpeed, 0.8f);   //Get the vertical axis, interpolate between 0 and the input by 0.8

        if (move.x != 0 || move.y != 0)
        {
            playerMoving = true;
            anim.SetFloat("lastVert", lastMove.x);      //lastVert variable in the animator controller to move.x
            anim.SetFloat("lastHorz", lastMove.y);      //lastHorz variable in the animator controller to move.y
        }
            
        anim.SetFloat("verticalSpeed", move.x);     //verticalSpeed variable in the animator controller to move.x
        anim.SetFloat("horizontalSpeed", move.y);   //horizontalSpeed variable in the animator controller to move.y
        anim.SetBool("playerMoving", playerMoving); //Set the playerMoving parameter in the animator

        rigidbody2D.velocity = new Vector2(move.x, move.y);    //Move the player
        maxSpeed = originSpeed;     //Reset the player's speed
    }
}



