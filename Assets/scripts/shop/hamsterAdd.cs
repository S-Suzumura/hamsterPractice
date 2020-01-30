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
        X.text = "ゴールデンハムスター\n寿命が長く、ストレスにも強いです。\nただし餌の消費が激しく、価値も高くありません。";

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
        X.text = "ジャンガリアンハムスター\nこれといった特徴のない普通のハムスターです。";

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
        X.text = "ロボロフスキーハムスター\n餌の消費が少なく、価値も高いです。\nただし、ストレスに非常に弱いです。";

        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　4 Ham";

        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入して使用";
        }
        

    }
}
