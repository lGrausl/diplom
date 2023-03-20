using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int StartHealth;
    public int CurrentHealth;

    private void Awake()
    {
        CurrentHealth = StartHealth;
    }
    public void TakeDamage(int amount)  
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0) 
        {
           gameObject.SetActive(false);
        }
    }
}
