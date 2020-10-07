using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class ScoreBehavior : MonoBehaviour
{
    [SerializeField] private GameObject ScoreUI;
    private int score;
    Text scoreText;

    private static ScoreBehavior _instance;
    public static ScoreBehavior Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No UIManager Found!");
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = ScoreUI.GetComponent<Text>();
        score = 0;
        scoreText.text = "SCORE: 0";
        //InvokeRepeating("IncreaseScore", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void IncreaseScore(int point)
    {
        score += point;
    }
}
