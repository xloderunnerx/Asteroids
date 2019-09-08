using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private static ScoreController _instance;

    [SerializeField] private Text _scoreText;
    private int _score;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            _scoreText.text = "SCORE: " + _score.ToString();
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public static ScoreController GetInstance() => _instance;

    void Start()
    {

    }

    void Update()
    {

    }
}
