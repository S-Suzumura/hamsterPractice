using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class factory : MonoBehaviour
{
public GameObject ham;
public GameObject ghost;
public GameObject heart;
public GameObject anger;
public GameObject feedObject;
public GameObject vegetableObject;
public GameObject sunflowerSeedObject;

    public static int hamsterTotal = 0;//一度でも出現したハムスターの累計
    public static int[,] hamsterAmount  = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};//各ハムスターの数[フィールド番号,ハムスターの種類]
        public static int[] hamsterAmountTotal  = {0,0,0,0,0};
    public static int[,] visibleHamster = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};//画面に表示されている数
        public static int[] visibleHamsterTotal = {0,0,0,0,0};

    public static int hamsterValue = 0;//ハムスターの価値(スコア)
    public static int diedHamster = 0;//ハムスターの死亡数
    public static int hamsterLimit = 250;//ハムスターの最大表示数

    public static int viewingField = 0;
    public static int pageNumber = 0;

    public static int[] feed = {0,0,0,0,0};
    public static int[] vegetable = {0,0,0,0,0};
    public static int[] sunflowerSeed = {0,0,0,0,0};
    public static string itemName = "";

    public static int[,] instantiateHamster = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};
    public static int[,] deletedHamster     = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};
    //ハムスターの基本ステータス(参照用)
    public static int[] stressMAX = new int[] {150,100,100};
    public static int[] stomachMAX = new int[] {150,100,80};
    public static int[] moistureMAX = new int[] {150,100,80};
    public static int[] deathStress = new int[] {2,4,8};
    public static int[] valuePoints = new int[] {1,1,2};
    public static int[] breedingStress = new int[] {20,30,50};

    //フィールドのステータス増減効果(参照用)
    public static int[] fieldStress = {1,1,1,1,1};
    public static int[] feedMachine = new int[] {0,0,0,0,0};
    public static int[] waterPot = new int[] {0,0,0,0,0};
    public static int[] house = new int[] {0,0,0,0,0};
    public static int[] wheel = new int[] {0,0,0,0,0};

    //ここからハムスターに割り当てるステータス
    //0 ゴールデン　1 ジャンガリアン　2 ロボロフスキー
    public static int[,] stomach   = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};
    public static int[,] moisture  = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};
    public static int[,] stress    = new int[,] {{0,0,0},{0,0,0},{0,0,0},{0,0,0},{0,0,0}};



    private float interval = 1f;//時間経過処理用変数
    private float tmpTime  = 0f;

    int breedingTime  = 0;
    int stressPerTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        feed[0] += 100;
        vegetable[0] += 100;
        feedObject.GetComponent<Text>().text = feed[0].ToString();
        vegetableObject.GetComponent<Text>().text = vegetable[0].ToString();
        
        //最初にジャンガリアン4匹所持してスタート
        for(int X=1;X<=4;X++){
            stomach[0,1] = ((stomach[0,1]*hamsterAmount[0,1])+100)/(hamsterAmount[0,1]+1);
            moisture[0,1] = ((moisture[0,1]*hamsterAmount[0,1])+100)/(hamsterAmount[0,1]+1);
            stress[0,1] = ((stress[0,1]*hamsterAmount[0,1])+30)/(hamsterAmount[0,1]+1);

            hamsterAmount[0,1] += 1;
            hamsterTotal += 1;
            hamsterValue += 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
           //時間経過時の処理
        tmpTime += Time.deltaTime;
        
        if(tmpTime >= interval){

        //空腹度・水分の動作
        for(int X=0;X<=2;X++){
            for(int Y=0;Y<=4;Y++){
                hamsterMeal(X,Y);
            }
        }

        //5秒ごとにストレス変動
        if(stressPerTime>=5){
            for(int Y=0;Y<=4;Y++){
                for(int X=0;X<=2;X++){
                    int density = 0;
                    hamsterAmountTotal[Y] = hamsterAmount[Y,0] + hamsterAmount[Y,1] + hamsterAmount[Y,2];
                    //フィールドの密度が低いほど快適　数が増えるとストレスが増える
                    if(hamsterAmountTotal[Y]<=40){
                        density = (-3);
                    }else if(hamsterAmountTotal[Y]<=80){
                        density = (-2);
                    }else if(hamsterAmountTotal[Y]<=120){
                        density = (-1);
                    }else if(hamsterAmountTotal[Y]<=160){
                        density = 0;
                    }else if(hamsterAmountTotal[Y]<=200){
                        density = 1;
                    }else{
                        density = 2;
                    }

                    if(X==0){
                    stress[Y,X] += (fieldStress[Y]+density-1);
                    }else if(X==1){
                    stress[Y,X] += (fieldStress[Y]+density);
                    }else if(X==2){
                    stress[Y,X] += (fieldStress[Y]+density+1);
                    }


                }
            }
            stressPerTime = 0;
        }



        //繁殖

        if(breedingTime>=2){
            for(int X=0;X<=2;X++){
                for(int Y=0;Y<=4;Y++){
                    int breedingCheck = Random.Range(1,hamsterAmount[Y,X]+50);
                    breedingCheck /= 5;
                    breedingCheck -= stress[Y,X];

                    if(breedingCheck >= 1 && hamsterAmount[Y,X] >= 2){
                        string hamsterName = "";
                            int name1 = Random.Range(deletedHamster[Y,X]+1,instantiateHamster[Y,X]+1);
                            int name2 = Random.Range(deletedHamster[Y,X]+1,instantiateHamster[Y,X]+1);
                            while(name1==name2){
                                name2 = Random.Range(deletedHamster[Y,X]+1,instantiateHamster[Y,X]+1);
                            }

                            if(X==0){
                                hamsterName="Field"+(Y+1)+"_goldenHamster"+name1+"(Clone)";
                            }else if(X==1){
                                hamsterName="Field"+(Y+1)+"_djungarianHamster"+name1+"(Clone)";
                            }else if(X==2){
                                hamsterName="Field"+(Y+1)+"_roborovskiHamster"+name1+"(Clone)";
                            }
                        GameObject obj = GameObject.Find(hamsterName);
                        Vector3 heartAddress = obj.transform.position;
                        Instantiate(heart,new Vector3(heartAddress.x,heartAddress.y,-3),Quaternion.identity);

                            if(X==0){
                                hamsterName="Field"+(Y+1)+"_goldenHamster"+name2+"(Clone)";
                            }else if(X==1){
                                hamsterName="Field"+(Y+1)+"_djungarianHamster"+name2+"(Clone)";
                            }else if(X==2){
                                hamsterName="Field"+(Y+1)+"_roborovskiHamster"+name2+"(Clone)";
                            }
                        obj = GameObject.Find(hamsterName);
                        heartAddress = obj.transform.position;
                        Instantiate(heart,new Vector3(heartAddress.x,heartAddress.y,-3),Quaternion.identity);


                        int temp = Random.Range(1,10);
                        temp += Random.Range(1,hamsterAmount[Y,X]/10);                
                        for(int A=1;A<=temp;A++){
                            stomach[Y,X] = ((stomach[Y,X]*hamsterAmount[Y,X])+60)/(hamsterAmount[Y,X]+1);
                            moisture[Y,X] = ((moisture[Y,X]*hamsterAmount[Y,X])+60)/(hamsterAmount[Y,X]+1);
                            hamsterAmount[Y,X] += 1;
                            hamsterTotal += 1;
                            hamsterValue += valuePoints[X];
                        }
                        if(house[Y]>=1){
                            stress[Y,X] += breedingStress[X]/2;
                        }else{
                            stress[Y,X] += breedingStress[X];
                        }
                    }
                }

            }
            breedingTime = 0;
        }


        //共食い
            for(int Y=0;Y<=4;Y++){
                for(int X=0;X<=2;X++){
                    hamsterAmountTotal[Y] = hamsterAmount[Y,0]+hamsterAmount[Y,1]+hamsterAmount[Y,2];
                    if(stress[Y,X] >= 70 && hamsterAmountTotal[Y] >= 2){
                        int deathAmount = 0;
                        if(stress[Y,X] >= 90 && hamsterAmountTotal[Y] >5){
                            deathAmount = 5;
                        }else if(stress[Y,X] >= 80 && hamsterAmountTotal[Y] >3){
                            deathAmount = 3;
                        }else{
                            deathAmount = 1;
                        }
                        
                        string hamsterName = "";
                        if(visibleHamster[Y,X] > 0){
                            if(X==0){
                                hamsterName="Field"+(Y+1)+"_goldenHamster"+(instantiateHamster[Y,X])+"(Clone)";
                            }else if(X==1){
                                hamsterName="Field"+(Y+1)+"_djungarianHamster"+(instantiateHamster[Y,X])+"(Clone)";
                            }else if(X==2){
                                hamsterName="Field"+(Y+1)+"_roborovskiHamster"+(instantiateHamster[Y,X])+"(Clone)";
                            }
                            GameObject ang = GameObject.Find(hamsterName);
                            Vector3 angerAddress = ang.transform.position;
                            Instantiate(anger,new Vector3(angerAddress.x,angerAddress.y,-3),Quaternion.identity);
                        }

                        for(int Z = 1;Z <= deathAmount;Z++){
                            int Victim = Random.Range(0,3);//ハムスターの種類を選ぶ
                            while(hamsterAmount[Y,Victim] == 0){
                                Victim = Random.Range(0,3);
                            }
                                stomach[Y,X] += 5;
                                moisture[Y,X] += 5;
                                stress[Y,X] -= 10;
                                diedHamster += 1;
                                hamsterAmount[Y,Victim] -= 1;
                                hamsterValue -= valuePoints[Victim];
                                stress[Y,Victim] += deathStress[Victim];

                            if(visibleHamster[Y,Victim] >= 1){
                                //ハムスターを一匹消す
                                if(Victim==0){
                                    hamsterName = "Field"+(Y+1)+"_goldenHamster"+(deletedHamster[Y,Victim]+1)+"(Clone)";
                                }else if(Victim==1){
                                    hamsterName = "Field"+(Y+1)+"_djungarianHamster"+(deletedHamster[Y,Victim]+1)+"(Clone)";
                                }else if(Victim==2){
                                    hamsterName= "Field"+(Y+1)+"_roborovskiHamster"+(deletedHamster[Y,Victim]+1)+"(Clone)";
                                }
                                GameObject obj = GameObject.Find(hamsterName);
                                Vector3 ghostAddress = obj.transform.position;
                                Destroy(obj);
                                Instantiate(ghost,new Vector3(ghostAddress.x,ghostAddress.y,-3),Quaternion.identity);
                                visibleHamster[Y,Victim] -= 1;
                                deletedHamster[Y,Victim] += 1;
                            }

                            

                        }

                    }

                }

            }



        //画面上のハムスターが総数より少ない場合、補充する
        for(int Y=0;Y<=4;Y++){
        visibleHamsterTotal[Y] = visibleHamster[Y,0]+visibleHamster[Y,1]+visibleHamster[Y,2];
        hamsterAmountTotal[Y]  = hamsterAmount[Y,0]+hamsterAmount[Y,1]+hamsterAmount[Y,2];
        
            while(hamsterLimit > visibleHamsterTotal[Y] && hamsterAmountTotal[Y] > visibleHamsterTotal[Y]){
                //非表示の中から生きているハムスターを探す
                //少ない順に出す
                int minimum = 99999999;
                int minimumHamster = 0;
                for(int X=0; X<=2;X++){
                    if(minimum>hamsterAmount[Y,X] && hamsterAmount[Y,X] > visibleHamster[Y,X]){
                        minimum = hamsterAmount[Y,X];
                        minimumHamster = X;
                    }
                }

                instantiateHamster[Y,minimumHamster] += 1;
                if(minimumHamster==0){
                    ham = (GameObject)Resources.Load("goldenHamster");
                    ham.name = "Field"+(Y+1)+"_goldenHamster"+instantiateHamster[Y,minimumHamster];
                }else if(minimumHamster==1){
                    ham = (GameObject)Resources.Load("djungarianHamster");
                    ham.name = "Field"+(Y+1)+"_djungarianHamster"+instantiateHamster[Y,minimumHamster];
                }else if(minimumHamster==2){
                    ham = (GameObject)Resources.Load("roborovskiHamster");
                    ham.name = "Field"+(Y+1)+"_roborovskiHamster"+instantiateHamster[Y,minimumHamster];
                }

                Instantiate(ham,new Vector3(Y*10,0,-2),Quaternion.identity);
                visibleHamster[Y,minimumHamster] += 1;
                visibleHamsterTotal[Y] = visibleHamster[Y,0]+visibleHamster[Y,1]+visibleHamster[Y,2];
                hamsterAmountTotal[Y]  = hamsterAmount[Y,0]+hamsterAmount[Y,1]+hamsterAmount[Y,2];
            }

        }

        
        breedingTime += 1;
        stressPerTime += 1;
        tmpTime = 0f;
        }
        scoreUpdate();

    }






    public void foodUpdate(){
        feedObject.GetComponent<Text>().text = feed[viewingField].ToString();
        vegetableObject.GetComponent<Text>().text = vegetable[viewingField].ToString();
        sunflowerSeedObject.GetComponent<Text>().text = sunflowerSeed[viewingField].ToString();
    }

    public void scoreUpdate(){
            GameObject obj = GameObject.Find("Score");
            Text X = obj.GetComponent<Text>();
            X.text = "Ham：" + hamsterValue;
    }


    public void hamsterMeal(int X,int Y){
        string hamsterName = "";
        int dangerStomach  = 0;
        int dangerMoisture = 0;
        int mealSize = 0;
        if(X==0){
        hamsterName = "Field"+(Y+1)+"_goldenHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
        dangerStomach  = 75;
        dangerMoisture = 75;
        mealSize = 3;
        }else if(X==1){
        hamsterName = "Field"+(Y+1)+"_djungarianHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
        dangerStomach  = 50;
        dangerMoisture = 50;
        mealSize = 2;
        }else if(X==2){
        hamsterName= "Field"+(Y+1)+"_roborovskiHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
        dangerStomach  = 40;
        dangerMoisture = 40;
        mealSize = 2;
        }


        if(hamsterAmount[Y,X] != 0){
                stomach[Y,X] -= 1;//満腹値を減らす
                moisture[Y,X] -= 1;//水分を減らす

                 //食料がある場合はステータスに応じて食べる
                 if(stress[Y,X]>50 && sunflowerSeed[Y] > hamsterAmount[Y,X]*mealSize){
                    sunflowerSeed[Y] -= hamsterAmount[Y,X]*mealSize;
                    stomach[Y,X] += 10;
                    stress[Y,X] -= 50;
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }else if(stress[Y,X]>50 && sunflowerSeed[Y] > 1){
                    sunflowerSeed[Y] = 0;
                    stomach[Y,X] += 10*sunflowerSeed[Y]/hamsterAmount[Y,X];
                    stress[Y,X] -= 50*sunflowerSeed[Y]/hamsterAmount[Y,X];
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }

                 if(stomach[Y,X] < dangerStomach && sunflowerSeed[Y] > hamsterAmount[Y,X]*mealSize){
                    sunflowerSeed[Y] -= hamsterAmount[Y,X]*mealSize;
                    stomach[Y,X] += 10;
                    stress[Y,X] -= 50;
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }else if(stomach[Y,X] < dangerStomach && sunflowerSeed[Y] > 1){
                    sunflowerSeed[Y] = 0;
                    stomach[Y,X] += 10*sunflowerSeed[Y]/hamsterAmount[Y,X];
                    stress[Y,X] -= 50*sunflowerSeed[Y]/hamsterAmount[Y,X];
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }

                //給水器があれば使う
                if(moisture[Y,X] < dangerMoisture && waterPot[Y] >= 1){
                   moisture[Y,X] = moistureMAX[X];
                   stress[Y,X]   -= 5;
                }
                //自動餌精製機があれば使う
                if(stomach[Y,X] < dangerStomach && feedMachine[Y] >= 1){
                   stomach[Y,X] = stomachMAX[X];
                   stress[Y,X]   -= 10;
                }


                 if(stomach[Y,X] < dangerStomach && moisture[Y,X] < dangerMoisture && vegetable[Y] > hamsterAmount[Y,X]*mealSize || moisture[Y,X] < dangerMoisture*0.8f && vegetable[Y] > hamsterAmount[Y,X]*mealSize){
                    vegetable[Y] -= hamsterAmount[Y,X]*mealSize;
                    stomach[Y,X] += 20;
                    moisture[Y,X] += 30;
                    stress[Y,X] -= 10;
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 } else if(stomach[Y,X] < dangerStomach && moisture[Y,X] < dangerMoisture && vegetable[Y] > 1 || moisture[Y,X] < dangerMoisture*0.8f && vegetable[Y] > 1){
                    vegetable[Y] = 0;
                    stomach[Y,X] += 20*vegetable[Y]/hamsterAmount[Y,X];
                    moisture[Y,X] += 30*vegetable[Y]/hamsterAmount[Y,X];
                    stress[Y,X] -= 10*vegetable[Y]/hamsterAmount[Y,X];
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }
                 
                 if(stomach[Y,X] < dangerStomach && feed[Y] > hamsterAmount[Y,X]*mealSize){
                    feed[Y] -= hamsterAmount[Y,X]*mealSize;
                    stomach[Y,X] += 50;
                    stress[Y,X] -= 10;
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }else if(stomach[Y,X] < dangerStomach && feed[Y] > 1){
                    feed[Y] = 0;
                    stomach[Y,X] += 50*feed[Y]/hamsterAmount[Y,X];
                    stress[Y,X] -= 10*feed[Y]/hamsterAmount[Y,X];
                    if(stress[Y,X] < 0){
                        stress[Y,X] = 0;
                    }
                 }


                if (stomach[Y,X] < dangerStomach*0.67f)//満腹度低下時
                {
                    int deathAmount = 0;
                    if(stomach[Y,X] < dangerStomach*0.05){
                        deathAmount = 100;
                    }else if(stomach[Y,X] < dangerStomach*0.1){
                        deathAmount = 10;
                    }else if(stomach[Y,X] < dangerStomach*0.2){
                        deathAmount = 5;
                    }else if(stomach[Y,X] < dangerStomach*0.35){
                        deathAmount = 3;
                    }else if(stomach[Y,X] < dangerStomach*0.5){
                        deathAmount = 2;
                    }else{
                        deathAmount = 1;
                    }

                    //死亡時、死んだハムスター分の満腹値の残りを全体に加算
                    for(int Z = 1;Z <= deathAmount;Z++){
                        if(hamsterAmount[Y,X]>0){
                            stomach[Y,X] = ((stomach[Y,X]*hamsterAmount[Y,X])+stomach[Y,X])/hamsterAmount[Y,X];
                            diedHamster += 1;
                            hamsterAmount[Y,X] -= 1;
                            hamsterValue -= valuePoints[X];

                            if(visibleHamster[Y,X] > 0){
                                //ハムスターを一匹消す
                                if(X==0){
                                    hamsterName = "Field"+(Y+1)+"_goldenHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
                                }else if(X==1){
                                    hamsterName = "Field"+(Y+1)+"_djungarianHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
                                }else if(X==2){
                                    hamsterName= "Field"+(Y+1)+"_roborovskiHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
                                }
                                GameObject obj = GameObject.Find(hamsterName);
                                Vector3 ghostAddress = obj.transform.position;
                                Destroy(obj);
                                Instantiate(ghost,new Vector3(ghostAddress.x,ghostAddress.y,-3),Quaternion.identity);
                                visibleHamster[Y,X] -= 1;
                                deletedHamster[Y,X] += 1;
                                stress[Y,X] += deathStress[X];
                            }

                        }

                    }
                }else if (moisture[Y,X] < dangerMoisture*0.67f)//水分低下時
                {
                    int deathAmount = 0;
                    if(moisture[Y,X] < dangerMoisture*0.05){
                        deathAmount = 100;
                    }else if(moisture[Y,X] < dangerMoisture*0.1){
                        deathAmount = 10;
                    }else if(moisture[Y,X] < dangerMoisture*0.2){
                        deathAmount = 5;
                    }else if(moisture[Y,X] < dangerMoisture*0.35){
                        deathAmount = 3;
                    }else if(moisture[Y,X] < dangerMoisture*0.5){
                        deathAmount = 2;
                    }else{
                        deathAmount = 1;
                    }
                    //死亡時、死んだハムスター分の水分の残りを全体に加算
                    for(int Z = 1;Z <= deathAmount;Z++){
                        if(hamsterAmount[Y,X]>0){
                            moisture[Y,X] = ((moisture[Y,X]*hamsterAmount[Y,X])+moisture[Y,X])/hamsterAmount[Y,X];
                            diedHamster += 1;
                            hamsterAmount[Y,X] -= 1;
                            hamsterValue -= valuePoints[X];

                            if(visibleHamster[Y,X] > 0){
                                //ハムスターを一匹消す
                                if(X==0){
                                    hamsterName = "Field"+(Y+1)+"_goldenHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
                                }else if(X==1){
                                    hamsterName = "Field"+(Y+1)+"_djungarianHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
                                }else if(X==2){
                                    hamsterName= "Field"+(Y+1)+"_roborovskiHamster"+(deletedHamster[Y,X]+1)+"(Clone)";
                                }
                                GameObject obj = GameObject.Find(hamsterName);
                                Vector3 ghostAddress = obj.transform.position;
                                Destroy(obj);
                                Instantiate(ghost,new Vector3(ghostAddress.x,ghostAddress.y,-3),Quaternion.identity);
                                visibleHamster[Y,X] -= 1;
                                deletedHamster[Y,X] += 1;
                                stress[Y,X] += deathStress[X];
                            }

                        }
                    }

                }
            foodUpdate();
        }
    }

}
