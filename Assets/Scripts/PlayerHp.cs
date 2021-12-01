using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public GameObject thePlayer;
    public GameManager theGameManager;

    public static PlayerHp instance;
    public int maxHP = 3;
    public int currentHP;
    public static bool isDead;

    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    private bool isRespawning;
    private Vector3 respawnPoint;
   

    // Start is called before the first frame update
    void Start()
    {
        theGameManager = FindObjectOfType<GameManager>();
        currentHP = maxHP;
        isDead = false;
        thePlayer.transform.position = theGameManager.respawnPoint;
        
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
            // Destroy(gameObject);
            Respawn();
        }
    }

    public void Respawn()
    {
        if(!isRespawning)
        {
            StartCoroutine("RespawnCo");
            
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        

        yield return new WaitForSeconds(1);
        isRespawning = false;
        isDead = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        //thePlayer.transform.position = respawnPoint;
        //currentHP = maxHP;

    }
   
}
