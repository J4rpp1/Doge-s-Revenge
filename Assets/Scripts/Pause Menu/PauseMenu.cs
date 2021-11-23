using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    KeyCode pauseKey = KeyCode.P;
    private Animator animator;

    private void Pause() {
        //Time.timeScale = 0.0f;
        isPaused = true;
        animator.SetBool("isPaused", true);

    }

    private void Resume() {
        //Time.timeScale = 1.0f;
        isPaused = false;
        animator.SetBool("isPaused", false);

    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(pauseKey)) {
            if (isPaused) {
                Resume();
                
            }
            else {
                Pause();

            }

        }

    }


}
