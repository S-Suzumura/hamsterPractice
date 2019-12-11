using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ham : MonoBehaviour{

    private Rigidbody2D rb = null;
    public float directionX = 0;
    public float directionY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        while(directionX==0||directionY==0){
        directionX = Random.Range(-1,2);
        directionY = Random.Range(-1,2);
        }
        rb.velocity = new Vector2(directionX, directionY);
    }

    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D coll){
        int temp = Random.Range(0,3);
        if(temp==0){
        directionX *= -1;
        } else if(temp==1){
        directionY *= -1;
        } else {
        directionX *= -1;
        directionY *= -1;
        }
        rb.velocity = new Vector2(directionX, directionY);
    }

}