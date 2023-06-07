using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distribution : MonoBehaviour
{
    public GameObject hand;

    public float positionY = 3.5f;

    public GameObject[] card = new GameObject[3];

    void Start()
    {
        deal();   
    }


    void deal() 
    {
        for (int i = 0; i < card.Length; i++)
        {
            GameObject gameObject = Instantiate(card[i], card[i].transform.position, Quaternion.identity) as GameObject;
            gameObject.transform.parent = hand.transform;
            gameObject.tag = hand.tag;

            if (gameObject.tag == "Card")
                gameObject.GetComponent<Transform>().position = new Vector3(-5, positionY);
            else
                gameObject.GetComponent<Transform>().position = new Vector3(5, positionY);

            positionY -= 1;
        }

    }
}
