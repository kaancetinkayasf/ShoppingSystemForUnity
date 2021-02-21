using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Text moneyText;
    private ShopManager shopManager;
    private void Start()
    {
        //UPDATE MONEY TEXT ON MAIN MENU
        moneyText.text = "Money: " + PlayerPrefs.GetInt("Money").ToString();
    }

    public void GoToShop()
    {
        try
        {
           SceneManager.LoadScene("Shop");
        }
        catch 
        {
            GoToShop();
        }
        
    }
    
}
