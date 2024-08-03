
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class HelthBar : MonoBehaviour 
{
    Image helthBar; //шакала здоровья
    public float maxHealth = 3f; //Максимальное значение здоровья
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
