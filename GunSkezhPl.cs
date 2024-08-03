using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSkezhPl : MonoBehaviour
{
    public GameObject Player;
    

    //следить за курсором -->
    public float offset;

    void Update()
    {
       
        
            Vector3 diference = Player.transform.position - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        
    }
}
