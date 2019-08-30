using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    int collisionCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;
        if (collisionCount == FindObjectsOfType<Ball>().Length)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
