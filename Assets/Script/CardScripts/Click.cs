using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public bool action = false;
    public bool invulnerability = true;
    public bool character = false;

    public static GameObject Card;
    public static GameObject Cardfrag;

    private void OnMouseDown()
    {

        if ((playerChange.player && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag") && action && invulnerability == false)
        {
            Card = this.gameObject;

        }
        else if (((playerChange.player == false && this.gameObject.tag == "Card") || (playerChange.player && this.gameObject.tag == "CardFrag")) && Card != null && invulnerability == false && character == false && Card != this.gameObject)
        {
            Cardfrag = this.gameObject;
            Action.oneCard = Card;
            Action.twoCard = Cardfrag;

            Card = null;
            action = false;
            Action.steps -= 1;
        }
        else if(Card != null && (Card.GetComponent<Click>().character == true && this.gameObject.GetComponent<Click>().character == true)) 
        {
            Debug.Log("чипуха");
        }


    }

}




