using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable_HP : MonoBehaviour
{
    
    public int _iVegetableHp;
    // Use this for initialization
    void Start ()
    {
        _iVegetableHp = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(_iVegetableHp<=0)
        {
            gameObject.SetActive(false);
        }

	}
  
}
