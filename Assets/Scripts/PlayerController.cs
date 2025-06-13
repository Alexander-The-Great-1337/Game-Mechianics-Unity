using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private float powerupStrength = 15.0f;
    [SerializeField] private float timePowerupLasts = 7.0f;
    [SerializeField] private GameObject powerupIndicator;

    private Rigidbody rb;

    public bool hasPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        rb.AddForce(fowardInput * speed * focalPoint.transform.forward);

        powerupIndicator.transform.position = new(transform.position.x, -0.5f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPower = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPower)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log($"Collided with {collision.gameObject.name} with powerup set to {hasPower}");
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(timePowerupLasts);
        Debug.Log("Powerup faded");
        hasPower = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
