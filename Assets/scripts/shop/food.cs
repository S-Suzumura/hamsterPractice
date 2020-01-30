using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food : MonoBehaviour
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
        factory.itemName = "feed";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "固形飼料　100個\n最も一般的な餌です。\n満腹度を50回復し、ストレスを10下げます。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　1 Ham";
        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入";

        }else if(number==1){
        factory.itemName = "vegetable";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "レタス　100個\n水分を多く含んだ野菜です。\n満腹度を20、水分を30回復し、ストレスを10下げます。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　2 Ham";
        obj = GameObject.Find("Buy");
        X = obj.GetComponent<Text>();
        X.text = "購入";

        }else if(number==2){
        factory.itemName = "sunflowerSeed";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "ひまわりの種　100個\nハムスターの大好きなおやつです。\n満腹度を10回復し、ストレスを50下げます。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　4 Ham";
        }else if(number==3){
        factory.itemName = "waterPot";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "給水器\n現在のフィールドに給水器を設置します。\nハムスターが自動的に水分補給を行います。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　80 Ham";
        }else if(number==4){
        factory.itemName = "feedMachine";
        GameObject obj = GameObject.Find("ItemMessage");
        Text X = obj.GetComponent<Text>();
        X.text = "自動餌精製機\n地中の成分から餌を精製する機械を設置します。\nハムスターが自動的に餌の補給を行います。";
        obj = GameObject.Find("Price");
        X = obj.GetComponent<Text>();
        X.text = "価格：　60 Ham";
        }
    }
}
