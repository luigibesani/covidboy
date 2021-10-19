using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMaskController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite maskSprite;
    public Sprite infectedMaskSprite;
    public Sprite infectedNoMaskSprite;

    public void SetMaskSprite() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = maskSprite;
        gameObject.tag = "mask_novax";
    }

    public void SetIllSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = infectedNoMaskSprite;
        gameObject.tag = "nomask_novax_ill";
    }

    public void SetMaskIllSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = infectedMaskSprite;
        gameObject.tag = "nomask_novax_ill";
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.tag == "infected_character")
        {
            if (gameObject.tag == "mask_novax") 
            {
                if (Random.value > 0.80) 
                {
                    SetMaskIllSprite();
                }
            }
            if (gameObject.tag == "nomask_novax")
            {
                if (Random.value > 0.50)
                {
                    SetIllSprite();
                }
            }
        }
    }
}

