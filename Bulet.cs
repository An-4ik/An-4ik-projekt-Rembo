using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    private float TimeBtwAttak; // задержка меж атаками
    public float StatrTimeBtwAttak;

    public Transform shotPoint;
    public GameObject bullet; //спрайт выстрела

    //следить за курсором -->
    public float offset;

    void Update()
    {
        if ((Input.GetMouseButton(1)))
        {
            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

            if (TimeBtwAttak <= 0)
            {
                if ((Input.GetMouseButtonDown(0)))  //стрельба
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                    TimeBtwAttak = StatrTimeBtwAttak;
                }
            }
            else
            {
                TimeBtwAttak -= Time.deltaTime;

            }
        }
    }
}