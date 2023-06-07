using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoText : MonoBehaviour
{


    void Update()
    {
        this.gameObject.GetComponent<TextMesh>().text = this.transform.parent.gameObject.GetComponent<Specifications>().CurrentHealth.ToString();
    }
}
