using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamsterMove : MonoBehaviour{

    private Rigidbody2D rb = null;
    public GameObject heart;
    public float directionX = 0;
    public float directionY = 0;
    public static float[] love = new float[] {0,0,0};


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionX = Random.Range(0.3f,2f);
        int temp = Random.Range(0,2);
        if(temp == 1){
            directionX *= -1;
        }
        directionY = Random.Range(0.3f,2f);
        temp = Random.Range(0,2);
        if(temp == 1){
            directionY *= -1;
        }
        rb.velocity = new Vector2(directionX, directionY);
    }

    void Update()
    {

    }


    public void OnClick(int type){
        Vector3 heartAddress = this.transform.position;
        Instantiate(heart,new Vector3(heartAddress.x,heartAddress.y,-3),Quaternion.identity);

        love[type] += 2f/factory.hamsterAmount[factory.viewingField,type];
        if(love[type]>=1 && factory.stress[factory.viewingField,type] > 0){
            factory.stress[factory.viewingField,type] -= 1;
            love[type] = 0;
        }

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