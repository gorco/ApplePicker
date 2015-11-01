using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {

    private int highScore = 0;
    private int score = 0;
    private UnityEngine.UI.Text text;

    void Awake()
    {
        Debug.Log("AWAKE");
        // If the ApplePickerHighScore already exists, read it
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        } else
        {
            highScore = 0;
        }

        if (PlayerPrefs.HasKey("ApplePickerScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerScore");
        }
        else
        {
            score = 0;
        }

        text = GetComponent<UnityEngine.UI.Text>();
    }

    void Start()
    {
        Debug.Log("START");
        text.text = "HIGH SCORE" + '\n' +
                    highScore + '\n' + '\n' +
                    "SCORE" + '\n' +
                    score;
    }
}
