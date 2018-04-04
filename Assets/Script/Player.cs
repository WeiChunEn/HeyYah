using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Foot foot = null;
    public Anime anime = null;

    /*public enum AllTeam
    {
        none,
        P1Team,
        P2Team
    }*/
    public enum AllPlayer
    {
        noPlayer,
        player1,
        player2

    }
    public AllPlayer _allPlayer = AllPlayer.noPlayer;
    public GameObject _gUnderFoot = null;
    private Rigidbody2D _rigi;
    private string _sPlayer = "";
    private string _sJump = "";

    //public AllTeam _myTeam = AllTeam.none;

    //public Player _P1Team= null;
    //public Player _P2Team = null;

    public bool _bFacingRight = false;
    public bool _bOnTheFood = false;
    //[SerializeField]
    //private bool _bCanJump = false;
    [SerializeField]
    private float _fJumpStart = 0.0f;
    [SerializeField]
    private float _fJumpTime = 2.0f;
    private float _fAxisX;
    [SerializeField]
    private bool _bJumping = false;
    [SerializeField]
    private bool _bKnockBack = false;
    [SerializeField]
    private bool _bKnockCorrect = false;
    [SerializeField]
    private float _fKnockUp = 0.0f;
    [SerializeField]
    private float _fKnockUpTime = 0.3f;
    [SerializeField]
    private float _fKnocking = 0.0f;
    [SerializeField]
    private float _fKnockBackTime = 0.3f;
    [SerializeField]
    private float _fMoveforcex = 3.0f;
    [SerializeField]
    private float _fJumpforce = 6.0f;
    [SerializeField]
    private float _fDownforce = 5.0f;
    [SerializeField]
    private float _fKnockUpforce = 3.0f;
    [SerializeField]
    private float _fKnockBackforce = 3.0f;
    public Slider Time_Slider;
    [SerializeField]
    private float _fTime_control;



    void Awake()
    {
        //玩家設定
        switch (_allPlayer)
        {
            case AllPlayer.noPlayer:
                break;
            case AllPlayer.player1:
                _sPlayer = "Player1_Movement";
                _sJump = "Player1_Jump";
                _bFacingRight = true;
                break;
            case AllPlayer.player2:
                _sPlayer = "Player2_Movement";
                _sJump = "Player2_Jump";
                _bFacingRight = true;
                break;

        }
        //設定腳
        if (foot == null)
        {
            foot = gameObject.GetComponentsInChildren<Foot>()[0];
        }
        //foot._myTeam = _myTeam;
        if (foot.playerMySelf == null)
        {
            foot.playerMySelf = this;
        }




        _rigi = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _fAxisX = Input.GetAxis(_sPlayer);

        //移動
        if (_fAxisX != 0.0f && _bJumping != true)
        {
            Move(true);
            anime._bMoving = true;
            anime._bJumping = false;
        }
        else
        {
            Move(false);
            anime._bMoving = false;
            anime._bJumping = false;
        }
        //跳躍
        if (Input.GetButtonDown(_sJump) && _fJumpStart > _fJumpTime)
        {
            //_bJumping = true;
            Jump();
            anime._bJumping = true;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();

            _fJumpStart = 0.0f;
            if (_gUnderFoot != null && _bOnTheFood)
            {
                _gUnderFoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_fDownforce);
                switch (_gUnderFoot.tag)
                {
                    case "Hama":
                        //print(_gUnderFoot.GetComponent<Animator>());
                        _gUnderFoot.GetComponent<Animator>().SetBool("Open", true);
                        break;
                }
            }
        }
        _fJumpStart += Time.deltaTime;
        //if (!anime._bJumping && !anime._bMoving)
        //{
        //    anime._bIdling = true;
        //}


    }
    public void StampSuccessful(bool _bSameTeam)
    {
        //不同隊
        if (!_bSameTeam)
        {
            // print("Getout");
            _bKnockBack = true;
        }
        /*else
        {
            _bKnockBack = true;
        }*/

        //StartCoroutine(KnockBack(0.05f, 500, this.gameObject.transform.position));
    }
    public void StampSuccess(bool _bPlayer)
    {
        if (!_bPlayer)
        {
            _bKnockCorrect = true;
        }

    }
    void Move(bool _bMoving)
    {
        if (_bMoving)
        {
            //方向控制
            if (!_bFacingRight && _fAxisX > 0.0f)
            {
                gameObject.transform.Rotate(0, -180, 0);
                //print("right");
                _bFacingRight = true;
            }
            else if (_bFacingRight && _fAxisX < 0.0f)
            {
                gameObject.transform.Rotate(0, -180, 0);
                //print("left");
                _bFacingRight = false;
            }
            //移動
            _rigi.velocity = new Vector2(_fAxisX * _fMoveforcex, _rigi.velocity.y);
        }
        else
        {
            //if (_rigi.velocity.x != 0.0)
            _rigi.velocity = new Vector2(0.0f, _rigi.velocity.y);
        }
    }
    //跳躍
    void Jump()
    {

        _rigi.velocity = new Vector2(0, _fJumpforce);
        anime._bMoving = false;
        //anime._bIdling = false;

    }
    //在地板
    /*void CanJump(bool _bOnTheGround)
    {
        if (_bOnTheGround)
        {
            _bCanJump = true;
        }
        else
        {
            _bCanJump = false;
        }
    }*/
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _fTime_control = Time_Slider.value;
        if (_bKnockBack)
        {
            KnockBack();
        }
        if (_bKnockCorrect)
        {
            //print(1);
            KnockCorrect();
        }
        if (_fTime_control <= 30)
        {
            _fJumpTime = 0.5f;
            _fJumpforce = 3.0f;
            _fMoveforcex = 1.5f;
        }
        else if (_fTime_control <= 50)
        {
            _fJumpTime = 0.75f;
            _fJumpforce = 4.0f;
            _fMoveforcex = 4.0f;
        }
        else
        {
            _fJumpTime = 0.75f;
            _fJumpforce = 5.0f;
            _fMoveforcex = 5.0f;
        }

    }
    bool KnockBack()
    {
        bool _bKnocking = false;
        if (_fKnocking <= _fKnockBackTime)
        {
            _bKnocking = true;
            _fKnocking += Time.deltaTime;
            //if (_bFacingRight)
            //{
            _rigi.velocity = new Vector2(0, -_fKnockBackforce);
            //print("123  " + _rigi.velocity.x);
            //_rigi.AddForce(new Vector3(_v3KnockBackDir.x * -300, _v3KnockBackDir.y * _fKnockBackPwr, 0));
            //}
            /*else
            {
                _rigi.velocity = new Vector2(0, -_fKnockBackforce);
                //print("456  " + _rigi.velocity.x);
                //_rigi.AddForce(new Vector3(_v3KnockBackDir.x * 300, _v3KnockBackDir.y * _fKnockBackPwr, 0));
            }*/
        }
        //時間到
        else
        {
            _fKnocking = 0.0f;
            _bKnockBack = false;
            _bKnocking = false;
        }
        return _bKnocking;
    }
    bool KnockCorrect()
    {
        bool _bKnock = false;
        if (_fKnockUp <= _fKnockUpTime)
        {
            _bKnock = true;
            _fKnockUp += Time.deltaTime;
            //if (_bFacingRight)
            //{
            _rigi.velocity = new Vector2(0, _fKnockUpforce);
            //print("123  " + _rigi.velocity.x);
            //_rigi.AddForce(new Vector3(_v3KnockBackDir.x * -300, _v3KnockBackDir.y * _fKnockBackPwr, 0));
            //}
            /*else
            {
                _rigi.velocity = new Vector2(0, -_fKnockBackforce);
                //print("456  " + _rigi.velocity.x);
                //_rigi.AddForce(new Vector3(_v3KnockBackDir.x * 300, _v3KnockBackDir.y * _fKnockBackPwr, 0));
            }*/
        }
        //時間到
        else
        {
            _fKnockUp = 0.0f;
            _bKnockCorrect = false;
            _bKnock = false;
        }
        return _bKnock;
    }
}
