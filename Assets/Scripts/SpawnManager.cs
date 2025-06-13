using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject m_EnemyPrefab;

    private readonly float spawnRange = 9;

    // Update is called once per frame
    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Instantiate(m_EnemyPrefab, GetRandomPosition(), m_EnemyPrefab.transform.rotation);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(GetRandomCoordinates(), 0, GetRandomCoordinates());
    }

    private float GetRandomCoordinates()
    {
        return Random.Range(-spawnRange, spawnRange);
    }
}
