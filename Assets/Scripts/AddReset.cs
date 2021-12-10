using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReset : MonoBehaviour {
    public void resetSavedData() {
        PlayerPrefs.DeleteAll();
        print("reset savedata");

    }

}
