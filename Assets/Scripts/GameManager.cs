using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject lostMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider == null){return;}
            if (!hit.collider.CompareTag("House")){return;}
            if(hit.collider.gameObject.GetComponent<HouseMovement>() == null){return;}
            HouseMovement houseMovement = hit.collider.gameObject.GetComponent<HouseMovement>();
            houseMovement.OnPressed(false);
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.zero);
            if(hit.collider == null){return;}
            if (!hit.collider.CompareTag("House")){return;}
            if(hit.collider.gameObject.GetComponent<HouseMovement>() == null){return;}
            HouseMovement houseMovement = hit.collider.gameObject.GetComponent<HouseMovement>();
            houseMovement.OnPressed(true);

        }
    }

    public void Lost()
    {
        lostMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
