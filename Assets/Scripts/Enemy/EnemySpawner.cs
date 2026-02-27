using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 0.5f;
    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for(int i = 0; i < wave.GetEnemyCount(); i++)
            {
                Instantiate(wave.GetEnemyPrefab(i), 
                            wave.GetStartWayPoint().position,
                            Quaternion.identity, 
                            this.transform);

                yield return new WaitForSeconds(wave.RandomTimeSpawnEnemy());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
