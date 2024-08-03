

using System;
using UnityEngine;


public class PlyDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedDemage; //�������� ����������� �� �����
    Vector2 targetPos; //���� ������ ����������
    public float pushPower; //�� ������� ������ ����������

    private bool IsDemage = false;

    public GameObject[] heart = new GameObject[3]; // ����������� ������
    public int health; //��������
    public GameObject Bar; //������ ��������

    public float pushBackForce = 5f; // ���� ������������

    // ������� ��� ��������� ����� --->
    private Material MatBlink; // �������� - ������
                               // private Material MatDefault; // ��������� ������ (��������)
    private SpriteRenderer SpriteRend; // ������ ��� ������ �� ���������

    public Animator anim;

   [NonSerialized] public bool BotAtaks = false; // ����� �� ���� � �����

    private void Start()
    {
        SpriteRend = GetComponent<SpriteRenderer>();
        MatBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material; // ��������� ���������� ���� "EnemyBlink" �� �������� typeof(Material) - � ��������
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


            // ��������� ����������� �� ��������� �����
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
