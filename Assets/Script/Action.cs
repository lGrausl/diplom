using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public static GameObject oneCard;
    public static GameObject twoCard;

    public static int HiddenStaps;
    public static int steps;

    public int CurrentHealth;
    public int damage;
    public int finalHealth;
    public int finalHealth2;

    private void Awake()
    {
        steps = HiddenStaps = 1;
    }

    private void FixedUpdate()
    {
        if(oneCard && twoCard)
        {
            CurrentHealth = oneCard.GetComponent<Specifications>().CurrentHealth; //1card stats
            damage = twoCard.GetComponent<Specifications>().damage;
            finalHealth = CurrentHealth - damage;

            CurrentHealth = twoCard.GetComponent<Specifications>().CurrentHealth; //2card stats
            damage = oneCard.GetComponent<Specifications>().damage;             
            finalHealth2 = CurrentHealth - damage;


            oneCard.GetComponent<Specifications>().CurrentHealth = finalHealth;
            twoCard.GetComponent<Specifications>().CurrentHealth = finalHealth2;


            oneCard.GetComponent<Click>().action = false;

            oneCard = null;
            twoCard = null;

        }

        if(Action.steps <= 0) 
        {
            playerChange.change();
        }
    }



}
