using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    private static HUD instance;

    public Text _textStage;
    public Text _textCoins;
    public Text _textMessage;
    public GameObject _panelMessage;

    public static Text textStage;
    public static Text textCoins;
    //public static Text textMessage;
    //public static GameObject panelMessage;

    private static Vector3 cachedBannerPosition;
    private static Vector3 hiddenBannerPosition;

    void Awake() {
        instance = this;
        textStage = _textStage;
        textCoins = _textCoins;
        //textMessage = _textMessage;
        //panelMessage = _panelMessage;

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
