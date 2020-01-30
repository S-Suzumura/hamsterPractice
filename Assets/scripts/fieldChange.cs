using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fieldChange : MonoBehaviour
{
    public GameObject fieldName;
    public GameObject factoryFood;
    factory script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnClick(int field){
        if(field==0 && factory.viewingField != 0){
            GameObject obj = GameObject.Find("Main Camera");
            obj.transform.position = new Vector3(0,0,-20);
            fieldName.GetComponent<Text>().text = "Field 1";
            factory.viewingField = 0;
        }else if(field==1 && factory.viewingField != 1){
            GameObject obj = GameObject.Find("Main Camera");
            obj.transform.position = new Vector3(10,0,-20);
            fieldName.GetComponent<Text>().text = "Field 2";
            factory.viewingField = 1;
        }else if(field==2 && factory.viewingField != 2){
            GameObject obj = GameObject.Find("Main Camera");
            obj.transform.position = new Vector3(20,0,-20);
            fieldName.GetComponent<Text>().text = "Field 3";
            factory.viewingField = 2;
        }else if(field==3 && factory.viewingField != 3){
            GameObject obj = GameObject.Find("Main Camera");
            obj.transform.position = new Vector3(30,0,-20);
            fieldName.GetComponent<Text>().text = "Field 4";
            factory.viewingField = 3;
        }else if(field==4 && factory.viewingField != 4){
            GameObject obj = GameObject.Find("Main Camera");
            obj.transform.position = new Vector3(40,0,-20);
            fieldName.GetComponent<Text>().text = "Field 5";
            factory.viewingField = 4;
        }
            factoryFood = GameObject.Find ("factory");
            script = factoryFood.GetComponent<factory>();
            script.foodUpdate();

    }
}
