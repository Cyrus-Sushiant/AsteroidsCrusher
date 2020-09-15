using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;
    public Sprite[] healthSprite;

    private const string _animationParameterName = "health";
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Called before start
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        else
        {
            this.DoAnimationOrChangeSprite();
        }
    }

    private void DoAnimationOrChangeSprite()
    {
        if (animator != null)
        {
            animator.SetInteger(_animationParameterName, health);
        }
        else
        {
            this.ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = healthSprite[health - 1];
    }
}
