using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataka : MonoBehaviour
{
    public float TimeBtwAttak; // задержка меж атаками
    public float StatrTimeBtwAttak;

   // public GameObject Score;

    public Transform atacPos; //точка атаки
    public LayerMask enemy; // в каком слое враг
    public float attacRange; //радиус атаки
    public int demage; // урон

    public Animator anim;


    public AudioSource Gunshoot; //звук выстрела
    public void Update()
    {
        if (TimeBtwAttak <= 0) {

            if (Input.GetMouseButtonUp(1))
            {
                anim.enabled = true;
            }

            if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
            {
    
                    anim.SetTrigger("atack"); //атака мечом
                                              // anim.enabled = true;

                // Gunshoot.pitch = Random.Range(0.9f, 1.2f);


                TimeBtwAttak = StatrTimeBtwAttak;
            }
            else if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
            {
                Gunshoot.Play();
                Gunshoot.pitch = Random.Range(0.9f, 1.2f);
                anim.enabled = false;
            }
            //TimeBtwAttak = StatrTimeBtwAttak;
        }
        else
        {
            TimeBtwAttak -= Time.deltaTime;
            //anim.SetBool("atack", false);
        } 
    }

    public void OnAttak()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(atacPos.position, attacRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemy>().TakeDimage(demage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(atacPos.position, attacRange);
    }
}
