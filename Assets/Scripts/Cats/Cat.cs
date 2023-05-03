using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] private CatSO buildingData;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI footerText;
    [SerializeField] private Slider tickProgressSlider;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject catPrefab;

    

    public CatSO BuildingData
    {
        get => buildingData;
        set => buildingData = value;
    }

    private void Start()
    {
        buildingData.Reset();
        UpdateText();
        UpdateUIImage();
    }

    private void UpdateUIImage()
    {
        buyButton.image.sprite = buildingData.buildingSprite;
    }

    private void Update()
    {
        UpdateSliderProgress();
    }

    private void UpdateText()
    {
        headerText.text = "Buy " + buildingData.GetBuildingName();
        footerText.text = "Cost: " + buildingData.GetPrice();
    }

    public void OnBuildingBought()
    {
        if (buildingData.GetPrice() < GameManager.Instance.currency)
        {
            GameManager.Instance.currency -= buildingData.GetPrice();
            buildingData.OnUpgradeBought();
            UpdateText();
            SpawnNewCat();
        }
    }
    
    public void UpdateSliderProgress()
    {
        tickProgressSlider.value = buildingData.lastUpdateTime / buildingData.GetUpdateInterval();
    }

    void SpawnNewCat()
    {
        GameObject newCat = Instantiate(catPrefab, new Vector3(-2, 0, 0), quaternion.identity);
        newCat.GetComponent<SpriteRenderer>().sprite = buildingData.buildingSprite;
        newCat.transform.SetParent(CatManager.Instance.transform);
    }
}
