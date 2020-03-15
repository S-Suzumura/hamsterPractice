using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_drone : MonoBehaviour
{
    private Rigidbody2D rb = null;
    public GameObject ghost;
    public GameObject Bomb;
    public float moveSpeed = 0;
    int Life = 20;
    // Start is called before the first frame update
    void Start()
    {
        factory.machineStay = true;
        Life = 20;
        StartCoroutine("DroneMove");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    IEnumerator DroneMove()
    {
        //入場
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = -1f;
        rb.velocity = new Vector2(moveSpeed,0);
        yield return new WaitForSeconds(2);
        //停止・待機
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(2);
        //攻撃

        while(factory.feedMachine[factory.machineTargetField] >= 1){
            GameObject target = GameObject.Find("Field"+(factory.machineTargetField+1)+"_feedMachine(Clone)");
            Vector3 effectAddress = target.transform.position;
            float temp = Random.Range(-0.5f,0.5f);
            float temp2 = Random.Range(-0.5f,0.5f);
            Instantiate(Bomb,new Vector3(effectAddress.x+temp,effectAddress.y+temp2,-5),Quaternion.identity);
            factory.feedMachine[factory.machineTargetField] -= 2;

            if(factory.feedMachine[factory.machineTargetField] <= 0){
                Destroy(target);
            }

            yield return new WaitForSeconds(0.5f);
        }

        while(factory.waterPot[factory.machineTargetField] >= 1){
            GameObject target = GameObject.Find("Field"+(factory.machineTargetField+1)+"_waterPot(Clone)");
            Vector3 effectAddress = target.transform.position;
            float temp = Random.Range(-0.5f,0.5f);
            float temp2 = Random.Range(-0.5f,0.5f);
            Instantiate(Bomb,new Vector3(effectAddress.x+temp,effectAddress.y+temp2,-5),Quaternion.identity);
            factory.waterPot[factory.machineTargetField] -= 2;

            if(factory.waterPot[factory.machineTargetField] <= 0){
                Destroy(target);
            }

            yield return new WaitForSeconds(0.5f);
        }

        while(factory.wheel[factory.machineTargetField] >= 1){
            GameObject target = GameObject.Find("Field"+(factory.machineTargetField+1)+"_wheel(Clone)");
            Vector3 effectAddress = target.transform.position;
            float temp = Random.Range(-0.5f,0.5f);
            float temp2 = Random.Range(-0.5f,0.5f);
            Instantiate(Bomb,new Vector3(effectAddress.x+temp,effectAddress.y+temp2,-5),Quaternion.identity);
            factory.wheel[factory.machineTargetField] -= 2;

            if(factory.wheel[factory.machineTargetField] <= 0){
                Destroy(target);
            }

            yield return new WaitForSeconds(0.5f);
        }

        while(factory.house[factory.machineTargetField] >= 1){
            GameObject target = GameObject.Find("Field"+(factory.machineTargetField+1)+"_house(Clone)");
            Vector3 effectAddress = target.transform.position;
            float temp = Random.Range(-0.5f,0.5f);
            float temp2 = Random.Range(-0.5f,0.5f);
            Instantiate(Bomb,new Vector3(effectAddress.x+temp,effectAddress.y+temp2,-5),Quaternion.identity);
            factory.house[factory.machineTargetField] -= 2;

            if(factory.house[factory.machineTargetField] <= 0){
                Destroy(target);
            }

            yield return new WaitForSeconds(0.5f);
        }


        //退場
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 1f;
        rb.velocity = new Vector2(moveSpeed,0);
        yield return new WaitForSeconds(2);
        factory.machineStay = false;
        Destroy(this.gameObject);


        yield return null;
        StopCoroutine("DroneMove");
    }

    public void OnClick(){
        Vector3 effectAddress = this.transform.position;
        float temp = Random.Range(-0.5f,0.5f);
        float temp2 = Random.Range(-0.5f,0.5f);
        Instantiate(Bomb,new Vector3(effectAddress.x+temp,effectAddress.y+temp2,-7),Quaternion.identity);
        Life -= 1;
        if(Life<=0){
        factory.machineStay = false;
        Destroy(this.gameObject);
        StopCoroutine("DroneMove");
        }
    }



}
