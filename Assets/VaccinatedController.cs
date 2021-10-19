using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccinatedController : MonoBehaviour
{
    public Sprite infectedSprite;
    public Sprite originalSprite;

    public void SetIllSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = infectedSprite;
        gameObject.tag = "vaccinated_ill";
    }

    public void SetOriginalSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
        gameObject.tag = "vaccinated";

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "infected_character")
        {
            if (Random.value > 0.95)
            {
                SetIllSprite();
            }
        }
    }
}
