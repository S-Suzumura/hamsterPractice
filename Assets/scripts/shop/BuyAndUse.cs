using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndUse : MonoBehaviour
{
    public GameObject item;
    public GameObject coin;
    public GameObject ham;
    public GameObject obj;
    public GameObject FeedMachine;
    public GameObject WaterPot;
    public GameObject Wheel;
    public GameObject House;
    public GameObject Drone;
    public GameObject smoke1;
    public GameObject smoke2;
    public GameObject smoke3;
    public GameObject smoke4;
    factory script;

    public int itemValue = 0;
    private int money;
    private int temp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick(){
        if(factory.itemName=="goldenHamster" && factory.hamsterValue >= 2){
            itemValue = 2;
            Purchase();
            hamsterAdd(0);
        }else if(factory.itemName=="djungarianHamster" && factory.hamsterValue >= 2){
            itemValue = 2;
            Purchase();
            hamsterAdd(1);
        }else if(factory.itemName=="roborovskiHamster" && factory.hamsterValue >= 4){
            itemValue = 4;
            Purchase();
            hamsterAdd(2);
        }else if(factory.itemName=="feed" && factory.hamsterValue >= 1){
            itemValue = 1;
            Purchase();
            factory.feed[factory.viewingField] += 100;
            obj = GameObject.Find ("factory");
            script = obj.GetComponent<factory>();
            script.foodUpdate();
        }else if(factory.itemName=="vegetable" && factory.hamsterValue >= 2){
            itemValue = 2;
            Purchase();
            factory.vegetable[factory.viewingField] += 100;
            obj = GameObject.Find ("factory");
            script = obj.GetComponent<factory>();
            script.foodUpdate();
        }else if(factory.itemName=="sunflowerSeed" && factory.hamsterValue >= 4){
            itemValue = 4;
            Purchase();
            factory.sunflowerSeed[factory.viewingField] += 100;
            obj = GameObject.Find ("factory");
            script = obj.GetComponent<factory>();
            script.foodUpdate();
        }else if(factory.itemName=="waterPot" && factory.hamsterValue >= 80 && factory.waterPot[factory.viewingField] == 0){
            itemValue = 80;
            Purchase();
            factory.waterPot[factory.viewingField] = 100;
            WaterPot.name = "Field"+(factory.viewingField+1)+"_waterPot";
            Instantiate(WaterPot,new Vector3(1.1f+factory.viewingField*10,3.2f,-2),Quaternion.identity);

            ItemEffect(1.1f,3.0f);
        }else if(factory.itemName=="wheel" && factory.hamsterValue >= 50 && factory.wheel[factory.viewingField] == 0){
            itemValue = 50;
            Purchase();
            factory.wheel[factory.viewingField] = 100;
            Wheel.name = "Field"+(factory.viewingField+1)+"_wheel";
            Instantiate(Wheel,new Vector3((-0.1f)+factory.viewingField*10,3.2f,-2),Quaternion.identity);

            ItemEffect(-0.1f,3.0f);
        }else if(factory.itemName=="house" && factory.hamsterValue >= 100 && factory.house[factory.viewingField] == 0){
            itemValue = 100;
            Purchase();
            factory.house[factory.viewingField] = 100;
            House.name = "Field"+(factory.viewingField+1)+"_house";
            Instantiate(House,new Vector3((-1.5f)+factory.viewingField*10,3.2f,-2),Quaternion.identity);

            ItemEffect(-1.5f,3.0f);
        }else if(factory.itemName=="feedMachine" && factory.hamsterValue >= 60 && factory.feedMachine[factory.viewingField] == 0){
            itemValue = 60;
            Purchase();
            factory.feedMachine[factory.viewingField] = 100;
            FeedMachine.name = "Field"+(factory.viewingField+1)+"_feedMachine";
            Instantiate(FeedMachine,new Vector3(2.2f+factory.viewingField*10,3.2f,-2),Quaternion.identity);
            ItemEffect(2.2f,3.0f);
        }

    }


    public void Purchase(){
        money = 0;//初期化
        while(money<itemValue){//数の多いハムスターから順に売却、アイテム価格以上に達したらストップ money=売却額
            //売却額をmoneyに加え、指定のハムスターを消す(死亡状態と同じ、ただし死んだわけではないのでdiedHamsterは加算しない)
            int maximum = 0;
            int maximumHamster = 0;
            int fieldNumber = 0;
            string hamsterName = "";

            for(int X=0; X<=11;X++){
                for(int Y=0;Y<=4;Y++){
                    if(maximum<factory.hamsterAmount[Y,X]){
                        maximum = factory.hamsterAmount[Y,X];
                        maximumHamster = X;
                        fieldNumber = Y;
                    }

                }

            }


            money += factory.valuePoints[maximumHamster];
            factory.hamsterValue -= factory.valuePoints[maximumHamster];
            factory.hamsterAmount[fieldNumber,maximumHamster] -= 1;

            factory.visibleHamsterTotal[fieldNumber] = factory.visibleHamster[fieldNumber,0]+factory.visibleHamster[fieldNumber,1]+factory.visibleHamster[fieldNumber,2];
            
            if(factory.visibleHamsterTotal[fieldNumber] >= 1){
                //★
                if(maximumHamster==0){
                hamsterName = "Field"+(fieldNumber+1)+"_goldenHamster"+(factory.deletedHamster[fieldNumber,maximumHamster]+1)+"(Clone)";
                }else if(maximumHamster==1){
                hamsterName = "Field"+(fieldNumber+1)+"_djungarianHamster"+(factory.deletedHamster[fieldNumber,maximumHamster]+1)+"(Clone)";
                }else if(maximumHamster==2){
                hamsterName = "Field"+(fieldNumber+1)+"_roborovskiHamster"+(factory.deletedHamster[fieldNumber,maximumHamster]+1)+"(Clone)";
                }
            obj = GameObject.Find(hamsterName);
            Vector3 coinAddress = obj.transform.position;
            Destroy(obj);
            factory.deletedHamster[fieldNumber,maximumHamster]+=1;
            Instantiate(coin,new Vector3(coinAddress.x,coinAddress.y,-2),Quaternion.identity);
            factory.visibleHamster[fieldNumber,maximumHamster] -= 1;
            }
            
            if(money>itemValue){//売却額がアイテムの価格を超過した場合、差額を払い戻す
                factory.hamsterValue += (money-itemValue);
            }
        }
    }


    public void hamsterAdd(int number){
        //★
        if(number==0){//ゴールデン
            if(factory.visibleHamster[factory.viewingField,number]<factory.hamsterLimit){
            factory.instantiateHamster[factory.viewingField,number] += 1;
            ham = (GameObject)Resources.Load("goldenHamster");
            ham.name = "Field"+(factory.viewingField+1)+"_goldenHamster"+factory.instantiateHamster[factory.viewingField,number];
            Instantiate(ham,new Vector3(factory.viewingField*10,0,-2),Quaternion.identity);
            factory.visibleHamster[factory.viewingField,number] += 1;
            }

            //初期パラメータ設定
            factory.stomach[factory.viewingField,number] = ((factory.stomach[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+150)/(factory.hamsterAmount[factory.viewingField,number]+1);
            factory.moisture[factory.viewingField,number] = ((factory.moisture[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+150)/(factory.hamsterAmount[factory.viewingField,number]+1);
            factory.stress[factory.viewingField,number] = ((factory.stress[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+30)/(factory.hamsterAmount[factory.viewingField,number]+1);

            factory.hamsterAmount[factory.viewingField,number] += 1;
            factory.hamsterTotal += 1;
            factory.hamsterValue += 1;
        }else if(number==1){//ジャンガリアン
            if(factory.visibleHamster[factory.viewingField,number]<factory.hamsterLimit){
            factory.instantiateHamster[factory.viewingField,number] += 1;
            ham = (GameObject)Resources.Load("djungarianHamster");
            ham.name = "Field"+(factory.viewingField+1)+"_djungarianHamster"+factory.instantiateHamster[factory.viewingField,number];
            Instantiate(ham,new Vector3(factory.viewingField*10,0,-2),Quaternion.identity);
            factory.visibleHamster[factory.viewingField,number] += 1;
            }
            //初期パラメータ設定
            factory.stomach[factory.viewingField,number] = ((factory.stomach[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+100)/(factory.hamsterAmount[factory.viewingField,number]+1);
            factory.moisture[factory.viewingField,number] = ((factory.moisture[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+100)/(factory.hamsterAmount[factory.viewingField,number]+1);
            factory.stress[factory.viewingField,number] = ((factory.stress[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+30)/(factory.hamsterAmount[factory.viewingField,number]+1);

            factory.hamsterAmount[factory.viewingField,number] += 1;
            factory.hamsterTotal += 1;
            factory.hamsterValue += 1;
        }else if(number==2){//ロボロフスキー
            if(factory.visibleHamster[factory.viewingField,number]<factory.hamsterLimit){
            factory.instantiateHamster[factory.viewingField,number] += 1;
            ham = (GameObject)Resources.Load("roborovskiHamster");
            ham.name = "Field"+(factory.viewingField+1)+"_roborovskiHamster"+factory.instantiateHamster[factory.viewingField,number];
            Instantiate(ham,new Vector3(factory.viewingField*10,0,-2),Quaternion.identity);
            factory.visibleHamster[factory.viewingField,number] += 1;
            }
            //初期パラメータ設定
            factory.stomach[factory.viewingField,number] = ((factory.stomach[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+80)/(factory.hamsterAmount[factory.viewingField,number]+1);
            factory.moisture[factory.viewingField,number] = ((factory.moisture[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+80)/(factory.hamsterAmount[factory.viewingField,number]+1);
            factory.stress[factory.viewingField,number] = ((factory.stress[factory.viewingField,number]*factory.hamsterAmount[factory.viewingField,number])+30)/(factory.hamsterAmount[factory.viewingField,number]+1);

            factory.hamsterAmount[factory.viewingField,number] += 1;
            factory.hamsterTotal += 1;
            factory.hamsterValue += 2;
        }



    }


    public void ItemEffect(float X,float Y){
        smoke1.name = "smoke1";
        Instantiate(smoke1,new Vector3(X+factory.viewingField*10,Y,-3),Quaternion.identity);
        smoke1 = GameObject.Find("smoke1(Clone)");
        smoke1.GetComponent<Rigidbody2D>().velocity = new Vector2(1,0);

        smoke2.name = "smoke2";
        Instantiate(smoke2,new Vector3(X+factory.viewingField*10,Y,-3),Quaternion.identity);
        smoke2 = GameObject.Find("smoke2(Clone)");
        smoke2.GetComponent<Rigidbody2D>().velocity = new Vector2(-1,0);

        smoke3.name = "smoke3";
        Instantiate(smoke3,new Vector3(X+factory.viewingField*10,Y,-4),Quaternion.identity);
        smoke3 = GameObject.Find("smoke3(Clone)");
        smoke3.GetComponent<Rigidbody2D>().velocity = new Vector2(1,0.5f);

        smoke4.name = "smoke4";
        Instantiate(smoke4,new Vector3(X+factory.viewingField*10,Y,-4),Quaternion.identity);
        smoke4 = GameObject.Find("smoke4(Clone)");
        smoke4.GetComponent<Rigidbody2D>().velocity = new Vector2(-1,0.5f);
    }











}
