using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    private GameObject currentMonster;
    private bool isWaiting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 1f);
    }

    // Update is called once per frame
    void SpawnAMonster()
    {
        if(spawnAllowed && currentMonster == null && !isWaiting)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            currentMonster = Instantiate(monsters [randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);

            currentMonster.GetComponent<Inimigo>().SetOnDeathCallback(OnMonsterDeath);
        }
    }

    void OnMonsterDeath()
    {
        StartCoroutine(WaitBeforeNextSpawn(3f));  // Espera 3 segundos antes de gerar o próximo monstro
    }

    IEnumerator WaitBeforeNextSpawn(float waitTime)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }
}
