using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float scalingFactor;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale + scalingFactor, 0 , 100);

    }
}
