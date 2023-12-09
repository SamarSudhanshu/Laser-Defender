using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private List<WaveConfigSO> waveConfig;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping = true;
    private WaveConfigSO currentWave;

    private void Start() {
        StartCoroutine(SpawnEnemyWaves());
    }
    private IEnumerator SpawnEnemyWaves() {
        do {
            foreach(WaveConfigSO wave in waveConfig) {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++) {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.Euler(0, 0, 180), 
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave() {
        return currentWave;
    }
}
