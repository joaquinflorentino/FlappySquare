using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    private int bestScore;
    private string bestScoreKey = "BestScore";

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int score = GameObject.Find("Score").GetComponent<Score>().GetScore();

        GetComponent<Text>().text = "best: " + bestScore.ToString();

        if (score > bestScore) {
            bestScore = score;
            PlayerPrefs.SetInt(bestScoreKey, bestScore);
            PlayerPrefs.Save();
        }
    }
}
