using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoText : MonoBehaviour
{
    public Text Text;
    public GameObject card;
    private void Awake()
    {
        
    }
    void Update()
    {
        Text.text = card.GetComponent<Specifications>().CurrentHealth.ToString();
    }
}
