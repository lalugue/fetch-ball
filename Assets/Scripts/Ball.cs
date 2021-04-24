using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float forceX = 50f;
    public float forceY = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){            
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
        }
    }
}
