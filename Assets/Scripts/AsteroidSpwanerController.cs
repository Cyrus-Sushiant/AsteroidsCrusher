using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpwanerController : MonoBehaviour
{
    public GameObject asteroidPrefab;
    // time
    public float minTime;
    public float maxTime;

    // axis
    public float minAxis;
    public float maxAxis;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Spwan());
        Invoke(nameof(Spwan), Random.Range(minTime, maxTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spwan()
    {
        ShowSpwan();
        Invoke(nameof(Spwan), Random.Range(minTime, maxTime));
    }

    //private IEnumerator Spwan()
    //{
    //    yield return new WaitForSeconds(Random.Range(minTime, maxTime));

    //    ShowSpwan();
    //}

    private void ShowSpwan()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(minAxis, maxAxis);

        Instantiate(asteroidPrefab, position, Unity.Mathematics.quaternion.identity);
    }
}
