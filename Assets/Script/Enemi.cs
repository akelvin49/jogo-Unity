using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour {
    public int lives;
    public GameObject coinDrop;
    public GameObject lifeDrop;

	
	// Update is called once per frame
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.GetComponent<Player>().death)
        {
            if (!collision.GetComponent<Player>().onEnemi || GetComponent<Animator>().GetBool("Rage"))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 7);
                collision.GetComponent<Player>().Death();
            }
            else
            {
                if (!collision.GetComponent<Player>().onGraund)
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 7);
                    if (lives > 1)
                    {
                        if (lives > 2)
                        {
                            StartCoroutine("Rage", 2.2f);
                        }
                        else
                        {
                            StartCoroutine("Rage", 2.5f);
                        }
                        
                    }else
                    {
                        StartCoroutine("AutoDestruction");
                    }
                }
                else
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 7);
                    collision.GetComponent<Player>().Death();
                }

            }
            collision.GetComponent<Player>().onGraund = false;
            collision.GetComponent<Player>().onEnemi = false;
        }
    }

    IEnumerator AutoDestruction() {
        GetComponent<Animator>().SetBool("Puft", true);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

    IEnumerator Rage(float time)
    {
        lives--;
        GetComponent<Animator>().SetBool("Rage", true);
        yield return new WaitForSeconds(time);
        GetComponent<Animator>().SetBool("Rage", false);
    }
}
