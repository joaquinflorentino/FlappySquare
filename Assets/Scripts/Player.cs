using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject controlsInfoObject;
    private AudioSource jumpSound;
    private float jumpForce = 7.2f;
    private float gravityToSet = 1.8f;
    private bool isGamePaused;
    private bool hasGameStarted;
    private bool hasGameEnded;
    private bool canPlayerRestart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controlsInfoObject = GameObject.Find("ControlsInfo");
        rb.gravityScale = 0f;
        controlsInfoObject.SetActive(true);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && !isGamePaused) {
            Jump();
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !hasGameEnded) {
            if (!isGamePaused) {
                Pause();
            }
            else {
                Resume();
            }
            GameObject.Find("PauseSoumd").GetComponent<AudioSource>().Play();
        }

        if (canPlayerRestart && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))) {
            RestartGame();
        }
    }

    public void SetHasGameEnded(bool value) {
        hasGameEnded = value;
    }

    private void Jump() {
        if (!hasGameStarted) {
            rb.gravityScale = gravityToSet;
            controlsInfoObject.SetActive(false);
            GameObject.Find("Spawner").GetComponent<Spawner>().SetCanSpawn(true);
            hasGameStarted = true;
        }
        rb.velocity = Vector2.up * jumpForce;
    }

    private void Pause() {
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    private void Resume() {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    private void RestartGame() {
        SceneManager.LoadScene("Main");
        hasGameEnded = false;
        Time.timeScale = 1f;
    }

    private void GameOver() {
        hasGameEnded = true;
        canPlayerRestart = true;
        Time.timeScale = 0f;
        controlsInfoObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Ground")) {
            SceneManager.LoadScene("Main");
        }
        else if (coll.CompareTag("Obstacle")) {
            GameOver();
            GameObject.Find("HitSound").GetComponent<AudioSource>().Play();

        }
    }
}
