using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,1);
        Destroy(this.gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
