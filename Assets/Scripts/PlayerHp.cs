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
    public bool isDead;
    public bool canTakeDamage;
    public bool takingDamage;

    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    private bool isRespawning;
    private Vector3 respawnPoint;
    Rigidbody m_Rigidbody;
	[SerializeField]
	bool startAtCheckPoint;
    


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        takingDamage = false;
        canTakeDamage = true;
        theGameManager = FindObjectOfType<GameManager>();
        currentHP = maxHP;
        isDead = false;
		if(startAtCheckPoint)
        	thePlayer.transform.position = theGameManager.respawnPoint;
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (canTakeDamage == false && takingDamage == false)
        {
            StartCoroutine(Invulnerability());
        }
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
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
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
    public IEnumerator Invulnerability()
    {
        takingDamage = true;
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
        Debug.Log("Ei voi ottaa damagea");
        takingDamage = false;
    }


}
