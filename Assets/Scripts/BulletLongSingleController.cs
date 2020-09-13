using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLongSingleController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
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
