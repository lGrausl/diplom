using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject target;
    public int damage;




    private void OnMouseDown()
    {

        Health TargetHealht = target.GetComponent<Health>();
        TargetHealht.TakeDamage(damage);
        //if(gameObject.layer == 6)//����
        //{
            
        //}
        //if (gameObject.layer == 7)//����
        //{
            
        //}
        Debug.Log("asd");
    }
}
