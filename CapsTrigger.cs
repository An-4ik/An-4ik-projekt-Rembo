using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsTrigger : MonoBehaviour
{
    public GameObject Bot;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bot.GetComponent<BotAtak>().anim.SetBool("botAtaks", true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bot.GetComponent<BotAtak>().anim.SetBool("botAtaks", false);
        }
    }



   
}
