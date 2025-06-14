using UnityEngine;
using UnityEngine.Analytics;

public class Enemy : MonoBehaviour
{
    private Rigidbody m_Rb;
    private GameObject m_Player;

    [Header("Configurações de movimento")]
    [SerializeField, Tooltip("Velocidade do inimigo")]
    private float m_Speed = 5.0f;
    private bool isGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Player = GameObject.Find("Player");
        isGameOver = m_Player.GetComponentInParent<PlayerController>().gameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            m_Rb.AddForce(GetLookDirection() * m_Speed);
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GetLookDirection()
    {
        return (m_Player.transform.position - transform.position).normalized;
    }
}
