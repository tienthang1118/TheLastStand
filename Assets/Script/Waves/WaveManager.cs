using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Waves setup")]
    [SerializeField]
    private Wave[] waves;

    [Header("Wave duration")]
    [SerializeField]
    private float waveDuration;

    [Header("Wave break time duration")]
    [SerializeField]
    private float breaktimeDuration;

    private int currentWaveIndex;

    private EnemiesSpawner enemiesSpawner;

    private AbilitiesManager abilitiesManager;

    public int EnemyNumbers = 0;
    private void Awake()
    {
        enemiesSpawner = FindObjectOfType<EnemiesSpawner>();
        abilitiesManager = FindObjectOfType<AbilitiesManager>();
    }
    void Start()
    {
        currentWaveIndex = 0;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];

            foreach (EnemiesSetup enemiesSetup in currentWave.enemies)
            {
                for (int i = 0; i < enemiesSetup.count; i++)
                {
                    enemiesSpawner.SpawnZombie(enemiesSetup.prefab);
                    EnemyNumbers++;
                    yield return new WaitForSeconds((waveDuration - breaktimeDuration) / currentWave.enemies.Length / enemiesSetup.count);
                }
            }
            yield return new WaitForSeconds(breaktimeDuration);
            StartCoroutine(abilitiesManager.ChooseAbility());
            currentWaveIndex++;
        }
    }
}
