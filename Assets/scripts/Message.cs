using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Message : MonoBehaviour
{

  // GameObject plant;
  // factory script;
    void Start()
    {
      // plant = GameObject.Find("factory");
      // script = plant.GetComponent<factory>();
    }

    void Update()
    {
      // total = factory.hamsterTotal;
      // amount = factory.hamsterAmount;
      // display = factory.visibleHamster;
      // this.GetComponent<Text>().text = "累計：" + factory.hamsterTotal + "\n総数：" + factory.hamsterAmount[0] + "\n表示：" + factory.visibleHamster[0];

      //this.GetComponent<Text>().text = "満腹度：" + factory.stomach[0,0] + "　　水分：" + factory.moisture[0,0] + "\nストレス：" + factory.stress[0,0] + "\n総数：" + factory.hamsterAmount[0,0];
      this.GetComponent<Text>().text = "満腹度：" + factory.stomach[0,1] + "　　水分：" + factory.moisture[0,1] + "\nストレス：" + factory.stress[0,1] + "\n総数：" + factory.hamsterAmount[0,1];
    }
}
