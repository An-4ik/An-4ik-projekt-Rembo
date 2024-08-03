
using UnityEngine;

public class CameraOnMous : MonoBehaviour
{
    public GameObject Cell;
    public Transform Garaj;

    private void Start()
    {
        Cell = GetComponent<GameObject>();
    }
    void Update()
    {
        OnPreC�ll();
    }
    Vector2 screenPosition = Input.mousePosition;
   // Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
    private void OnPreC�ll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = new Vector2(screenPosition.x, screenPosition.y);
        }
        else
        {
            transform.position = Garaj.position;
        }
    }
}
