using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicPlayerStates : MonoBehaviour
{
    float health = 4;
    
    protected UnityEvent GameOverSignal = new();
    public UnityEvent OnGameOverSignal { get { return GameOverSignal; } }    // Start is called before the first frame update

    protected UnityEvent<float> ChangeSize = new();
    public UnityEvent<float> OnChangeSize { get { return ChangeSize; } }    // Start is called before the first frame update

    protected UnityEvent<float> AddToTimer = new();
    public UnityEvent<float> OnAddToTimer { get { return ChangeSize; } }    // Start is called before the first frame update

    void Start()
    {
        //ChangeSize.Invoke(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOverSignal.Invoke();
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "damage": AddToTimer.Invoke(-10); health--; break;
            case "heal": AddToTimer.Invoke(10); break;
            case "powerUp": ChangeSize.Invoke(2); break;
        }
    }
}
