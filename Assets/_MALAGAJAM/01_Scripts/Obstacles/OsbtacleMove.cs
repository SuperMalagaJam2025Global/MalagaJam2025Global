using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsbtacleMove : MonoBehaviour
{
    [SerializeField] bool isFish = false;
    public float speed = 6.0f;

    public float speedfish = 6.0f;
    public float time = 15.0f;

    public float timeloop = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (isFish)
        {
            time = timeloop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFish)
        { moveFish(); }

        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }


    void moveFish()
    {
        time -= Time.deltaTime;
        if (time <= timeloop / 2)
        {
            transform.Translate(speedfish * Time.deltaTime * new Vector3(0, -1, 0), Space.World);
        }
        else
        {
            transform.Translate(speedfish * Time.deltaTime * new Vector3(0, 1, 0), Space.World);
        }
        if (time <= 0)
        {
            time = timeloop;
        }
    }

}
