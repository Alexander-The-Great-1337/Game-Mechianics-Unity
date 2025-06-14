using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject m_EnemyPrefab;
    [SerializeField] private GameObject m_PowerupPrefab;

    private readonly float spawnRange = 9f;

    private float numberOfEnemies = 1;

    public int enemyCount;

    // Update is called once per frame
    void Start()
    {
        SpawnEnemyWave(numberOfEnemies);
        Instantiate(m_PowerupPrefab, GenerateRandomPosition(), m_PowerupPrefab.transform.rotation);
    }

    private void Update()
    {
        SpawnNewEnemyWave();
    }

    private void SpawnEnemyWave(float enemiesToRespawn)
    {
        for(int i = 0; i < enemiesToRespawn; i++)
        {
            Instantiate(m_EnemyPrefab, GenerateRandomPosition(), m_EnemyPrefab.transform.rotation);
        }
    }

    private void SpawnNewEnemyWave()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(++numberOfEnemies);
            Instantiate(m_PowerupPrefab, GenerateRandomPosition(), m_PowerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        return new Vector3(GetRandomCoordinates(), 0, GetRandomCoordinates());
    }

    private float GetRandomCoordinates()
    {
        return Random.Range(-spawnRange, spawnRange);
    }
}
