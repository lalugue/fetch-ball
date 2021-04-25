using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject dog;
    public GameObject scorer;
    public GameObject ball;
    public Transform ballPosition;


    public AudioClip coin;
    AudioSource audioSource;
    public GameObject audioManager;
    public GameObject timer;

    void Start()
    {
        audioSource = audioManager.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){            
        if(col.gameObject.name == "Dog"){            
            if(dog.GetComponent<DogMovement>().getHasBall())
            {
                Debug.Log("Good boy!");
                timer.GetComponent<Timer>().StopTime();
                scorer.GetComponent<Scorer>().AddScore();
                dog.GetComponent<DogMovement>().TakeBallFromDog();
                SpawnNewBall();
                audioSource.PlayOneShot(coin, 0.7F);

            }
        }
    }

    void SpawnNewBall(){
        Instantiate(ball, ballPosition.position, Quaternion.identity);
    }
}
