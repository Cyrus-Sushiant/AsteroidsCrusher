using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;

    private const string _animationParameterName = "health";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        animator.SetInteger(_animationParameterName, health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(health);
        Debug.Log(collision.gameObject.GetComponent<BulletController>().power);
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
