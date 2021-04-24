using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public int velocity = 5;
    public float jumpForce = 20f;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            Vector3 position = this.transform.position;            
            this.transform.position += Vector3.left * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            Vector3 position = this.transform.position;            
            this.transform.position += Vector3.right * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && canJump){
            canJump = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    void OnCollisionEnter2D(){
        canJump = true;
    }

}
