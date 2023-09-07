using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Specifications : MonoBehaviour
{
    public int StartHealth;
    public int CurrentHealth;
    public int damage;
    public int ActionPoints;
    public int[] StepDistance = new int[2];
    public int[] position = new int[2] {0,0};
    public GameObject BackPlane;
    public Material standart,red,green;


    private void Awake()
    {
        CurrentHealth = StartHealth;

    }

    private void Start()
    {
        standart = BackPlane.GetComponent<Renderer>().material;
        if (gameObject.tag == "Card")
        {
            standart.color = green.color;
        }
        else
        {
            standart.color = red.color;
        }
    }

    private void FixedUpdate()
    {
        if (this.gameObject.GetComponent<Specifications>().ActionPoints > Action.steps) 
        {
            this.gameObject.GetComponent<Click>().action = false;
        }
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            if (this.gameObject.gameObject.GetComponent<Click>().character == true) 
            {
                if (this.gameObject.name == "character 1") 
                {
                    Camera.main.GetComponent<ButtonMainMenu>().loadScenWin1();
                }
                else if(this.gameObject.name == "character 2")
                {
                    Camera.main.GetComponent<ButtonMainMenu>().loadScenWin2();
                }
            }
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



        if ((Action.steps == Action.HiddenStaps && Action.steps % 2 == 1) && Action.steps >= this.ActionPoints)
        {
            if (this.gameObject.tag == "Card")
                this.gameObject.GetComponent<Click>().action = true;
            else
                this.gameObject.GetComponent<Click>().action = false;

        }
        else if ((Action.steps == Action.HiddenStaps && Action.steps % 2 == 0) && Action.steps >= this.ActionPoints)
        {
            if (this.gameObject.tag == "Card")
                this.gameObject.GetComponent<Click>().action = false;
            else
                this.gameObject.GetComponent<Click>().action = true;

        }



        
    }


}
