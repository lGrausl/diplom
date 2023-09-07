using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaInfo : MonoBehaviour
{

    void Update()
    {
        this.gameObject.GetComponent<TextMesh>().text = this.transform.parent.gameObject.GetComponent<Specifications>().ActionPoints.ToString();
    }
}
