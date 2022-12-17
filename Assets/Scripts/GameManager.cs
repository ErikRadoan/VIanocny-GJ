using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera _camera;
    private bool _isCameraNotNull;

    private void Start()
    {
        _isCameraNotNull = _camera != null;
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!_isCameraNotNull) {return;}
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, -Vector2.up);
            if (!hit.collider.CompareTag("house")){return;}
            if(hit.collider.gameObject.GetComponent<HouseMovement>())
            {
                HouseMovement houseMovement = hit.collider.gameObject.GetComponent<HouseMovement>();
                houseMovement.OnPressed(false);
                Debug.Log("Left Clikced");
            }
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!_isCameraNotNull) {return;}
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, -Vector2.up);
            if (!hit.collider.CompareTag("house")){return;}
            if(hit.collider.gameObject.GetComponent<HouseMovement>())
            {
                HouseMovement houseMovement = hit.collider.gameObject.GetComponent<HouseMovement>();
                houseMovement.OnPressed(true);
                Debug.Log("Right Clikced");
            }
        }
    }
}
