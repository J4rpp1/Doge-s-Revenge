using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUserInterface : MonoBehaviour {
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private TMP_InputField volumeInputField;
    [SerializeField]
    private string volumePrefKey = "CurrentGameVolume";

    public float CurrentGameVolume { get; private set; } = 1;
    [SerializeField]
    private string currentText;
    private string safeText;





    private float GetVolumeSliderValue() {
        return volumeSlider.value;

    }
    private float GetPercentageInputFieldValue() {
        float output;
        try {
            output = float.Parse(volumeInputField.text) * (1f / 100f);

        }
        catch (System.Exception) {
            output = float.Parse(safeText) * (1f / 100f);

        }
        return output;

    }

    public void OnVolumeSliderValueChanged() {
        CurrentGameVolume = GetVolumeSliderValue();
        OnCurrentGameVolumeChanged();


    }
    public void OnPercentageInputFieldEditEnded() {
        CurrentGameVolume = GetPercentageInputFieldValue();
        OnCurrentGameVolumeChanged();

    }
    private void OnCurrentGameVolumeChanged() {
        string formatted = (CurrentGameVolume * 100f).ToString("f0");
        safeText = formatted;
        volumeInputField.text = formatted;
        volumeSlider.value = CurrentGameVolume;


        PlayerPrefs.SetFloat(key: volumePrefKey, value: CurrentGameVolume);

        // bad way to do this
        PlayerPrefs.Save();

    }

    private void Start() {
        currentText = (PlayerPrefs.GetFloat(key: volumePrefKey, defaultValue: 1.0f) * 100f).ToString("f0");
        safeText = currentText;
        volumeInputField.text = currentText;
        volumeSlider.value = PlayerPrefs.GetFloat(key: volumePrefKey, defaultValue: 1.0f);

        volumeSlider.onValueChanged.AddListener(delegate {
            OnVolumeSliderValueChanged();
        });
        volumeInputField.onEndEdit.AddListener(delegate {
            OnPercentageInputFieldEditEnded();
        });
        
    }

}
