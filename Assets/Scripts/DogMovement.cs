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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            Vector3 position = this.transform.position;            
            this.transform.position += Vector3.left * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            Vector3 position = this.transform.position;            
            this.transform.position += Vector3.right * velocity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (jumpCount < jumpLimit)){
            jumpCount++;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        jumpCount = 0;
        //canJump = true; //for single jumping

        if(col.collider.gameObject.name == "Ball"){
            hasBall = true;
            GameObject.Destroy(col.collider.gameObject);
        }
    }

    public bool getHasBall(){
        return hasBall;
    }



}
