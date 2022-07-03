using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacleObject;

    private bool canSpawn;
    private float timeLengthBtwSpawns = 1.8f;
    private float timeUntilNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextSpawn = timeLengthBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextSpawn <= 0) {
            Spawn();
            timeUntilNextSpawn = timeLengthBtwSpawns;
        }
        else if (canSpawn) {
            timeUntilNextSpawn -= Time.deltaTime;
        }
    }

    public void SetCanSpawn(bool value) {
        canSpawn = value;
    }

    private void Spawn() {
        GameObject newObstacle = Instantiate(obstacleObject, new Vector2(transform.position.x, Random.Range(-3, 3)), Quaternion.identity);
        Destroy(newObstacle, 10f);
    }
}
