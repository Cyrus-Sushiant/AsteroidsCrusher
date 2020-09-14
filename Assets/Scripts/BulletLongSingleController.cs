using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLongSingleController : MonoBehaviour
{
    public float speed;
    public BulletDirection direction;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        if (direction == BulletDirection.Up)
        {
            move = Vector3.up;
        }
        else
        {
            move = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    // Collision is called
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Remove asteroid
        Destroy(col.gameObject);

        // Remove bullet
        Destroy(gameObject);
    }
}

public enum BulletDirection
{
    Up,
    Down
}
