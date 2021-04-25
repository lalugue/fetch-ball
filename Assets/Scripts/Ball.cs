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
    public float timeToThrow = 0.3f;
    float startTime;

    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow)) && canThrow && ((Time.time - startTime) >= timeToThrow)){
            canThrow = false;
            ThrowBall();
            timer.GetComponent<Timer>().RunTime();
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

    //called after instantiating ball (eg: from Human)
    public void SetTimerManager(GameObject timeManager){
        timer = timeManager;
    }
}
