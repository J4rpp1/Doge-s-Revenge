using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveOnButtonClick : MonoBehaviour
{
    [SerializeField]
    private Button thisButton;
    [SerializeField]
    private GameObject otherObject;
    [SerializeField]
    private bool setTo;



    private void OnButtonClicked() {
        otherObject.SetActive(setTo);

    }

    private void Start() {
        thisButton.onClick.AddListener(delegate {
            OnButtonClicked();

        });

    }

}
