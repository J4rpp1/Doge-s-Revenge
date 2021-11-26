using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp instance;
    public int maxHP = 3;
    public int currentHP;
    public static bool isDead;

    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        isDead = false;
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHP)
            {
                hearts[i].sprite = fullHearth;
            }
            else
            {
                hearts[i].sprite = emptyHearth;
            }
            if( i< maxHP)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (currentHP <= 0 && isDead == false)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
