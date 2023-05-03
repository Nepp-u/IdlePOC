using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShop : MonoBehaviour
{

    [SerializeField] private GameObject uiPrefab;
    
    private void Start()
    {
        foreach (var catData in CatManager.Instance.buildings)
        {
            GameObject uiElement = Instantiate(uiPrefab);
            uiElement.transform.SetParent(this.transform);
            Debug.Log("Instantiated");
            uiElement.GetComponent<Cat>().BuildingData = catData;
        }
    }
}
