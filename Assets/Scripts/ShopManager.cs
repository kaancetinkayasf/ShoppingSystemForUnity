using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopManager : MonoBehaviour
{
    class Item
    {
        public int _ItemId { get; set; }
        public int _Price { get; set; }
        
    }

    
    public int money = 1500;
    public Text moneyText;

    private void Start()
    {
        //try catch 
        InitializeMoneyData();

        
        //UpdateMoney();
    }

    private void InitializeMoneyData()
    {
        try
        {
            if (PlayerPrefs.HasKey("Money"))
            {
                GetMoneyData();
            }
            else
            {
                PlayerPrefs.SetInt("Money", money);
                GetMoneyData();
            }
        }
        catch
        {
            InitializeMoneyData();
        }
       
    }

    public void Buy(int price)
    {
        try
        {
            // DO WE HAVE ENOUGH MONEY ? 
            if (PlayerPrefs.GetInt("Money") >= price)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
                SaveMoneyData();
                GetMoneyData();
            }
            else
            {
                Debug.Log("Not Enough Money");
            }
        }
        catch
        {
            Buy(price);
        }
        
        
    }

    private void GetMoneyData()
    {

        //load money
        
        money = PlayerPrefs.GetInt("Money");
        moneyText.text = "Money: " + money.ToString();

    }

    private void SaveMoneyData()
    {
        PlayerPrefs.Save();
        
    }

    
    private void UpdateMoney()
    {
        // THIS METHOD IS FOR UPDATING MONEY
        // money = 9000 <--- SOME VALUE YOU WANT
        // PlayerPrefs.SetInt("Money", money) <---- SAVE MONEY KEY
        // moneyText.text = "Money: " + money.ToString(); <----- UPDATE MONEY TEXT ON SHOP MENU
    }

    public void GoToMainMenu()
    {
        try
        {
           SceneManager.LoadScene("Main Menu");
        }
        catch
        {
            GoToMainMenu();
        }
        
    }
}
