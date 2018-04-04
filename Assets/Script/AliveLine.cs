using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveLine : MonoBehaviour {

    public GameManager gameManager;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player":
                gameManager.PlayerWin(col.GetComponent<Player>()._allPlayer);
                break;
        }
    }
}
