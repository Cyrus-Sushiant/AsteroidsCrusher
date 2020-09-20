using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public BulletDirection direction;
    public GameObject explosionPrefab;
    public int power;
    public Sprite[] sprites;

    private Vector3 move;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (spriteRenderer != null && sprites != null)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }

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
        // Show fire
        //Instantiate(explosionPrefab, transform.position, Unity.Mathematics.quaternion.identity);
        Instantiate(explosionPrefab, col.contacts[0].point, Unity.Mathematics.quaternion.identity);

        // Remove asteroid
        //Destroy(col.gameObject);

        // Remove bullet
        Destroy(gameObject);
    }
}

public enum BulletDirection
{
    Up,
    Down
}

