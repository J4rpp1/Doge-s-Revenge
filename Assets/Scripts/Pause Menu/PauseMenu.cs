using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GlobalVariables;


public class PauseMenu : MonoBehaviour {
    [SerializeField]
    public static bool isPaused = false;

    KeyCode pauseKey = KeyCode.P;
    private Animator animator;


    
    public void OnResumeButtonPressed() {
        SetPause(false);

    }

    public void OnRestartButtonPressed() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void OnExitToMenuButtonPressed() {
        SceneManager.LoadScene("StartMenu");

    }
    
    private void SetPause(bool setTo) {
        isPaused = setTo;
        
        if (setTo) {
            Cursor.lockState = CursorLockMode.None;

        }
        else {
            Cursor.lockState = CursorLockMode.Locked;

        }
        Cursor.visible = setTo;

        if (setTo) {
            Time.timeScale = Variables.PausedTimeScale;

        }
        else {
            Time.timeScale = 1.0f;

        }
        animator.SetBool("isPaused", setTo);

    }



    private void Start() {
        animator = GetComponent<Animator>();
        SetPause(false);

    }

    private void Update() {
        if (Input.GetKeyDown(pauseKey) || Input.GetKeyDown(KeyCode.Escape)) 
		{
            SetPause(!isPaused);

        }

    }

}
