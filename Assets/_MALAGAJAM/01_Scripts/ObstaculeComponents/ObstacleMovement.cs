using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float BaseVelocity = 0.0f;
    private float velocity = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        var gameVelocity = GameObject.FindWithTag("GameController")
            .GetComponent<GameManager>()
            .GetVelocity();

            velocity = gameVelocity * BaseVelocity;
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += velocity * Time.deltaTime * Vector3.left;
    }
}
