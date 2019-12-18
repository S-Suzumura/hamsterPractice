using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
	private int total = 0;
	private int amount = 0;
	private int display = 0;

  GameObject plant;
  factory script;
    void Start()
    {
      plant = GameObject.Find("factory");
      script = plant.GetComponent<factory>();
    }

    void Update()
    {
      total = script.hamsterTotal;
      amount = script.hamsterAmount;
      display = script.visibleHamster;
      this.GetComponent<Text>().text = "累計：" + total + "\n総数：" + amount + "\n表示：" + display;
    }
}
