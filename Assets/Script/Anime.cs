using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{ 
    
    private Animator anim;
    public bool _bJumping;
    public bool _bMoving;
    public bool _bIdling;
    public bool _bGetDowning;
    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	
	void Update ()
    {
        anim.SetBool("Jump",_bJumping);
        anim.SetBool("Move", _bMoving);
        anim.SetBool("Idle", _bIdling);
        //anim.SetBool("GetDown", _bGetDowning);
		
	}
}
