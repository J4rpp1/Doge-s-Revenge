using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour {
    
    public Slider volumeSlider;
    public TMP_InputField volumeInputField;


    public StartMenu() {
        currentText = (currentGameVolume * 100f).ToString("f0");
        safeText = currentText;

    }

    public float currentGameVolume { get; private set; } = 1 ;
    [SerializeField]
    private string currentText;
    private string safeText;

    

    public void OnPlayButtonPressed() {
        SceneManager.LoadScene("Game");

    }
    public void OnOptionsButtonPressed() {

    }
    public void OnQuitButtonPressed() {
        Debug.Log("Quitting application.");
        Application.Quit();

    }
    private void UpdateVolumeUserInterface() {

    }

    public void ParseStuff() {

    }
    public void OnVolumeSliderValueChanged() { 
        currentGameVolume = volumeSlider.value;
        volumeInputField.text = volumeInputField.text = (currentGameVolume * 100f).ToString("f0");
        safeText = (currentGameVolume * 100f).ToString("f0");

        Debug.Log("The value of gameVolume is " + currentGameVolume.ToString());

    }
    public void OnPercentageInputFieldEditEnded() {
        try {
            currentGameVolume = float.Parse(volumeInputField.text) * (1f / 100f);

        }
        catch (System.FormatException) {
            currentGameVolume = float.Parse(safeText) * (1f / 100f);

        }

        volumeInputField.text = (currentGameVolume * 100f).ToString("f0");
        safeText = (currentGameVolume * 100f).ToString("f0");
        volumeSlider.value = currentGameVolume;

        Debug.Log("The value of gameVolume is " + currentGameVolume.ToString());
    }

    private void Start() {
        volumeSlider.onValueChanged.AddListener(delegate {
            OnVolumeSliderValueChanged();
        });
        volumeInputField.onEndEdit.AddListener(delegate {
            OnPercentageInputFieldEditEnded();
        });

        volumeInputField.text = currentText;

    }
    private void Update() {
        

    }

}
