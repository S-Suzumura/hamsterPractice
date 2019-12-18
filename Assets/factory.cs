using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class factory : MonoBehaviour
{
public GameObject ham;
    public int hamsterTotal = 0;//一度でも出現したハムスターの累計
    public int hamsterAmount = 0;//ハムスターの数(スコア)
    public int visibleHamster = 0;//画面に表示されている数
    private int hamsterLimit = 10;//ハムスターの最大表示数

    //ここから各ハムスターに割り当てるステータス
    private List<int> stomach = new List<int>();
    private List<int> moisture = new List<int>();
    private List<int> stress = new List<int>();
    private List<int> life = new List<int>();
    private List<int> status = new List<int>();//0:死亡　1:通常　2:病気
    private List<bool> knowWaterPot = new List<bool>();
    private List<bool> visible = new List<bool>();


    private float interval = 1f;//時間経過処理用変数
    private float tmpTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) {
            hamsterAmount += 1;
            hamsterTotal += 1;
            ham.name = "hamster" + (hamsterTotal);
            if(visibleHamster<hamsterLimit){
            Instantiate(ham,new Vector3(0,0,-2),Quaternion.identity);
            visibleHamster += 1;
            visible.Add(true);
            }else{
            visible.Add(false);
            }

            //初期パラメータ設定
            stomach.Add(100);
            moisture.Add(100);
            stress.Add(0);
            life.Add(10);
            status.Add(1);
            int temp = Random.Range(0,10);//2割の確率で最初から給水器を知っている
            if(temp>=8){
                knowWaterPot.Add(true);
            }else{
                knowWaterPot.Add(false);
            }
	    }


        tmpTime += Time.deltaTime;

         if(tmpTime >= interval){

         for (int X = 0; X < stomach.Count; X++)
         {
             if(status[X] != 0){
                 stomach[X] -= 1;
                 if (stomach[X] <= 0)
                 {
                     status[X] = 0;
                     hamsterAmount -= 1;

                     if(visible[X] == true){
                     GameObject obj = GameObject.Find("hamster" + (X+1) + "(Clone)");
                     Destroy(obj);
                     visible[X] = false;
                     visibleHamster -= 1;
                     }
                 }
             }
        }

        for (int X = 0; X < moisture.Count; X++)
        {
            if(status[X] != 0){
                moisture[X] -= 2;
                if (moisture[X] <= 0)
                {
                    status[X] = 0;
                    hamsterAmount -= 1;

                     if(visible[X] == true){
                     GameObject obj = GameObject.Find("hamster" + (X+1) + "(Clone)");
                     Destroy(obj);
                     visible[X] = false;
                     visibleHamster -= 1;
                     }
                    }
            }

        }

        for (int X = 0; X < life.Count; X++)
        {
            if(status[X] != 0){
                life[X] -= 1;
                if (life[X] <= 0)
                {
                    status[X] = 0;
                    hamsterAmount -= 1;
                    
                     if(visible[X] == true){
                     GameObject obj = GameObject.Find("hamster" + (X+1) + "(Clone)");
                     Destroy(obj);
                     visible[X] = false;
                     visibleHamster -= 1;
                     }
                    }
            }

        }

        //死亡等で画面上のハムスターが減った場合、非表示のハムスターがいればそこから補充する
        if(hamsterLimit > visibleHamster && hamsterAmount > visibleHamster){
            int temp = 0;
            //非表示の中から生きているハムスターを探す
            for(int X = 0; X < status.Count; X++){
                if(status[X] !=0 && visible[X] == false){
                    temp = X;
                    break;
                }
            }
            ham.name = "hamster" + (temp+1);
            Instantiate(ham,new Vector3(0,0,-2),Quaternion.identity);
            visibleHamster += 1;
            visible[temp] = true;


        }

         tmpTime = 0f;
        }


    }
}
