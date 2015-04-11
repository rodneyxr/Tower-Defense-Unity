using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void PlayGame() {
        Application.LoadLevel("Level00");
    }

    public void Quit() {
        Application.Quit();
    }

}
