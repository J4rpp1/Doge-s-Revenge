using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public TMP_Text moneyText;
    public int moneyCount;
    public static PlayerMoney instance;
    public AudioSource collect;


    private void Start()
    {
        moneyCount = PlayerPrefs.GetInt("PlayerMoney");
        StartCoroutine(MoneySave());
    }

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money " + moneyCount.ToString();
        
    }

    public void PickupSound()
    {
        collect.Play();
    }
    IEnumerator MoneySave()
    {
        while (true)
        {
            PlayerPrefs.SetInt("PlayerMoney", moneyCount);
            yield return new WaitForSeconds(10);
            //Debug.Log("rahat tallennettu");
        }
    }
}
