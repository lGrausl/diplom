using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Specifications : MonoBehaviour
{
    public int StartHealth;
    public int CurrentHealth;
    public int damage;
    public int[] StepDistance = new int[2];
    public int[] position = new int[2] {0,0};



    private void Awake()
    {
        CurrentHealth = StartHealth;
    }



    private void FixedUpdate()
    {

        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }



        if (this.gameObject.GetComponent<Click>().action == true && this.gameObject.GetComponent<Click>().attack == false)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (this.gameObject.GetComponent<Click>().action == false)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            this.gameObject.GetComponent<Click>().attack = false;
        }



        if (Action.steps == Action.HiddenStaps && Action.steps % 2 == 1)
        {
            if (this.gameObject.tag == "Card")
                this.gameObject.GetComponent<Click>().action = true;
            else
                this.gameObject.GetComponent<Click>().action = false;

        }
        else if (Action.steps == Action.HiddenStaps && Action.steps % 2 == 0)
        {
            if (this.gameObject.tag == "Card")
                this.gameObject.GetComponent<Click>().action = false;
            else
                this.gameObject.GetComponent<Click>().action = true;

        }



        
    }


}
