using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class steps : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = Action.steps.ToString();

        if (playerChange.player)
            GetComponent<Text>().color = Color.green;
        else
            GetComponent<Text>().color = Color.red;
    }
}
