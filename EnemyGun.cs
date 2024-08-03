using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour

{
    public GameObject Player;

    public float TimeBtwAttak; // задержка меж атаками
    public float StatrTimeBtwAttak;

    public Transform shotPoint;
    public GameObject bullet; //спрайт выстрела

    //следить за курсором -->
    public float offset;

    void Update()
    {

        PlayerOnDistance();


    }

    /*
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
*/

    public AudioSource shoot;

    private void PlayerOnDistance()
    {
        Vector3 diference = Player.transform.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        
        if (TimeBtwAttak <= 0) //перезарядка
        {

            Instantiate(bullet, shotPoint.position, transform.rotation);
            TimeBtwAttak = StatrTimeBtwAttak;
            shoot.Play();

        }
        else
        {
            TimeBtwAttak -= Time.deltaTime;

        }
    }
}
