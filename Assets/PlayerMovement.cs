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
        if (collision.gameObject.tag == "nomask_novax" || collision.gameObject.tag == "nomask_novax_ill")
        {
            if (spacebarStatus)
            {
                collision.gameObject.GetComponent<NoMaskController>().SetMaskSprite();
            }
        }
        if (collision.gameObject.tag == "at_risk_ill")
        {
            if (spacebarStatus)
            {
                collision.gameObject.GetComponent<AtRiskController>().SetOriginalSprite();
            }
        }
        if (collision.gameObject.tag == "vaccinated_ill")
        {
            if (spacebarStatus)
            {
                collision.gameObject.GetComponent<VaccinatedController>().SetOriginalSprite();
            }
        }
        if (collision.gameObject.tag == "infected_character")
        {
            if (spacebarStatus)
            {
                var enemyAIComponent = collision.gameObject.GetComponent<EnemyAi>();
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

