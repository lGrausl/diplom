using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Material Idle;
    public Material Active;
    Material m_Matierial;
    Collider coll;

    private void Awake()
    {
        m_Matierial = GetComponent<Renderer>().material;
        coll = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (coll.Raycast(ray, out hit,Mathf.Infinity))
        {
            active();
        }
        else 
        {
            idle();
        }

    }


    public void idle()
    {
        m_Matierial.color = Idle.color;
    }

    public void active()
    {
        m_Matierial.color = Active.color;
    }
}
