using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hamsterAdd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(int number)
    {
        if(number==0){//ゴールデンハムスター
        factory.itemName = "goldenHamster";
        
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "ゴールデンハムスター\n体の大きなハムスターです。\nストレスに強いですが、餌の消費が多め。";

        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　2 Ham";

        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入して使用";

        }else if(number==1){//ジャンガリアンハムスター
        factory.itemName = "djungarianHamster";
        
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "ジャンガリアンハムスター\nこれといった特徴のないハムスターです。";

        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　2 Ham";

        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入して使用";

        }else if(number==2){//ロボロフスキーハムスター
        factory.itemName = "roborovskiHamster";
        
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "ロボロフスキーハムスター\nやや価値の高いハムスターです。\nただし、ストレスに非常に弱いです。";

        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　4 Ham";

        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入して使用";
        }
        

    }
}
