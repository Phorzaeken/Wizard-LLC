using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryQ : MonoBehaviour
{
    public int item1;
    public int item2;
    public int item3;
    public int item4;
    public int item5;
    public int item6;
    public int item7;
    public int item8;
    public int item9;
    public int item10;
    public int item11;
    public int item12;

    public TMP_Text playeritems;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentitems = item1 + item2 + item3 + item4 + item5 + item6 + item7 + item8 + item9 + item10 + item11 + item12;
        playeritems.text = "Items Collected: " + currentitems.ToString() + "/" + "12";
    }

    public void i1()
    {
        item1 = 1;
    }

    public void i2()
    {
        item2 = 1;
    }

    public void i3()
    {
        item3 = 1;
    }

    public void i4()
    {
        item4 = 1;
    }

    public void i5()
    {
        item5 = 1;
    }

    public void i6()
    {
        item6 = 1;
    }

    public void i7()
    {
        item7 = 1;
    }
    public void i8()
    {
        item8 = 1;
    }

    public void i9()
    {
        item9 = 1;
    }

    public void i10()
    {
        item10 = 1;
    }

    public void i11()
    {
        item11 = 1;
    }

    public void i12()
    {
        item12 = 1;
    }
}
