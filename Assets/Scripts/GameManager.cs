using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject playerPrefab;
    public GameObject playerSpawnPoint;

    public GameObject[] enemies;
    public GameObject[] enemySpawners;

    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnPlayer();
        SpawnEnemies();
    }

    private void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, playerSpawnPoint.transform.rotation);
    }

    private void SpawnEnemies()
    {
        foreach (GameObject enemySpawner in enemySpawners)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], enemySpawner.transform.position, enemySpawner.transform.rotation);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void RespawnPlayer()
    {
        Destroy(player);
        SpawnPlayer();
    }
}
