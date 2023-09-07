using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public bool action = false;
    public bool attack = false;
    public bool invulnerability = true;
    public bool character = false;

    public static GameObject Card;
    public static GameObject Cardfrag;



    private void OnMouseUp()
    {

        if (((playerChange.player && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag")) && invulnerability == false && action && character == false && Card == null)
        {
            Card = this.gameObject;
            attack = !attack;

            if (attack)
                GetComponent<SpriteRenderer>().color = Color.red;

        }
        else if (((playerChange.player == false && this.gameObject.tag == "Card") || (playerChange.player && this.gameObject.tag == "CardFrag")) && Card != null && invulnerability == false && Card != this.gameObject)
        {
            Cardfrag = this.gameObject;
            if (
               Mathf.Abs(Card.GetComponent<Specifications>().position[0] - Cardfrag.GetComponent<Specifications>().position[0]) <= Card.GetComponent<Specifications>().StepDistance[0] &&
               Mathf.Abs(Card.GetComponent<Specifications>().position[1] - Cardfrag.GetComponent<Specifications>().position[1]) <= Card.GetComponent<Specifications>().StepDistance[1]
              )
            {
                mapDefinition();
            }
        }

    }


    void mapDefinition()
    {
        Action.oneCard = Card;
        Action.twoCard = Cardfrag;

        Card = null;
        action = false;
        Action.steps -= 1;
        attack = false;
    }



}




