using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable_end : MonoBehaviour
{
    static public int num;
    public Vegetables vegetables;
    // public bool _bOpen;
    // Use this for initialization
    void Start()
    {
        //_bOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.SetActive(_bOpen);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "veg":
                //print(2);
                vegetables.put_vegetable();
                //col.gameObject.SetActive(false);
                num++;
                break;
        }
    }
}
