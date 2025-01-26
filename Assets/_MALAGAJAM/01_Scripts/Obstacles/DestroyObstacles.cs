using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Bubbles") || other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
        }
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
