using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public Rigidbody2D rigidBody;
    //public Animator animator;
    Vector2 movement;
    public bool spacebarStatus;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool spacebarStatus = getSpaceBarInput();
        if (collision.gameObject.tag == "infected_area")
        {
            if (spacebarStatus)
            {
                collision.gameObject.SetActive(false);

            }
        }

    }

    private bool getSpaceBarInput() 
    {
        if (Input.GetKey("space")) 
        {
            return true;
        }
        return false;
    }

}

