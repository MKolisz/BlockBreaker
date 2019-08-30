using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 push;
    [SerializeField] AudioClip[] ballSounds;
    [Range(0.1f,1f)] [SerializeField] float randomFactor=0.4f;

    bool bHasStarted = false;
    Vector2 paddleToBallVector;

    AudioSource audioSource;
    Rigidbody2D myRigidbody2D;
    

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bHasStarted)
        {
            LockBallToPaddle();
            LanuchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LanuchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            bHasStarted = true;
            myRigidbody2D.velocity = push;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(-randomFactor,randomFactor), UnityEngine.Random.Range(-randomFactor,randomFactor));

        if (bHasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
