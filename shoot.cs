

using UnityEngine;

public class shoot : MonoBehaviour // ����������� ������ � �� ��
{
    

    public LayerMask enemy; //����
    public LayerMask Ply;
    public int demage;// ����
    public float speed; //��������
    public float lifeTime; //����� ������ ����
    public float Distanse;




    void Update()
    {
        BotDmg();
        PlyDmg();
       
    }

    private void BotDmg()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, Distanse, enemy);  // ��������, ��������� ��������
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("enemy"))
            {
                hitInfo.collider.GetComponent<enemy>().TakeDimage(demage);
            }

            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void PlyDmg()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, Distanse, Ply);  // ��������, ��������� ��������
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlyDamage>().BotAtaks = true;

            }
            Destroy(gameObject);
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
   

}
