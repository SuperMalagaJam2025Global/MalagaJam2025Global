using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float blowSpeed = 1.0f;

    public float fallSpeed = 0.1f;

    BasicPlayerStates basicPlayerStates;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        basicPlayerStates = GetComponent<BasicPlayerStates>();
    }
    void Update()
    {


    }

    void FixedUpdate()
    {
        MovementPlayer();
    }
    private Vector3 Blow(Vector3 dir)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                dir = dir + new Vector3(0, 1, 0) * blowSpeed;
            }

        }

        return dir;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // GameManager.AddTimer(-10);
            // GameManager.GameOver();
            Debug.Log("Game Over!");
            // basicPlayerStates.OnAddToTimer.Invoke(-10);
        }
    }

    private void MovementPlayer()
    {


        Vector3 dir = Vector3.zero;
        // we assume that the device is held parallel to the ground
        // and the Home button is in the right hand

        // remap the device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) rotated 90 degrees around Y axis

        dir.x = Input.acceleration.x;
        // dir.z = Input.acceleration.x;
        dir = Blow(dir);
        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;
        Debug.Log(dir);
        // Move object
        // transform.Translate(dir * speed);
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }
}



