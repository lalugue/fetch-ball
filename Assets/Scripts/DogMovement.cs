using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public int velocity = 5;
    public float jumpForce = 20f;
    //bool canJump = true; //for single jumping
    int jumpCount = 0; //for double-jumping
    int jumpLimit = 2;

    bool hasBall = false;

    public AudioClip jump;
    AudioSource audioSource;
    public GameObject audioManager;

    SpriteRenderer spriteRenderer;
    bool flipSprite = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioManager.GetComponent<AudioSource>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            Vector3 position = this.transform.position;            
            this.transform.position += Vector3.left * velocity * Time.deltaTime; 
            FlipSprite(true);
                       
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            Vector3 position = this.transform.position;            
            this.transform.position += Vector3.right * velocity * Time.deltaTime;
            FlipSprite(false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (jumpCount < jumpLimit)){
            jumpCount++;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            audioSource.PlayOneShot(jump, 0.7F);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        jumpCount = 0;
        //canJump = true; //for single jumping

        if(col.collider.gameObject.tag == "Ball"){
            hasBall = true;
            GameObject.Destroy(col.collider.gameObject);
        }
    }

    public bool getHasBall(){
        return hasBall;
    }

    public void TakeBallFromDog(){
        hasBall = false;
    }

    void FlipSprite(bool flip){
        if(flipSprite != flip){
            spriteRenderer.flipX = flip;
            flipSprite = flip;
        }
    }



}
