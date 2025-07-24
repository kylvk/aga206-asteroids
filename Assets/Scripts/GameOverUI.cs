using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    public TMP_Text ScoreTextBox, HighScoreTextBox;
    public GameObject Celebrate, GameOverPanel;
    private Spaceship ship;
    void Start()
    {
        ship = FindFirstObjectByType<Spaceship>();
        Hide();
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void Show(bool celebrateHiScore, int score, int highscore)
    {
        ScoreTextBox.text = "Score: " + score.ToString();
        HighScoreTextBox.text = ship.GetHighScore().ToString();
        GameOverPanel.SetActive(true);
        Celebrate.gameObject.SetActive(celebrateHiScore);
    }
    public void ClickRestart()
    {
        SceneManager.LoadScene("Asteroids");
    }
    public void ClickMenu()
    {
        SceneManager.LoadScene("Title");
    }
}