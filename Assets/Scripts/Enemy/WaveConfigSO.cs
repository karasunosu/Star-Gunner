using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefab; // co the co nhieu enemy khac nhau
    [SerializeField] Transform pathPrefab; // chi can lay vi tri toa do
    [SerializeField] float enemySpeed = 10f;

    // Time
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float timeSpawnVariance = 0.2f;
    [SerializeField] float minTimeBetweenEnemySpawn = 0.2f;

    // wayPoints
    public Transform GetStartWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public Transform[] GetWayPoints()
    {
        Transform[] wayPoints = new Transform[pathPrefab.childCount];

        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            wayPoints[i] = pathPrefab.GetChild(i);
        }

        return wayPoints;
    }

    // Enemy
    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }

    public int GetEnemyCount()
    {
        return enemyPrefab.Length;
    }

    // Time
    public float RandomTimeSpawnEnemy()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - timeSpawnVariance, 
                            timeBetweenEnemySpawn + timeSpawnVariance);
        spawnTime = Mathf.Clamp(spawnTime, minTimeBetweenEnemySpawn, float.MaxValue); // de tranh so am
        return spawnTime;
    }
}
