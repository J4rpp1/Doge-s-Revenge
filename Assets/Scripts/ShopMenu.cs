using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GlobalVariables;

public class ShopMenu : MonoBehaviour
{
    PlayerMoney playermoney;
    Gun gun;
    public ShopMenu instance;
    public bool canOpen;
    public int doubleJumpCost = 100;
    public int ammoCost = 10;
   
    public int ammoBonus = 15;

    public int doubleJumpBought;
    public  bool doubleJumpIsActive;
    public bool doublejumppi;
    
    public static bool shopActive;

    public GameObject shopMenuUI;
    public GameObject pressEText;
     
    void Start()
    {
        instance = this;
        gun = FindObjectOfType<Gun>();
        canOpen = false;
        doubleJumpIsActive = false;
        playermoney = FindObjectOfType<PlayerMoney>();
        doubleJumpBought = PlayerPrefs.GetInt("DoubleJump");
        if(doubleJumpBought > 9)
        {
            doubleJumpIsActive = true;
			FindObjectOfType<ECM.Controllers.BaseCharacterController>().EnableDoubleJump(); //Find the controller and enable jumps
            Debug.Log("Doublejump's forcibly actived from ShopMenu");
        }
      /* if(doublejumppi == true)
        {
            doubleJumpIsActive = true;
        }*/
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen == true)
        {
            //Debug.Log("kauppa auki");
            shopMenuUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = Variables.PausedTimeScale; //Always use this when pausing
            shopActive = true;
            pressEText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //Debug.Log("kauppa");
            canOpen = true;
            pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            //Debug.Log("kauppa kii");
            canOpen = false;
            pressEText.SetActive(false);
        }
    }

    public void CloseMenu()
    {
        shopMenuUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        shopActive = false;
        pressEText.SetActive(true);
    }

    public void DoubleJump()
    {
        if (doubleJumpBought < 10 && playermoney.moneyCount >= doubleJumpCost)
        {
            playermoney.moneyCount = playermoney.moneyCount - doubleJumpCost;
            PlayerPrefs.SetInt("DoubleJump", 10);
            doubleJumpIsActive = true;
			FindObjectOfType<ECM.Controllers.BaseCharacterController>().EnableDoubleJump(); //Find the controller and enable jumps on it manually so no restart is required.
        }
    }

    public void Ammo()
    {
        if (playermoney.moneyCount >= 10)
        {
            playermoney.moneyCount = playermoney.moneyCount - ammoCost;
            gun.ammoCount = gun.ammoCount + ammoBonus;
        }
    }
}
