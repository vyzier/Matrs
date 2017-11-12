using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickNumberManager : MonoBehaviour
{

    public int waterValue;
    public int foodValue;
    public int medicationValue;
    public int firstAidValue;
    public int toolsValue;
    public int clothingValue;
    public int waterCount;
    public int foodCount;
    public int medicationCount;
    public int firstAidCount;
    public int toolsCount;
    public int clothingCount;

    public Text waterCount1;
    public Text foodCount1;
    public Text medicationCount1;
    public Text firstAidCount1;
    public Text toolsCount1;
    public Text clothingCount1;

    public Text waterCount2;
    public Text foodCount2;
    public Text medicationCount2;
    public Text firstAidCount2;
    public Text toolsCount2;
    public Text clothingCount2;

    public Text waterText;
    public Text foodText;
    public Text medicationText;
    public Text firstAidText;
    public Text toolsText;
    public Text clothingText;

    public Text waterCO;
    public Text foodCO;
    public Text medicationCO;
    public Text firstAidCO;
    public Text toolsCO;
    public Text clothingCO;
    public Text waterCOText;
    public Text foodCOText;
    public Text medicationCOText;
    public Text firstAidCOText;
    public Text toolsCOText;
    public Text clothingCOText;
    public Image waterImg;
    public Image foodImg;
    public Image medicationImg;
    public Image firstAidImg;
    public Image toolsImg;
    public Image clothingImg;

    public Text checkoutTotal;


    public void WaterInc()
    {
        waterValue++;
        UpdateUI();
    }

    public void WaterDec()
    {
        if (waterValue > 0)
            waterValue--;

        UpdateUI();
    }

    public void FoodInc()
    {
        foodValue++;
        UpdateUI();
    }

    public void FoodDec()
    {
        if (foodValue > 0)
            foodValue--;

        UpdateUI();
    }

    public void MedicationInc()
    {
        medicationValue++;
        UpdateUI();
    }

    public void MedicationDec()
    {
        if (medicationValue > 0)
            medicationValue--;

        UpdateUI();
    }

    public void FirstAidInc()
    {
        firstAidValue++;
        UpdateUI();
    }

    public void FirstAidDec()
    {
        if (firstAidValue > 0)
            firstAidValue--;

        UpdateUI();
    }

    public void ToolsInc()
    {
        toolsValue++;
        UpdateUI();
    }

    public void ToolsDec()
    {
        if (toolsValue > 0)
            toolsValue--;

        UpdateUI();
    }

    public void ClothingInc()
    {
        clothingValue++;
        UpdateUI();
    }

    public void ClothingDec()
    {
        if (clothingValue > 0)
            clothingValue--;

        UpdateUI();
    }

    public float CalculateWater()
    {
        return (0.99f * waterValue);
    }

    public float CalculateFood()
    {
        return (2.5f * foodValue);
    }

    public float CalculateMedication()
    {
        return (3.25f * medicationValue);
    }

    public float CalculateFirstAid()
    {
        return (10.5f * firstAidValue);
    }

    public float CalculateTools()
    {
        return (12.45f * toolsValue);
    }

    public float CalculateClothing()
    {
        return (5.7f * clothingValue);
    }

    public float CalculatePrice()
    {
        return CalculateWater() +
               CalculateFood() +
               CalculateMedication() +
               CalculateFirstAid() +
               CalculateTools() +
               CalculateClothing();
    }

    public void UpdateCheckoutUI()
    {
        // Show only the things that were donated
        waterCOText.text = waterValue.ToString() + " x $0.99";
        foodCOText.text = foodValue.ToString() + " x $2.50";
        medicationCOText.text = medicationValue.ToString() + " x $3.25";
        firstAidCOText.text = firstAidValue.ToString() + " x $10.50";
        toolsCOText.text = toolsValue.ToString() + " x $12.45";
        clothingCOText.text = clothingValue.ToString() + " x $5.70";

        if (waterValue <= 0)
        {
            waterCO.gameObject.SetActive(false);
            waterCOText.gameObject.SetActive(false);
            waterImg.gameObject.SetActive(false);
        }
        else
        {
            waterCO.gameObject.SetActive(true);
            waterCOText.gameObject.SetActive(true);
            waterImg.gameObject.SetActive(true);
        }

        if (foodValue <= 0)
        {
            foodCO.gameObject.SetActive(false);
            foodCOText.gameObject.SetActive(false);
            foodImg.gameObject.SetActive(false);
        }
        else
        {
            foodCO.gameObject.SetActive(true);
            foodCOText.gameObject.SetActive(true);
            foodImg.gameObject.SetActive(true);
        }

        if (medicationValue <= 0)
        {
            medicationCO.gameObject.SetActive(false);
            medicationCOText.gameObject.SetActive(false);
            medicationImg.gameObject.SetActive(false);
        }
        else
        {
            medicationCO.gameObject.SetActive(true);
            medicationCOText.gameObject.SetActive(true);
            medicationImg.gameObject.SetActive(true);
        }

        if (firstAidValue <= 0)
        {
            firstAidCO.gameObject.SetActive(false);
            firstAidCOText.gameObject.SetActive(false);
            firstAidImg.gameObject.SetActive(false);
        }
        else
        {
            firstAidCO.gameObject.SetActive(true);
            firstAidCOText.gameObject.SetActive(true);
            firstAidImg.gameObject.SetActive(true);
        }

        if (toolsValue <= 0)
        {
            toolsCO.gameObject.SetActive(false);
            toolsCOText.gameObject.SetActive(false);
            toolsImg.gameObject.SetActive(false);
        }
        else
        {
            toolsCO.gameObject.SetActive(true);
            toolsCOText.gameObject.SetActive(true);
            toolsImg.gameObject.SetActive(true);
        }

        if (clothingValue <= 0)
        {
            clothingCO.gameObject.SetActive(false);
            clothingCOText.gameObject.SetActive(false);
            clothingImg.gameObject.SetActive(false);
        }
        else
        {
            clothingCO.gameObject.SetActive(true);
            clothingCOText.gameObject.SetActive(true);
            clothingImg.gameObject.SetActive(true);
        }

        checkoutTotal.text = "$" + CalculatePrice();
    }

    public void UpdateAfterDonate()
    {
        waterCount -= waterValue;
        foodCount -= foodValue;
        medicationCount -= medicationValue;
        firstAidCount -= firstAidValue;
        toolsCount -= toolsValue;
        clothingCount -= clothingValue;

        waterValue = 0;
        foodValue = 0;
        medicationValue = 0;
        firstAidValue = 0;
        toolsValue = 0;
        clothingValue = 0;

        waterCount1.text = waterCount.ToString();
        foodCount1.text = foodCount.ToString();
        medicationCount1.text = medicationCount.ToString();
        firstAidCount1.text = firstAidCount.ToString();
        toolsCount1.text = toolsCount.ToString();
        clothingCount1.text = clothingCount.ToString();
    }

    private void UpdateUI()
    {
        waterText.text = waterValue.ToString();
        foodText.text = foodValue.ToString();
        medicationText.text = medicationValue.ToString();
        firstAidText.text = firstAidValue.ToString();
        toolsText.text = toolsValue.ToString();
        clothingText.text = clothingValue.ToString();

        waterCount2.text = (waterCount - waterValue).ToString();
        foodCount2.text = (foodCount - foodValue).ToString();
        medicationCount2.text = (medicationCount - medicationValue).ToString();
        firstAidCount2.text = (firstAidCount - firstAidValue).ToString();
        toolsCount2.text = (toolsCount - toolsValue).ToString();
        clothingCount2.text = (clothingCount - clothingValue).ToString();
    }
}
