using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distribution : MonoBehaviour
{
    public GameObject hand;


    public GameObject[] card = new GameObject[3];

    void Start()
    {
        deal();   
    }


    void deal() 
    {
        for (int i = 0; i < card.Length; i++)
        {
            GameObject gameObject = Instantiate(card[i]);
            gameObject.transform.parent = hand.transform;
            gameObject.tag = hand.tag;
            gameObject.transform.localPosition = Vector3.zero;
        }

    }
}
