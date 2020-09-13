using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;

        // Check position
        this.CheckSpaceShipOutOfBounds();

        //Shot
        this.ShootGun();
    }

    private void ShootGun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Fire bullet
            //Debug.Log("Fire bullet");

            Instantiate(bulletPrefab, gun.transform.position, quaternion.identity);
        }
    }

    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.05f, 8.05f), Mathf.Clamp(transform.position.y, -4.2f, 3.1f), 0);
    }
}
