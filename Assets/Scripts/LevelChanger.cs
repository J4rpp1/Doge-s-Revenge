using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    private Animator animator;
    private string sceneToLoad;

    public void FadeToLevel(string levelNameString) {
        sceneToLoad = levelNameString;
        animator.SetTrigger("FadeOut");

    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);

    }

    private void Start() {
        animator = GetComponent<Animator>();

    }
    private void Update() {
        
    }

}
