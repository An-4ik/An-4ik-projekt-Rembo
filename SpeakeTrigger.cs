using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeakeTrigger : MonoBehaviour
{
    public GameObject PressButton; // ������ ������ ��� ������� *���������
    public GameObject SpekText; // ��������� �����
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PressButton.SetActive(true);
           
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PressButton.SetActive(false);

        }
    }


    private void TextTime()
    {
        SpekText.SetActive(false);
    }

    private void FixedUpdate()
    {
        Press();
    }
    void Press()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpekText.SetActive(true);
            PressButton.SetActive(false);
            Invoke("TextTime", 3f);
        }
    }
}
