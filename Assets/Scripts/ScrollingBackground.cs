using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    public float Speed = -1.5f;
    [SerializeField] private bool StopScrolling;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = new Vector2(0, Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (StopScrolling)
        {
            Rigidbody.velocity = Vector2.zero;
        }
        else
        {
            Rigidbody.velocity = new Vector2(0, Speed);
        }
    }
}
