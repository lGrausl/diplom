using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHand : MonoBehaviour
{
    public Material Idle;
    public Material Active;
    public Material te;
    Material m_Matierial;
    Collider coll;

    public int result;
    public string resultStr;
    

    public char[] arrPosition = new char[2];
    public int[] arrPosition2 = new int[2];



    private void Awake()
    {
        m_Matierial = GetComponent<Renderer>().material;
        coll = GetComponent<Collider>();



        resultStr = this.gameObject.name;
        int.TryParse(string.Join("", resultStr.Where(c => char.IsDigit(c))), out result);
        resultStr = result.ToString();

        arrPosition = resultStr.ToArray();

        arrPosition2[0] = arrPosition[0] - '0';
        arrPosition2[1] = arrPosition[1] - '0';


    }

    private void FixedUpdate()
    {
        Transform cardChildren = this.transform.GetComponentInChildren<Transform>();

        if (cardChildren != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, Mathf.Infinity) && MoveCard.Card != null)
            {
                m_Matierial.color = Active.color;

                if (gameObject.transform.childCount == 0)
                {
                    MoveCard.Card.transform.SetParent(transform);
                }
            }

            else
            {
                m_Matierial.color = Idle.color;
            }


            if (MoveCard.Card != null)
            {
                if (MoveCard.Card.GetComponent<Specifications>().position[0] == 0 && arrPosition2[1] == 1 && MoveCard.Card.tag == "Card")
                {
                    m_Matierial.color = te.color;
                }
                else if(MoveCard.Card.GetComponent<Specifications>().position[0] == 0 && arrPosition2[1] == 8 && MoveCard.Card.tag == "CardFrag") 
                {
                    m_Matierial.color = te.color;
                }
                else if (
                       (MoveCard.Card.GetComponent<Specifications>().position[0] != 0)
                           &&
                           (
                               arrPosition2[0] <= MoveCard.Card.GetComponent<Specifications>().position[0] + MoveCard.Card.GetComponent<Specifications>().StepDistance[0] && // низ лево
                               arrPosition2[1] >= MoveCard.Card.GetComponent<Specifications>().position[1] - MoveCard.Card.GetComponent<Specifications>().StepDistance[1]
                           )
                           &&
                           (
                               arrPosition2[0] >= MoveCard.Card.GetComponent<Specifications>().position[0] - MoveCard.Card.GetComponent<Specifications>().StepDistance[0] &&   // верх право
                               arrPosition2[1] <= MoveCard.Card.GetComponent<Specifications>().position[1] + MoveCard.Card.GetComponent<Specifications>().StepDistance[1]
                           )
                       )
                {
                    m_Matierial.color = te.color;
                }
            }

            
        }


    }


}
