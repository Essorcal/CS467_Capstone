using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    enum dir { UP = 0, DOWN, LEFT, RIGHT };
    dir lastDir = dir.DOWN, currentDir = dir.DOWN;
    public float runSpeedMultiplier = 1.05f;
    public float maxSpeed = .75f;
    float originSpeed;
    bool movePlayer, facingRight = true;
    new Rigidbody2D rigidbody2D;


    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        originSpeed = maxSpeed;
    }

    void FixedUpdate()
    {
        Vector2 move = Vector2.zero;
        rigidbody2D = GetComponent<Rigidbody2D>();

        move.x = Input.GetAxis("Horizontal"); //Get the horizontal axis
        move.y = Input.GetAxis("Vertical");     //Get the vertical axis

        anim.SetFloat("verticalSpeed", move.x);    //verticalSpeed variable in the animator controller to move.x
        anim.SetFloat("horizontalSpeed", move.y);   //horizontalSpeed variable in the animator controller to move.y

        lastDir = currentDir = GetDirection(move);
        SetIdle(currentDir);

        if (Input.GetKey("left shift") || Input.GetKey("right shift"))  //Add the running multiplier
            maxSpeed = 4 * runSpeedMultiplier;

        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("move"))
            rigidbody2D.velocity = new Vector2(move.x * maxSpeed, move.y * maxSpeed);    //Move the player
        else
            rigidbody2D.velocity = new Vector2(0, 0);

        maxSpeed = originSpeed;     //Reset the player's speed;

        //movePlayer = false;
        //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("up") && currentDir == dir.UP) movePlayer = true;
        //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("down") && currentDir == dir.DOWN) movePlayer = true;
        //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("left") && currentDir == dir.LEFT) movePlayer = true;
        //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("right") && currentDir == dir.RIGHT) movePlayer = true;

        //if (movePlayer)
        //    rigidbody2D.velocity = new Vector2(move.x * maxSpeed, move.y * maxSpeed);    //Move the player
        //else
        //    rigidbody2D.velocity = new Vector2(0, 0);

    }

    //Gets the current direction the player is running
    dir GetDirection(Vector2 move)
    {
        if (move.x >= .01 && move.y >= .01)
            return dir.UP;
        if (move.x >= .01 && move.y <= -.01)
            return dir.RIGHT;
        if (move.x <= -.01 && move.y >= .01)
            return dir.LEFT;
        if (move.x <= -.01 && move.y <= -.01) 
            return dir.DOWN; 

        if (move.x >= .01)
            return dir.RIGHT;
        if (move.x <= -.01)
            return dir.LEFT;
        if (move.y >= .01)
            return dir.UP;
        if (move.y <= -.01)
            return dir.DOWN;

        return lastDir;
    }

    //Sets the direction the player will face when He/She is idle
    void SetIdle(dir direction)
    {
        anim.SetBool("up", direction == dir.UP ? true : false);
        anim.SetBool("down", direction == dir.DOWN ? true : false);
        anim.SetBool("left", direction == dir.LEFT ? true : false);
        anim.SetBool("right", direction == dir.RIGHT ? true : false);
    }
}



