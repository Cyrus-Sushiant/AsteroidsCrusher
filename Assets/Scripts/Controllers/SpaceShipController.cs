using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float speed;
    public float fireRate = 0;
    public GameObject bulletPrefab;
    public GameObject[] guns;
    public Animator animatorFlame;

    public int Health => _health;

    [SerializeField]
    private int _health;
    private float lastShoot = 0;

    private const string flameAnimationParameter = "speed";


    public void ShootGun()
    {
        this.Fire();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position += move;
        animatorFlame.SetFloat(flameAnimationParameter, move.sqrMagnitude);

        // Check position
        this.CheckSpaceShipOutOfBounds();

        //Shot
        this.ShootGunWithKeybord();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            _health -= collision.gameObject.GetComponent<BulletController>().power;
        }
        else if (collision.gameObject.tag == "ShipEnemy")
        {
            _health -= collision.gameObject.GetComponent<EnemyShipController>().power;
        }
        else if (collision.gameObject.tag == "Asteroid")
        {
            int asHealth = collision.gameObject.GetComponent<AsteroidController>().health;
            collision.gameObject.GetComponent<AsteroidController>().health -= _health;
            _health -= asHealth;
        }

        this.CheckHealth();
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ShootGunWithKeybord()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Fire();
        }
    }

    private void Fire()
    {
        // Fire bullet
        //Debug.Log("Fire bullet");

        if (Time.time > fireRate + lastShoot)
        {
            foreach (var gun in guns)
            {
                Instantiate(bulletPrefab, gun.transform.position, quaternion.identity);
            }
            lastShoot = Time.time;
        }
    }

    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.05f, 8.05f), Mathf.Clamp(transform.position.y, -4.2f, 3.1f), 0);
    }
}
