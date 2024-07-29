using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTxtCanvas : MonoBehaviour
{
    public GameObject itemobjtxt;
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
            itemobjtxt.SetActive(true);
        }
        else if (collision.tag != "Player")
        {
            itemobjtxt.SetActive(false);
        }
    }
}
