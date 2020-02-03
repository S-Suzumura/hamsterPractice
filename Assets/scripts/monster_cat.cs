using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_cat : MonoBehaviour
{
    private Rigidbody2D rb = null;
    public GameObject ghost;
    public GameObject Bomb;
    public float moveSpeed = 0;
    int Life = 15;
    // Start is called before the first frame update
    void Start()
    {
        factory.enemyStay = true;
        Life = 15;
        StartCoroutine("CatMove");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    IEnumerator CatMove()
    {
        //入場
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 1f;
        rb.velocity = new Vector2(moveSpeed,0);
        yield return new WaitForSeconds(2);
        //停止・待機
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(2);
        //捕食
        factory.hamsterAmountTotal[factory.targetField] = factory.hamsterAmount[factory.targetField,0] + factory.hamsterAmount[factory.targetField,1] + factory.hamsterAmount[factory.targetField,2];
        int death = Random.Range(4,16+(factory.hamsterAmountTotal[factory.targetField]/4));
        if(death>factory.hamsterAmountTotal[factory.targetField]){
            death = factory.hamsterAmountTotal[factory.targetField];
        }
        for(int X=1;X<=death;X++){
            int Victim = Random.Range(0,3);//ハムスターの種類を選ぶ
            while(factory.hamsterAmount[factory.targetField,Victim] == 0){
                Victim = Random.Range(0,3);
            }
                factory.diedHamster += 1;
                factory.hamsterAmount[factory.targetField,Victim] -= 1;
                factory.hamsterValue -= factory.valuePoints[Victim];
                factory.stress[factory.targetField,Victim] += factory.deathStress[Victim];

            if(factory.visibleHamster[factory.targetField,Victim] >= 1){
                string hamsterName = "";
                //ハムスターを一匹消す
                if(Victim==0){
                    hamsterName = "Field"+(factory.targetField+1)+"_goldenHamster"+(factory.deletedHamster[factory.targetField,Victim]+1)+"(Clone)";
                }else if(Victim==1){
                    hamsterName = "Field"+(factory.targetField+1)+"_djungarianHamster"+(factory.deletedHamster[factory.targetField,Victim]+1)+"(Clone)";
                }else if(Victim==2){
                    hamsterName= "Field"+(factory.targetField+1)+"_roborovskiHamster"+(factory.deletedHamster[factory.targetField,Victim]+1)+"(Clone)";
                }
                GameObject obj = GameObject.Find(hamsterName);
                Vector3 ghostAddress = obj.transform.position;
                Destroy(obj);
                Instantiate(ghost,new Vector3(ghostAddress.x,ghostAddress.y,-3),Quaternion.identity);
                Instantiate(Bomb,new Vector3(ghostAddress.x,ghostAddress.y,-2),Quaternion.identity);


                factory.visibleHamster[factory.targetField,Victim] -= 1;
                factory.deletedHamster[factory.targetField,Victim] += 1;
            }

        yield return new WaitForSeconds(1);
        }
        //退場
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = -1f;
        rb.velocity = new Vector2(moveSpeed,0);
        yield return new WaitForSeconds(2);
        factory.enemyStay = false;
        Destroy(this.gameObject);
        yield return null;
        StopCoroutine("CatMove");
    }

    public void OnClick(){
        Vector3 effectAddress = this.transform.position;
        float temp = Random.Range(-0.5f,0.5f);
        float temp2 = Random.Range(-0.5f,0.5f);
        Instantiate(Bomb,new Vector3(effectAddress.x+temp,effectAddress.y+temp2,-7),Quaternion.identity);
        Life -= 1;
        if(Life<=0){
        factory.enemyStay = false;
        Destroy(this.gameObject);
        StopCoroutine("CatMove");
        }
    }

}
