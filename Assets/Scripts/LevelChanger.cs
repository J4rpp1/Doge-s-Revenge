using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    [SerializeField]
    private Animator animator;
    private string sceneToLoad;

    public void FadeToLevel(string levelName) {
        sceneToLoad = levelName;
        animator.SetTrigger("FadeOut");

    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);

    }

    private void Update() {
        
    }

}
