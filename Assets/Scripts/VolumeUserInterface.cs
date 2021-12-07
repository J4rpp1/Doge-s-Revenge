using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUserInterface : MonoBehaviour {
    public Slider volumeSlider;
    public TMP_InputField volumeInputField;

    public float CurrentGameVolume { get; private set; } = 1;
    [SerializeField]
    private string currentText = "100";
    private string safeText;





    public void OnVolumeSliderValueChanged() {
        CurrentGameVolume = volumeSlider.value;
        volumeInputField.text = volumeInputField.text = (CurrentGameVolume * 100f).ToString("f0");
        safeText = (CurrentGameVolume * 100f).ToString("f0");

    }
    public void OnPercentageInputFieldEditEnded() {
        try {
            CurrentGameVolume = float.Parse(volumeInputField.text) * (1f / 100f);

        }
        catch (System.Exception) {
            CurrentGameVolume = float.Parse(safeText) * (1f / 100f);

        }

        volumeInputField.text = (CurrentGameVolume * 100f).ToString("f0");
        safeText = (CurrentGameVolume * 100f).ToString("f0");
        volumeSlider.value = CurrentGameVolume;

    }

    private void Start() {
        currentText = (CurrentGameVolume * 100f).ToString("f0");
        safeText = currentText;

        volumeSlider.onValueChanged.AddListener(delegate {
            OnVolumeSliderValueChanged();
        });
        volumeInputField.onEndEdit.AddListener(delegate {
            OnPercentageInputFieldEditEnded();
        });

        volumeInputField.text = currentText;

    }

}
