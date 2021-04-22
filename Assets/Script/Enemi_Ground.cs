using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi_Ground : MonoBehaviour {
    private Rigidbody2D rigi;
    private SpriteRenderer sprite;
    private Animator anim;
    public float lado = 1;

	// Use this for initialization
	void Start () {
        this.rigi = GetComponent<Rigidbody2D>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        rigi.velocity = new Vector2(2.5f * lado, rigi.velocity.y);
        flip();
        anim.SetBool("Walking", true);
    }

    void flip(){
        if (lado > 0){
            sprite.flipX = false;
        }
        if (lado < 0)        {
            sprite.flipX = true;
        }
    }
}
