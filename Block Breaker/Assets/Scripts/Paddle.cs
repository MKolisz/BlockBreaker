using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minimumX = 1f;
    [SerializeField] float maximumX = 15f;

    GameStatus theGameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(GetXPos(),transform.position.y);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if(theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, minimumX, maximumX);
            return mousePositionInUnits;
        }
    }
}
