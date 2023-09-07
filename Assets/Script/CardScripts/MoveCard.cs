using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class MoveCard : MonoBehaviour, IDragHandler , IBeginDragHandler , IEndDragHandler
{

    public static GameObject Card;

    Vector3 StartPos;
    Vector3 StartPosScren;

    float shiftx;
    float shifty;

    Transform Parent;
    public static Transform StartParent;

    public static bool dragged = false;





    public void OnBeginDrag(PointerEventData eventData)
    {

        if (((playerChange.player == true && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag")) && this.gameObject.GetComponent<Click>().action == true)
        {
            Card = gameObject;

            StartParent = Card.transform.parent;
            Parent = transform.parent;

            StartPos = transform.position;
            StartPosScren = Camera.main.WorldToScreenPoint(StartPos);
            shiftx = eventData.position.x - StartPosScren.x;
            shifty = eventData.position.y - StartPosScren.y;
        }


}

    public void OnDrag(PointerEventData eventData)
    {
        if(((playerChange.player == true && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag")) && this.gameObject.GetComponent<Click>().action == true)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x - shiftx, eventData.position.y - shifty, 7));
            transform.position = p;

            Card.GetComponent<Click>().attack = false;

            if (Click.Card != Card) 
            {
                Card.GetComponent<Click>().attack = false;
            }

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if((playerChange.player == true && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag") && this.gameObject.GetComponent<Click>().action == true)
        {
            if (Parent == transform.parent)
            {
                transform.position = StartPos;
            }
            else if (MoveCard.Card.GetComponent<Specifications>().position[0] == 0 && this.transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[1] == 1 && MoveCard.Card.tag == "Card")
            {
                SaveMovement();
            }
            else if (MoveCard.Card.GetComponent<Specifications>().position[0] == 0 && this.transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[1] == 8 && MoveCard.Card.tag == "CardFrag") 
            {
                SaveMovement();
            }
            else if (
                        (MoveCard.Card.GetComponent<Specifications>().position[0] != 0) &&
                            (
                                transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[0] <= MoveCard.Card.GetComponent<Specifications>().position[0] + MoveCard.Card.GetComponent<Specifications>().StepDistance[0] && // down left
                                transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[1] >= MoveCard.Card.GetComponent<Specifications>().position[1] - MoveCard.Card.GetComponent<Specifications>().StepDistance[1]
                            )
                            &&
                            (
                                transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[0] >= MoveCard.Card.GetComponent<Specifications>().position[0] - MoveCard.Card.GetComponent<Specifications>().StepDistance[0] &&   // up right
                                 transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[1] <= MoveCard.Card.GetComponent<Specifications>().position[1] + MoveCard.Card.GetComponent<Specifications>().StepDistance[1]
                            )
                        )
            {
                SaveMovement();
            }
            else
            {
                transform.position = StartPos;
            }
                MoveCard.Card = null;
            
        }

    }

    public void SaveMovement() 
    {
            Action.steps -= Card.GetComponent<Specifications>().ActionPoints;
            transform.localPosition = Vector3.zero;
            Click.Card = null;
            Card.GetComponent<Click>().attack = false;
            Card.GetComponent<Click>().action = false;
            Card.GetComponent<Click>().invulnerability = false;
            Card.GetComponent<Specifications>().position[0] = transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[0];
            Card.GetComponent<Specifications>().position[1] = transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[1];

    }


}
