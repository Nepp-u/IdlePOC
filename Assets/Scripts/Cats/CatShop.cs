using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShop : MonoBehaviour
{

    [SerializeField] private GameObject uiPrefab;

    private void Start()
    {
        foreach (var catData in CatManager.Instance.cats)
        {
            GameObject uiElement = Instantiate(uiPrefab);
            uiElement.transform.SetParent(this.transform);
            uiElement.GetComponent<Cat>().BuildingData = catData;
        }
    }
}
