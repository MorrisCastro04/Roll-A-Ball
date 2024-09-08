using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score = 0;
    public TMP_Text scoreText;
    public static GameManager instance;
    public int totalPoints = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int point)
    {
        score += point;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText)
        {
            scoreText.text = score.ToString() + "/" + totalPoints.ToString();
        }
    }
}
