using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {
    [SerializeField]
    private GameObject backToStartMenuButton;

    public void OnBackToStartMenuButtonPressed() {
        gameObject.SetActive(false);

    }

}
