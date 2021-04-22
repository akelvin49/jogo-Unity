using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_OnGraund : MonoBehaviour {
    public GameObject player;
    private Player playerScript;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies" && !playerScript.death)
        {
            playerScript.onEnemi = true;
        }
        if (collision.gameObject.tag == "Trampolim" && !playerScript.death)
        {
            playerScript.onGraund = true;
            playerScript.onSpring = true;
            collision.GetComponent<Animator>().SetBool("Springer",true);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Plataforma")
        {
            playerScript.onGraund = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            playerScript.onGraund = false;
        }

        if (collision.gameObject.tag == "Trampolim")
        {
            playerScript.onGraund = false;
            playerScript.onSpring = false;
            collision.GetComponent<Animator>().SetBool("Springer",false);
        }
    }
}
