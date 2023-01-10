using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI ScoreText;
    private int score;
    public TextMeshProUGUI HighScoreText;
    private int highScore;
    public TextMeshProUGUI CoinsText;
    private int coinsValue;
    public TextMeshProUGUI WaveText;
    private int waveValue;
    public Image[] LifeSprites;
    public Image HealthBar;
    public Sprite[] HealthBars;
    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void UpdateLives(int l)
    {
        foreach (Image i in instance.LifeSprites)
        {
            i.color = instance.inactive;
        }
        for (int i = 0; i < l; i++)
        {
            instance.LifeSprites[i].color = instance.active;
        }
    }

    public static void UpdateHealthBar(int h)
    {
        instance.HealthBar.sprite = instance.HealthBars[h];
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.ScoreText.text = instance.score.ToString("000,000");
    }

    public static void UpdateHighScore()
    {

    }

    public static void UpdateWave()
    {
        instance.waveValue++;
        instance.WaveText.text = instance.waveValue.ToString();
    }

    public static void UpdateCoins()
    {

    }
}
