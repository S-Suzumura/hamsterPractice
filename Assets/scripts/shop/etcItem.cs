using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class etcItem : MonoBehaviour
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
        if(number==0){
        factory.itemName = "wheel";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "滑車\nハムスターが回して遊ぶ遊具です。\n一定時間ごとにストレスを減らします。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　50 Ham";
        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入して使用";

        }else if(number==1){
        factory.itemName = "house";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "ハウス\n安心して過ごせる小屋です。\n繁殖時のストレスを半減します。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　100 Ham";
        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入して使用";

        }else if(number==2){
        }else if(number==3){
        }


    }




}
