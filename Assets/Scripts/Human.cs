using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject dog;


    void Start()
    {
        
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
            }
        }
    }
}
