using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    
    //private float timeScale = 1.0f;
    [SerializeField]
    public static bool isPaused = false;
    

    KeyCode pauseKey = KeyCode.P;
    private Animator animator;

    
    public void OnResumeButtonPressed() {
        Unpause();

    }
    public void OnRestartButtonPressed() {
        return; //not implemented

    }
    public void OnExitToMenuButtonPressed() {
        return; //not implemented

    }

    private void UpdateAnimation() {
        animator.SetBool("isPaused", isPaused);

    }
    private void Pause() {
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

    }
    private void Unpause() {
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

    }

    private void Start() {
        animator = GetComponent<Animator>();
        UpdateAnimation();

    }

    private void Update() {
        //Time.timeScale = timeScale;

        if (Input.GetKeyDown(pauseKey)) {
            if (isPaused) {
                Unpause();
                
            }
            else {
                Pause();

            }

        }
        UpdateAnimation();

    }

}
