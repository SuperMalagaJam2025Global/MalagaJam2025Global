using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsbtacleMove : MonoBehaviour
{
    bool isFish = false;
    public float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }

   
}
