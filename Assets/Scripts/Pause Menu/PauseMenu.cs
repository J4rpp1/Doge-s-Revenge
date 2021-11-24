using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private float timeScale = 1.0f;
    [SerializeField]
    private bool isPaused = false;

    KeyCode pauseKey = KeyCode.P;
    private Animator animator;

    private void UpdateAnimation() {
        animator.SetBool("isPaused", isPaused);

    }

    private void Pause() {
        isPaused = true;
        UpdateAnimation();

    }

    private void Unpause() {
        isPaused = false;
        UpdateAnimation();

    }

    private void Start() {
        animator = GetComponent<Animator>();
        UpdateAnimation();

    }

    private void Update() {
        Time.timeScale = timeScale;

        if (Input.GetKeyDown(pauseKey)) {
            if (isPaused) {
                Unpause();
                
            }
            else {
                Pause();

            }

        }

    }

}
