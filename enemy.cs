using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public float pushBackForce = 5f; // Сила отталкивания

    public GameObject Score; // шакала уровня


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Score.GetComponent<LvlUp>().TekeScore(1f);
        }
    }

    public void TakeDimage(int demage/*, Vector3 damageSource*/)
    {
        health -= demage;
        // Вычисляем направление от источника урона
       // Vector3 pushDirection = (transform.position - damageSource).normalized;
        /*
        // Применяем силу отталкивания к персонажу
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(pushDirection * pushBackForce, ForceMode.Impulse);
        }*/
    }
}
