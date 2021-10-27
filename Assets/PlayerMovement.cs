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

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool spacebarStatus = getSpaceBarInput();
        var collisionObject = collision.gameObject;
        if (collisionObject.tag == "infected_area")
        {
            if (spacebarStatus)
            {
                collisionObject.SetActive(false);
            }
        }
        if (collisionObject.tag == "nomask_novax")
        {
            if (spacebarStatus)
            {
                collisionObject.GetComponent<NoMaskController>().SetMaskSprite();
            }
        }
        if (collisionObject.tag == "nomask_novax_ill")
        {
            if (spacebarStatus)
            {
                collisionObject.GetComponent<NoMaskController>().SetNoMaskSprite();
            }
        }
        if (collisionObject.tag == "at_risk_ill")
        {
            if (spacebarStatus)
            {
                collisionObject.GetComponent<AtRiskController>().SetOriginalSprite();
            }
        }
        if (collisionObject.tag == "vaccinated_ill")
        {
            if (spacebarStatus)
            {
                collisionObject.GetComponent<VaccinatedController>().SetOriginalSprite();
            }
        }
        if (collisionObject.tag == "infected_character")
        {
            if (spacebarStatus)
            {
                var enemyAIComponent = collisionObject.GetComponent<EnemyAi>();
                enemyAIComponent.SetIsolationDestination();
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

