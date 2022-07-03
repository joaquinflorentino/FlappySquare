using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            GameObject.Find("Score").GetComponent<Score>().IncramentScore();
            GetComponent<AudioSource>().Play();
        }
    }
}
