using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class BasicProjectile : MonoBehaviour
{
    public float speed = 1;
    public float maxLifetime = 10;

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
        Destroy(gameObject);
    }
}
