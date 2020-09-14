using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= collision.gameObject.GetComponent<BulletController>().power;

        this.CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Unity.Mathematics.quaternion.identity);
            Destroy(gameObject);
        }
    }
}
