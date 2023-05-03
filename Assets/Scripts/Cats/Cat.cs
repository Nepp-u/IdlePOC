using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] private CatSO catData;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI footerText;
    [SerializeField] private Slider tickProgressSlider;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject catPrefab;

    
    public CatSO BuildingData
    {
        get => catData;
        set => catData = value;
    }

    private void Start()
    {
        catData.Reset();
        UpdateText();
        UpdateUIImage();
    }

    private void UpdateUIImage()
    {
        buyButton.image.sprite = catData.catSprite;
    }

    private void Update()
    {
        UpdateSliderProgress();
    }

    private void UpdateText()
    {
        headerText.text = "Buy " + catData.GetCatName();
        footerText.text = "Cost: " + catData.GetPrice();
    }

    public void OnBuildingBought()
    {
        if (catData.GetPrice() < GameManager.Instance.currency)
        {
            GameManager.Instance.currency -= catData.GetPrice();
            catData.OnUpgradeBought();
            UpdateText();
            SpawnNewCat();
        }
    }
    
    public void UpdateSliderProgress()
    {
        tickProgressSlider.value = catData.lastUpdateTime / catData.GetUpdateInterval();
    }

    void SpawnNewCat()
    {
        GameObject newCat = Instantiate(catPrefab, new Vector3(-2, 0, 0), quaternion.identity);
        newCat.GetComponent<SpriteRenderer>().sprite = catData.catSprite;
        newCat.transform.SetParent(CatManager.Instance.transform);
    }
}
