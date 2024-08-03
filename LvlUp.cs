using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LvlUp : MonoBehaviour
{
    Image LevelBar; //������ ������
   public Image helthBar; //������ ��������
    public float maxLvl = 3f; //������������ �������� ������
    public float Lv;
    private int newLvl; // ����� ������� *��� ������ � ��

    public TextMeshProUGUI LevelText; //������� ������

    public GameObject[] health = new GameObject[3]; //������ ������

    public GameObject Player;

    void Start()
    {
        LevelBar = GetComponent<Image>();
        Lv = 0f;
    }


    void Update()
    {
        LevelBar.fillAmount = Lv / maxLvl;
        NewLvl();
    }

    public void TekeScore(float Kiled)
    {
        Lv += Kiled;
    }

    private void NewLvl()
    {
        if (Lv >= maxLvl)
        {
            maxLvl = 1.5f * maxLvl;
            Lv = 0f;
            newLvl++;
            LevelText.text = "Lv. " + newLvl;
            for (int i = 0; i <= 2; i++)
            {
                
                    health[i].SetActive(true);
                helthBar.GetComponent<HelthBar>().HP = 1;
                Player.GetComponent<PlyDamage>().health = 3;

            }
        }
    }
}
