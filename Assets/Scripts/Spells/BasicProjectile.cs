using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BasicProjectile : MonoBehaviour
{
    public float speed = 1;
    public float maxLifetime = 10;
    public GameObject explodePrefab;

    public float damage = 1;

    [HideInInspector] public GameObject player;
    Rigidbody rb;
    float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        BlowUp(collision.GetContact(0).point, collision.gameObject);
    }

    public void BlowUp(Vector3 pos, GameObject hitObject)
    {
        Health health = hitObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Instantiate(explodePrefab, pos, transform.rotation, null);
        Destroy(gameObject);
    }
}
