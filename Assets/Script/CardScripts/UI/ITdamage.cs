using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ITdamage : MonoBehaviour
{
    public Text Text;
    public GameObject card;

    void Update()
    {
        Text.text = card.GetComponent<Specifications>().damage.ToString();
    }
}
