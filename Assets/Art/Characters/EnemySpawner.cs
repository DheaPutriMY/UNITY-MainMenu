using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public Transform[] patrolPoints;

    public int maxEnemies = 3;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }

    void SpawnEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length < maxEnemies)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            EnemyAI ai = enemy.GetComponent<EnemyAI>();

            if (ai != null)
            {
                ai.player = player;
                ai.patrolPoints = patrolPoints;
            }
        }
    }
}