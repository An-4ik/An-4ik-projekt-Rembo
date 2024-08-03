
using UnityEngine;

public class bulletSlezhka : MonoBehaviour
{

 
    

    //следить за курсором -->
    public float offset;

    void Update()
    {
        if ((Input.GetMouseButton(1)))
        {
            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        }
    }
}