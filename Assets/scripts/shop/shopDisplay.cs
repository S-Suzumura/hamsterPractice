using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopDisplay : MonoBehaviour
{
    public Sprite ableButton;
    public Sprite disableButton;
    GameObject button;
    GameObject item;
    ShopWindowCall script;
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
        if(number==0 && factory.pageNumber == 0){

        }else if(number==0 && factory.pageNumber == 1){
        button = GameObject.Find("previous");
        button.GetComponent<SpriteRenderer>().sprite = disableButton;
        button = GameObject.Find("next");
        button.GetComponent<SpriteRenderer>().sprite = ableButton;

        item = GameObject.Find ("ShopWindowCall");
        script = item.GetComponent<ShopWindowCall>();
        script.page1();
        factory.pageNumber = 0;

        }else if(number==1 && factory.pageNumber == 0){
        button = GameObject.Find("next");
        button.GetComponent<SpriteRenderer>().sprite = disableButton;
        button = GameObject.Find("previous");
        button.GetComponent<SpriteRenderer>().sprite = ableButton;

        item = GameObject.Find ("ShopWindowCall");
        script = item.GetComponent<ShopWindowCall>();
        script.page2();
        factory.pageNumber = 1;


        }else if(number==1 && factory.pageNumber == 1){


        }
    }



}
