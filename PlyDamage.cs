

using System;
using UnityEngine;


public class PlyDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedDemage; //скорость оталкивания от урона
    Vector2 targetPos; //куда должно отталкнуть
    public float pushPower; //на сколько далеко отталкнуть

    private bool IsDemage = false;

    public GameObject[] heart = new GameObject[3]; // отоброжение цердец
    public int health; //здоровье
    public GameObject Bar; //шакала здоровья

    public float pushBackForce = 5f; // Сила отталкивания

    // мигание при нанесении урона --->
    private Material MatBlink; // материал - блинка
                               // private Material MatDefault; // Дефолтный спрайт (материал)
    private SpriteRenderer SpriteRend; // просто для работы со спрайтами

    public Animator anim;

   [NonSerialized] public bool BotAtaks = false; // атака от бота с мечом

    private void Start()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
        MatBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material; // присвоить переменной файл "EnemyBlink" ти которого typeof(Material) - в Материал
                                                                               // MatDefault = SpriteRend.material;

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("vrag") || collision.CompareTag("enemy") )
        {
            BotAtaks = true;
            PlayerDemage();
            /*
            health--;
            Bar.GetComponent<HelthBar>().TakeUron(0.33f);
            for (int i = 0; i <= heart.Length; i++)
            {

               // Destroy(heart[health]);
                heart[health].SetActive(false);
               

            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            */
           
            // SpriteRend.material = MatBlink;


            // Вычисляем направление от источника урона
            if (collision.transform.position.x > transform.position.x)
            {
                anim.SetTrigger("PlyDmg");
                //  rb.AddForce(Vector2.left * pushBackForce);
                //rb.velocity = new Vector2(1 * pushBackForce, rb.velocity.y);
                //rb.velocity = new Vector2(rb.velocity.x, pushBackForce);

                IsDemage = true;
                targetPos = new Vector2(transform.position.x - pushPower, transform.position.y);
                /*
                    transform.position = Vector2.MoveTowards(transform.position, targetPos, speedDemage * Time.deltaTime);

                   */
            }
            else if (collision.transform.position.x < transform.position.x)
            {
                anim.SetTrigger("PlyDmg");
               // rb.AddForce(Vector2.right * pushBackForce);  
                // rb.velocity = new Vector2(pushBackForce, rb.velocity.y);

                IsDemage = true;
                targetPos = new Vector2(transform.position.x + pushPower, transform.position.y);

            }


            BotAtaks = false;

        }
    }

    private void PlayerDemage()
    {
        if (BotAtaks)
        {
            health--;
            Bar.GetComponent<HelthBar>().TakeUron(0.33f);
            anim.SetTrigger("PlyDmg");
            IsDemage = true;
            targetPos = new Vector2(transform.position.x - pushPower, transform.position.y);
            for (int i = 0; i <= heart.Length; i++)
            {

                // Destroy(heart[health]);
                heart[health].SetActive(false);


            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            BotAtaks = false;
        } 
    }


    private void Update()
    {
        PlayerPush();
        PlayerDemage();
    }



    public void PlayerPush()
    {
        if (IsDemage)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speedDemage * Time.deltaTime);
            Invoke("End", 0.5f);
        }
       
    }

    public void End()
    {
        IsDemage = false;
    }
}
