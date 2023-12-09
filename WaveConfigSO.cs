using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Config", menuName = "New Way Config")]
public class WaveConfigSO : ScriptableObject {

    [SerializeField] private List<GameObject> enemyPrefabs;   
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenEnemySpawns = 1f;
    [SerializeField] private float spawnTimeVariance = 0f;
    [SerializeField] private float minimumSpawnTime = 0.2f;

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public Transform GetStartingWayPoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints() {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab) {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, 
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
