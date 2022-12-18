using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLost : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }   

    private void Update()
    {
        if (gameObject.transform.position.y < -6)
        {
            _gameManager.Lost();
        }
    }
}
