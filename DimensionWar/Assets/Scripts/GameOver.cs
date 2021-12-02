using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text TotalScore;
    public Text Announce;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        TotalScore.text = "Score points " + score.ToString();
    }

    public void Update()
    {
        if (DevianScript.enemies <= 0)
        {
            Announce.text = "Win";
            Announce.color = Color.green;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
