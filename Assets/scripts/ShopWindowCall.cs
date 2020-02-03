using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindowCall : MonoBehaviour
{
    GameObject Window;
    GameObject Item;
    Transform parent;
    void Start()
    {

    }
    void Update()
    {

    }

    public void OnClick(){
        Window = (GameObject)Resources.Load("shopItemWindow");
        Window.name = "shopItemWindow";
        float callAddress = factory.viewingField*10;
        factory.pageNumber = 0;
        Instantiate(Window,new Vector3(callAddress,-2.59f,-12),Quaternion.identity);
        page1();

     }



    public void page1(){
        Window = GameObject.Find("ItemView");
        foreach ( Transform X in Window.transform )
        {
            GameObject.Destroy(X.gameObject);
        }

        Item = (GameObject)Resources.Load("shopItem/GoldenHamster(Shop)");
        Item.name = "Item" + 1;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/DjungarianHamster(Shop)");
        Item.name = "Item" + 2;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);
        
        Item = (GameObject)Resources.Load("shopItem/RoborovskiHamster(Shop)");
        Item.name = "Item" + 3;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/Feed(Shop)");
        Item.name = "Item" + 4;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/Vegetable(Shop)");
        Item.name = "Item" + 5;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/SunflowerSeed(Shop)");
        Item.name = "Item" + 6;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/WaterPot(Shop)");
        Item.name = "Item" + 7;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/FeedMachine(Shop)");
        Item.name = "Item" + 8;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

    }

    public void page2(){
        Window = GameObject.Find("ItemView");
        foreach ( Transform X in Window.transform )
        {
            GameObject.Destroy(X.gameObject);
        }

        Item = (GameObject)Resources.Load("shopItem/House(Shop)");
        Item.name = "Item" + 1;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        Item = (GameObject)Resources.Load("shopItem/Wheel(Shop)");
        Item.name = "Item" + 2;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        for(int X=3;X<=8;X++){
        Item = (GameObject)Resources.Load("shopItem/noItem");
        Item.name = "Item" + X;
        parent = Window.transform;
        Instantiate(Item,this.transform.position,Quaternion.identity,parent);

        }

    }



}