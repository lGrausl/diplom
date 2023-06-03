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

        if ((playerChange.player && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag"))
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
        if((playerChange.player && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag"))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x - shiftx, eventData.position.y - shifty, 7));
            transform.position = p;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if((playerChange.player && this.gameObject.tag == "Card") || (playerChange.player == false && this.gameObject.tag == "CardFrag"))
        {

            if (Parent == transform.parent)
            {
                transform.position = StartPos;
            }
            else
            {
                Action.steps -= 1;
                transform.localPosition = Vector3.zero;
                Card.GetComponent<Click>().action = true;
                Card.GetComponent<Click>().invulnerability = false;
            }
            Card.GetComponent<Specifications>().position[0] = transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[0];
            Card.GetComponent<Specifications>().position[1] = transform.parent.gameObject.GetComponent<PlayerHand>().arrPosition2[1];

            MoveCard.Card = null;
        }

    }


}
