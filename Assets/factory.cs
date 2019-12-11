using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class factory : MonoBehaviour
{
public GameObject ham;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) {
            Instantiate(ham,new Vector3(0,0,-2),Quaternion.identity);
	    }	
    }
}
