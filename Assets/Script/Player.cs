using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private const float RIGHT_LIMIT = 108.3972f;
    private const float LEFT_LIMIT = -11.4f;
    public float DOWN_LIMIT = -15.8f;
    private Rigidbody2D rigi;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public bool onGraund;
    public bool onSpring;
    public bool onEnemi;
    public GameObject checkPoint;
    public float speed;
    public int coins;
    public int lives;    
    public float jumpForce;
    public Text textLives;
    public Text textCoins;
    public bool death;
    public Vector3 posicaoInicial = new Vector3(-9.45f, 1.962239f, 0f);


    

    // Use this for initialization
    void Start () {
        //this.transform.position = posicaoInicial;
        this.rigi = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        textLives.text = lives.ToString();
        textCoins.text = coins.ToString();
        death = false;


    }
	
	// Update is called once per frame
	void Update () {
        if (!death)
        {
            Pular();
        }
               
    }

    void FixedUpdate(){
        if (!death)
        {
            Andar();
            Limit();
        }
        

        
    }

    private void Pular(){

        if(Input.GetButtonDown("Jump") && onGraund)
        {
            rigi.AddForce(new Vector2(0f, jumpForce));
        }if (onSpring){
            rigi.AddForce(new Vector2(0f, jumpForce * 1.05f));
        }
        if (!onGraund) {
            animator.SetBool("Jumping", true);
        }if (onGraund)
        {
            animator.SetBool("Jumping", false);
        }

        
    }

    private void Andar(){
        float movimento = Input.GetAxis("Horizontal");
        animator.SetBool("Walking", movimento != 0);
        rigi.velocity = new Vector2(movimento * speed, rigi.velocity.y);
        if (movimento != 0)
        {
            if (movimento < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movimento > 0)
            {
                spriteRenderer.flipX = false;
            }
            
        }
        
    }

    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!death) { 
            
            if (other.gameObject.tag == "Coins")
            {
                Destroy(other.gameObject);
                coins++;
                textCoins.text = coins.ToString();
            }
            if (other.gameObject.tag == "ChechPoint")
            {
                if (checkPoint == null)
                {
                    checkPoint = other.gameObject;
                }
                else
                {
                    GameObject lastCheck = other.gameObject;
                    
                    if (lastCheck.transform.position.x > checkPoint.transform.position.x)
                    {
                        checkPoint = lastCheck;
                        Debug.Log("Checado");

                    }
                }
                other.gameObject.GetComponent<Animator>().SetBool("Check", true);
            }
        }
    }

    public void Death()
    {
        death = true;
        animator.SetBool("Jumping", false);
        animator.SetBool("Death", true);
        GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    private void Limit()
    {
        if (transform.position.x <= LEFT_LIMIT)
        {
            transform.position = new Vector3(LEFT_LIMIT, transform.position.y, 0f);
        }
        if (transform.position.x >= RIGHT_LIMIT)
        {
            transform.position = new Vector3(RIGHT_LIMIT, transform.position.y, 0f);
        }
        if (transform.position.y <= DOWN_LIMIT && death == false)
        {
            rigi.AddForce(new Vector2(0f, 1400));
            Death();
        }
    }
}
