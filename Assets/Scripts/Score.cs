using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = score.ToString();
    }

    public int GetScore() {
        return score;
    }

    public void IncramentScore() {
        score += 1;
    }
}
