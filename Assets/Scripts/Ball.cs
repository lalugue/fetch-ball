using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float forceX = 50f;
    public float forceY = 50f;
    public float randomMin = 150f;
    public float randomMax = 500f;

    bool canThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow)) && canThrow){
            canThrow = false;
            ThrowBall();
        }
    }

    // alternative way to start game: click ball
    /*
    private void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){ 
            ThrowBall();
        }
    }
    */

    public void ThrowBall(){
        forceX = Random.Range(randomMin, randomMax);           
        forceY = Random.Range(randomMin, randomMax);
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
    }
}
