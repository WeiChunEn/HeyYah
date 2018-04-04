using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    public Player playerMySelf = null;

    //public delegate void StampSomeone(bool _bSameTeam);
    //public StampSomeone stampSomeone = null;
    public delegate void OnTheGround(bool _bOnTheGround);
    public OnTheGround onTheGround = null;

    public enum AllLimbs
    {
        none,
        Foot
    }
    public AllLimbs allLimbs = AllLimbs.none;
    //public Player.AllTeam _myTeam = Player.AllTeam.none;


    void OnTriggerStay2D(Collider2D col)
    {
        switch (allLimbs)
        {
            case AllLimbs.Foot:
                switch (col.tag)
                {                   
                    case "Player":
                        //Player otherPlayer = col.GetComponent<Player>();
                        if (!playerMySelf._bOnTheFood)
                        {
                            playerMySelf._bOnTheFood = true;
                            playerMySelf._gUnderFoot = col.gameObject;
                        }
                        //不同隊
                        //if (_myTeam != otherPlayer._myTeam)
                        //{
                        //    //gameObject.GetComponent<Player>().StampSuccess(false);
                        //    gameObject.GetComponentInParent<Player>().StampSuccess(false);
                        //    otherPlayer.StampSuccessful(false);
                        //}
                        
                       
                        break;
                    case "Food":

                       
                        break;
                    case "Hama":
                        playerMySelf._bOnTheFood = true;
                        playerMySelf._gUnderFoot = col.gameObject;
                        break;  
                }
                break;
            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        switch (allLimbs)
        {
            case AllLimbs.Foot:
                switch (col.tag)
                {
                    case "Player":
                        //Player otherPlayer = col.GetComponent<Player>();
                        if (playerMySelf._bOnTheFood)
                        {
                            playerMySelf._bOnTheFood = false;
                            playerMySelf._gUnderFoot = null;
                        }
                        break;
                    case "Hama":
                        playerMySelf._bOnTheFood = false;
                        playerMySelf._gUnderFoot = null;
                        break;

                }
                break;
            
        }
    }
}
