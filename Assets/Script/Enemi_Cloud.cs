using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi_Cloud : MonoBehaviour {
    private Rigidbody2D rigi;
    private int lado = 1;
    public float speed;
    public bool moverOn = true;
	// Use this for initialization
	void Start () {
        rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        mover();
	}

    private void mover(){
        if (moverOn){
            rigi.velocity = Vector2.right * speed * lado;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plataforma")
        {
            lado *= -1;
        }
    }
}
