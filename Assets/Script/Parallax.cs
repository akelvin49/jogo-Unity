using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Vector2 startPosition = new Vector2(153.52f, 2);
    public Vector2 endPosition = new Vector2(-28.6f, 2);
    public float speed = 6;


    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (this.transform.position.x <= endPosition.x)
        {
            this.transform.position = startPosition;
        }
    }

    private void Move()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
