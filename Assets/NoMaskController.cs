using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMaskController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;

    public void SetNewSprite() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        gameObject.tag = "mask_novax";
    }
}
