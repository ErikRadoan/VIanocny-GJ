using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float moveAmount;
    [SerializeField] private float startTime;
    private void Awake()
    {
        _transform = gameObject.transform;
        StartCoroutine("Move");
    }

    public void OnPressed(bool rightClicked)
    {
        
        
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(startTime);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, _transform.position.y - moveAmount);
        StartCoroutine("Move");
    }
}
