using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public GameObject santaPos1;
    public GameObject santaPos2;
    public GameObject santaPos3;
    public GameObject santa;

    // Start is called before the first frame update
    void Start()
    {
        santa.transform.position = santaPos2.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            santa.transform.position = santaPos1.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            santa.transform.position = santaPos2.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            santa.transform.position = santaPos3.transform.position;
        }
    }
}
