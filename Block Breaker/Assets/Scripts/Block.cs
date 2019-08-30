using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] blockDamagedSprite;
    [SerializeField] float gameAcceleration = 0.02f;

    int maxHits;

    static int howManyBlocks = 0;  
    int timesHit = 0;


      
    private void Start()
    {
        if (tag == "Breakable")
        {
            howManyBlocks++;
            maxHits = blockDamagedSprite.Length + 1;
        }
    }

    private void Update()
    {
        if(howManyBlocks==0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if(timesHit>=maxHits)
            {
                DestroyBlock();
                FindObjectOfType<GameStatus>().SetGameSpeed(gameAcceleration);
            }
            else
            {
                ShowNextBlockDamagedSprite();
            }
        }
    }

    private void ShowNextBlockDamagedSprite()
    {
        int hitIndex = timesHit - 1;
        if (blockDamagedSprite[hitIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = blockDamagedSprite[hitIndex];
        }
        else
        {
            Debug.Log("Block sprite of "+ gameObject.name +" is missing from array");
        }
    }

    private void DestroyBlock()
    {
        howManyBlocks--;
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0.3f);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

