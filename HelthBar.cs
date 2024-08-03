
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class HelthBar : MonoBehaviour 
{
    Image helthBar; //шакала здоровь€
    public float maxHealth = 3f; //ћаксимальное значение здоровь€
    public float HP;

    void Start()
    {
        helthBar = GetComponent<Image>();
        HP = maxHealth;
    }
        
    // Update is called once per frame
    void Update()
    {
        helthBar.fillAmount = HP / maxHealth;
    }

    public void TakeUron(float Uron)
    {
        HP -= Uron;
       
    }
}
