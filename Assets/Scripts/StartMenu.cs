using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public void OnPlayButtonPressed() {
        SceneManager.LoadScene("Game");

    }
    public void OnOptionsButtonPressed() {

    }
    public void OnQuitButtonPressed() {
        Debug.Log("Quitting application.");
        Application.Quit();

    }
    


}
