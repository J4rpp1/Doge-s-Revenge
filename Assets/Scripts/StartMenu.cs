using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    [SerializeField]
    private GameObject optionsMenu;

    public void OnPlayButtonPressed() {
        //SceneManager.LoadScene("Game");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load next scene

    }
    public void OnOptionsButtonPressed() {
        optionsMenu.SetActive(true);

    }
    public void OnQuitButtonPressed() {
        Debug.Log("Quitting application.");
        Application.Quit();

    }

}
