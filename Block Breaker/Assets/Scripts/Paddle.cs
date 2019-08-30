﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minimumX = 1f;
    [SerializeField] float maximumX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, minimumX, maximumX);
        Vector2 paddlePosition = new Vector2(mousePositionInUnits,transform.position.y);
        transform.position = paddlePosition;
    }
}