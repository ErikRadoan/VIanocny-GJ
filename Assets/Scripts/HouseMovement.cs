using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour
{
    private Transform _transform;
    private GameManager _gameManager;
    [SerializeField] private float moveAmount;
    [SerializeField] private float startTime;
    [SerializeField] private int howManyClicks;
    [SerializeField] private bool isBlack = false;
    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _transform = gameObject.transform;
        StartCoroutine("Move");
    }

    public void OnPressed(bool rightClicked)
    {
        if (isBlack && !rightClicked)
        {
            //Game Lost
        }

        howManyClicks--;
        _gameManager.AddScore(1);
        if (howManyClicks <= 0)
        {
            _gameManager.AddScore(1);
            //Play The Animation
            Destroy(gameObject);
        }

    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(startTime);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, _transform.position.y - moveAmount);
        StartCoroutine("Move");
    }
}
