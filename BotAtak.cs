using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAtak : MonoBehaviour
{
    public float TimeBtwAttak; // �������� ��� �������
    public float StatrTimeBtwAttak;

    public GameObject capsulTrigger;

    public GameObject Playr;

    public Transform atacPos; //����� �����
    public LayerMask Player; // � ����� ���� ����
    public float attacRange; //������ �����
    public int demage; // ����

    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }


 

    public void OnBotAttak()
    {
       
        Collider2D[] Ply = Physics2D.OverlapCircleAll(atacPos.position, attacRange, Player);

        for (int i = 0; i < Ply.Length; i++)
        {
            Ply[i].GetComponent<PlyDamage>().BotAtaks = true;
           
        }
        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(atacPos.position, attacRange);
    }
}
