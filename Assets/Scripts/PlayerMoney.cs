using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public TMP_Text moneyText;
    public int moneyCount;
    public static PlayerMoney instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money " + moneyCount.ToString();
    }
}
