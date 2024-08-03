using UnityEngine;
using UnityEngine.SceneManagement;
//using static Unity.VisualScripting.Icons;
public class restart : MonoBehaviour
{
   public GameObject Manue; //активировать мею
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Paus()
    {
        Time.timeScale = 0f;
        Manue.SetActive(true);

    }

    public void Rusem()
    {
        Time.timeScale = 1f;
        Manue.SetActive(false);
    }

    public void ExitManue()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Manue.SetActive(true);
        } 
       
    }
    

}
