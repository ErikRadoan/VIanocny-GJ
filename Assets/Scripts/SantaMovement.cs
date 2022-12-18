using System;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public GameObject santaPos1;
    public GameObject santaPos2;
    public GameObject santaPos3;
    public GameObject santa;
    public GameObject GameOverCanvas;
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
        RaycastHit2D hit = Physics2D.Raycast(rayCast.transform.position, Vector2.up);
        if(hit.collider == null){return;}
        Debug.Log(hit.collider.name);
        if (hit.collider.CompareTag("RoadObsticle") && hit.collider.transform.position.y < -2.1f)
        {
            Lost();
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

    public void Lost()
    {
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }
}
