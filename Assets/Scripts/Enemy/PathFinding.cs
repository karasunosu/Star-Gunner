using System;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] wayPoints;
    int wayPointIndex = 0;

    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(wayPointIndex < wayPoints.Length)
        {
            Vector3 newPos = wayPoints[wayPointIndex].position;
            float moveDelta = waveConfig.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, newPos, moveDelta);
            if(transform.position == newPos)
            {
                ++wayPointIndex;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
