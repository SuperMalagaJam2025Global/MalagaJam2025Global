using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float time = 15.0f;

    public float timeloop = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        time = timeloop;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= timeloop / 2)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        if (time <= 0)
        {
            time = timeloop;
        }
    }
}
