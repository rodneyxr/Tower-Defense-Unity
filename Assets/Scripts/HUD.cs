using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    private static HUD instance;

    public Text _textStage;
    public Text _textCoins;
    public Text _textEnemies;
    public Text _textLife;
    public Text _textMessage;
    public GameObject _panelMessage;
    public GameObject _panelGameOver;
    public Button _buttonStart;

    public static Text textStage;
    public static Text textCoins;
    public static Text textEnemies;
    public static Text textLife;
    public static Button buttonStart;
    public static GameObject panelGameOver;

    void Awake() {
        instance = this;
        textStage = _textStage;
        textCoins = _textCoins;
        textEnemies = _textEnemies;
        textLife = _textLife;
        buttonStart = _buttonStart;
        panelGameOver = _panelGameOver;

        // setup message panel
        _panelMessage.SetActive(false);
        _textMessage.text = "";
    }

    public static void DisplayMessage(string message) {
        instance.StartCoroutine(instance.ShowMessage(message));
    }

    IEnumerator ShowMessage(string message) {
        _panelMessage.SetActive(true);
        _textMessage.text = message;
        yield return new WaitForSeconds(3f);
        _panelMessage.SetActive(false);
        _textMessage.text = "";
    }

}
