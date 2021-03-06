﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public enum ITEM_TYPES { KEY_BASIC, SIZE }
    // Use this for initialization
    public Dictionary<ITEM_TYPES, int> collection;

	void Start () {
        collection = new Dictionary<ITEM_TYPES, int>();
	}

    public void Collect(ITEM_TYPES collected_type)
    {
        int number_collected;
        collection.TryGetValue(collected_type, out number_collected);
        collection[collected_type] = number_collected + 1;
        Debug.Log("Currently have " + (number_collected + 1) + " items");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool HasKey()
    {
        int val;
        collection.TryGetValue(ITEM_TYPES.KEY_BASIC, out val);
        return (val > 0);
    }

    public void ConsumeKey()
    {
        int number_collected;
        collection.TryGetValue(ITEM_TYPES.KEY_BASIC, out number_collected);
        if(number_collected > 0)
        collection[ITEM_TYPES.KEY_BASIC] = number_collected - 1;
        Debug.Log("Currently have " + collection[ITEM_TYPES.KEY_BASIC] + " items");
    }

    public void Clear()
    {
        collection = new Dictionary<ITEM_TYPES, int>();
    }
}
