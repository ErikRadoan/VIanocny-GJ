using System;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public GameObject santaPos1;
    public GameObject santaPos2;
    public GameObject santaPos3;
    public GameObject santa;
    [SerializeField] private GameObject rayCast;
    private int _santaPosition;
    void Start()
    {
        santa.transform.position = santaPos2.transform.position;
        _santaPosition = 2;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _santaPosition = Mathf.Clamp(_santaPosition - 1, 1 , 3);
            UpdatePosition();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _santaPosition = Mathf.Clamp(_santaPosition + 1, 1 , 3);
            UpdatePosition();
        }
        RaycastHit2D hit = Physics2D.Raycast(rayCast.transform.position, Vector2.up, 0.1f);
        if(hit.collider == null){return;}
        
        if (hit.collider.tag  == "RoadObsticle")
        {
            //Lost
            Debug.Log("Lost");
        } else if (hit.collider.tag == "Devil")
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void UpdatePosition()
    {
        switch (_santaPosition)
        {
            case 1:
                santa.transform.position = santaPos1.transform.position;
                break;
            case 2:
                santa.transform.position = santaPos2.transform.position;
                break;
            case 3:
                santa.transform.position = santaPos3.transform.position;
                break;
        }
        
    }
}
