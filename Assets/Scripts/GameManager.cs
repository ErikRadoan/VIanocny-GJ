using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Passed1");
            RaycastHit2D hit = Physics2D.Raycast(camera.transform.position, Vector2.zero);
            if(hit.collider == null){return;}
            if (!hit.collider.CompareTag("house")){return;}
            Debug.Log("Passed2");
            if(hit.collider.gameObject.GetComponent<HouseMovement>() == null){return;}
            HouseMovement houseMovement = hit.collider.gameObject.GetComponent<HouseMovement>();
            houseMovement.OnPressed(false);
            Debug.Log("Left Clikced");
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.transform.position, -Vector2.zero);
            if(hit.collider == null){return;}
            if (!hit.collider.CompareTag("house")){return;}
            if(hit.collider.gameObject.GetComponent<HouseMovement>() == null){return;}
            HouseMovement houseMovement = hit.collider.gameObject.GetComponent<HouseMovement>();
            houseMovement.OnPressed(true);
            Debug.Log("Right Clikced");
            
        }
    }
}
