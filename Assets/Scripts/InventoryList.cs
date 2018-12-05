using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour {

    public int indexItems; //dont change in inspector
    private int maxIndex = 7;

    public GameObject[] itemList;
    public Image[] itemBox;
    //public Sprite selectedBox;

    public ItemBoxController itemBoxController;

    public enum State { Selected, Deselected };
    public State Status;

    // Use this for initialization
    void Start () {
        itemBoxController = GameObject.Find("ItemBox").GetComponent<ItemBoxController>();
        indexItems = 0;
        maxIndex = itemList.Length;
        maxIndex = itemBox.Length;
	}
	
	// Update is called once per frame
	void Update () {
     
        itemsNavigation();
        itemSelection();

        if (indexItems < 0)
        {
            indexItems = 0;
        }
        else if (indexItems > maxIndex)
        {
            indexItems = 0;
        }
	}

    void itemsNavigation()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            indexItems = indexItems + 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            indexItems = indexItems - 1;
        }

    }

    void itemSelection()
    {
        switch (indexItems)
        {
            case 0:
                //if ha piú di 1 di quell'oggetto
                    //funzione oggetto
                    //quantitá -1
                //if ne ha 0
                    //sprite grayato
                break;
        }
    }

}
