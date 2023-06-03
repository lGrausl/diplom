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

        if(Action.steps == Action.HiddenStaps) 
        {
            this.gameObject.GetComponent<Click>().action = true;
        }
        Debug.Log($"{position[0]}  {position[1]}");
    }





}
