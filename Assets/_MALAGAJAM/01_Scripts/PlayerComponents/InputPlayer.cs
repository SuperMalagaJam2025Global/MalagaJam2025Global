using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float blowSpeed = 1.0f;
    public float fallSpeed = 0.1f;

    BasicPlayerStates basicPlayerStates;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        basicPlayerStates = GetComponent<BasicPlayerStates>();
    }

    private void FixedUpdate()
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
        // if (other.gameObject.tag == "Enemy")
        // {
        //     Destroy(gameObject);
        // }
    }

    private void MovementPlayer()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;

        dir = Blow(dir);

        if (dir.sqrMagnitude > 1)
            dir.Normalize();


        dir *= Time.deltaTime;
        Debug.Log(dir);

        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bubbles")
        {
            Timer.timerInstance.ResetTimer();

        }
        else if (other.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
            SoundTrigger.PlayCustomAudioEvent(ESFXType.Dead);
        }
    }
}