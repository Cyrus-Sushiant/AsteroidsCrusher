using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotherShipController : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    public GameObject bulletPrefab;
    public GameObject gun;

    private int direction = 0; // 1 = right, -1= left, 0 = direct

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), 2, 1);
        InvokeRepeating(nameof(Fire), 3, Random.Range(1, 4));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * horizontalSpeed;
        move.y *= verticalSpeed;
        transform.position += move * Time.deltaTime;

        // Check position
        this.CheckSpaceShipOutOfBounds();
    }

    private void CheckSpaceShipOutOfBounds()
    {
        Vector3 positoion = transform.position;
        positoion.x = Mathf.Clamp(transform.position.x, -7.7f, 7.7f);
        transform.position = positoion;
    }

    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2);
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, gun.transform.position, Unity.Mathematics.quaternion.identity);
    }
}
