using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private float m_Speed = -1.5f;
    [SerializeField] private bool m_StopScrolling;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = new Vector2(0, m_Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_StopScrolling)
        {
            Rigidbody.velocity = Vector2.zero;
        }
        else
        {
            Rigidbody.velocity = new Vector2(0, m_Speed);
        }
    }
}
