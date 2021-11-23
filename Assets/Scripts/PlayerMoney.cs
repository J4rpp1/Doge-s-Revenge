using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public TMP_Text moneyText;
    public int moneyCount;
    public static PlayerMoney instance;


    private void Start()
    {
        moneyCount = PlayerPrefs.GetInt("PlayerMoney");
    }

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money " + moneyCount.ToString();
        PlayerPrefs.SetInt("PlayerMoney", moneyCount);
    }
}
