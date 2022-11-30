using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackpack : MonoBehaviour
{

    public int maxNoOfStoreFruit = 50;
    public int currentNoOfFruits;
    [SerializeField] private Text backpackInfoTxt;

    private void Awake()
    {
        setBackPackInfoText(0);
    }
    public int AddFruits(int amount)
    {
        currentNoOfFruits += amount;
        if (currentNoOfFruits > maxNoOfStoreFruit)
            currentNoOfFruits = maxNoOfStoreFruit;
        setBackPackInfoText(currentNoOfFruits);

        return currentNoOfFruits;
    }

    public int TakeFruits()

    {
        int takenFruits = currentNoOfFruits;
        currentNoOfFruits = 0;
        setBackPackInfoText(currentNoOfFruits);
        return takenFruits;
    }

    void setBackPackInfoText(int amount)
    {
        backpackInfoTxt.text = "BackPack: " + amount + "/" + maxNoOfStoreFruit;
    }

    
}//class






















