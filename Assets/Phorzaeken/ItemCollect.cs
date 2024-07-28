using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public InventoryQ Inventory1;
    [Space(10)]
    public GameObject item1;
    public GameObject iteme1;
    [Space(10)]
    public GameObject item2;
    public GameObject iteme2;
    [Space(10)]
    public GameObject item3;
    public GameObject iteme3;
    [Space(10)]
    public GameObject item4;
    public GameObject iteme4;
    [Space(10)]
    public GameObject item5;
    public GameObject iteme5;
    [Space(10)]
    public GameObject item6;
    public GameObject iteme6;
    [Space(10)]
    public GameObject item7;
    public GameObject iteme7;
    [Space(10)]
    public GameObject item8;
    public GameObject iteme8;
    [Space(10)]
    public GameObject item9;
    public GameObject iteme9;
    [Space(10)]
    public GameObject item10;
    public GameObject iteme10;
    [Space(10)]
    public GameObject item11;
    public GameObject iteme11;
    [Space(10)]
    public GameObject item12;
    public GameObject iteme12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (item1 == iteme1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i1();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item2 == iteme2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i2();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item3 == iteme3)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i3();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item4 == iteme4)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i4();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item5 == iteme5)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i5();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item6 == iteme6)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i6();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item7 == iteme7)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i7();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item8 == iteme8)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i8();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item9 == iteme9)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i9();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item10 == iteme10)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i10();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item11 == iteme11)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i11();
                    Destroy(gameObject);
                }
            }
        }
        if (collision.tag == "Player")
        {
            if (item12 == iteme12)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Inventory1.i12();
                    Destroy(gameObject);
                }
            }
        }
    }

}