using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        StartCoroutine(DestroyThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
