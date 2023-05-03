using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveClick : MonoBehaviour
{
    [SerializeField] private float incomeInterval = 1f;

    public float IncomeInterval => incomeInterval;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            collision.GetComponent<CatAI>().IsCollectingIncome = true;
            collision.GetComponent<CatAI>().StartCollectingIncome(incomeInterval);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            collision.GetComponent<CatAI>().IsCollectingIncome = false;
            collision.GetComponent<CatAI>().StopCollectingIncome(incomeInterval);
        }
    }
    
}
