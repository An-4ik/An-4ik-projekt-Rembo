using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public float pushBackForce = 5f; // ���� ������������

    public GameObject Score; // ������ ������


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
        // ��������� ����������� �� ��������� �����
       // Vector3 pushDirection = (transform.position - damageSource).normalized;
        /*
        // ��������� ���� ������������ � ���������
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(pushDirection * pushBackForce, ForceMode.Impulse);
        }*/
    }
}
