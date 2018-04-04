using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera_inout cameraInOut;
    public Play_Time playTime;
    public Put_Items putItem;


    public GameObject _gStart_Stuff;
    public GameObject _gStart_Game;
    public GameObject _gStart_Help;

    public GameObject _gStuff;
    public GameObject _gStuff_Stuff;

    public GameObject _gPlay;
    public GameObject _gPlayer1;
    public GameObject _gPlayer2;
    public GameObject _gHelp_Help;

    public GameObject _gGame;
    public GameObject _gPlayer1Time;
    public GameObject _gPlayer2Time;
    public GameObject _gGame_Stuff;
    public GameObject _gGame_Game;
    public GameObject _gGame_Help;

    public GameObject _gHeya;
    public GameObject _gSoup;

    public GameObject _gEndBothDead;
    public GameObject _gEndPlayer1Win;
    public GameObject _gEndPlayer2Win;

    //public GameObject _gEnd_Color;
    public GameObject _gEnd_Start;
    public GameObject _gEnd_Game;
    public GameObject _gEnd_Background;

    public Camera _gCamera;
    public AudioClip _audioMenu;
    public AudioClip _audioGame;
    public AudioClip _audioPlayer1Win;
    public AudioClip _audioPlayer2Win;
    public AudioClip _audioBothDead;

    public enum AllMenu
    {
        Menu,
        Help,
        Staff,
        Game,
        End
    }
    public AllMenu nowMenu = AllMenu.Menu;

    public bool _bBothDead = false;
    public bool _bPlayer1Win = false;
    public bool _bPlayer2Win = false;
    bool _bEnd = false;

    public bool _bGoNewGame = false;
    public float _fGoNewGameing = 0.0f;
    public float _fGoNewGameTime = 3.0f;
    void Start()
    {
        _gCamera.GetComponent<AudioSource>().clip = _audioMenu;
        _gCamera.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        switch (nowMenu)
        {
            case AllMenu.Game:
                Game();
                break;
            case AllMenu.End:
                if (!_bEnd)
                {
                    End();
                }
                break;
        }
        if (_bGoNewGame)
        {
            GoNewGame();
        }
    }
    void Game()
    {
        if (!_bBothDead && !_bPlayer1Win && !_bPlayer2Win)
        {
            cameraInOut.CameraUpdate();
            playTime.ColorUpdate();
            putItem.FoodUpdate();
        }
        else
        {
            nowMenu = AllMenu.End;
        }
    }
    void End()
    {
        //print("end");
        if (_bPlayer1Win)
        {
            _gCamera.GetComponent<AudioSource>().clip = _audioPlayer1Win;
            _gCamera.GetComponent<AudioSource>().Play();
            _gEndBothDead.SetActive(false);
            _gEndPlayer1Win.SetActive(true);
            _gEndPlayer2Win.SetActive(false);
            _gEnd_Start.SetActive(false);
            _gEnd_Game.SetActive(false);
            _gEnd_Background.SetActive(false);
            //print("Player1Win");
        }
        else if (_bPlayer2Win)
        {
            _gCamera.GetComponent<AudioSource>().clip = _audioPlayer2Win;
            _gCamera.GetComponent<AudioSource>().Play();
            _gEndBothDead.SetActive(false);
            _gEndPlayer1Win.SetActive(false);
            _gEndPlayer2Win.SetActive(true);
            _gEnd_Start.SetActive(false);
            _gEnd_Game.SetActive(false);
            _gEnd_Background.SetActive(false);
            //print("Player2Win");
        }
        else if (_bBothDead)
        {
            _gCamera.GetComponent<AudioSource>().clip = _audioBothDead;
            _gCamera.GetComponent<AudioSource>().Play();
            _gEndBothDead.SetActive(true);
            _gEndPlayer1Win.SetActive(false);
            _gEndPlayer2Win.SetActive(false);
            _gEnd_Start.SetActive(false);
            _gEnd_Game.SetActive(false);
            _gEnd_Background.SetActive(false);
            //print("BothDead");
        }
        _bEnd = true;
        _bGoNewGame = true;
    }

    bool GoNewGame()
    {
        bool _bGoNewGameing = false;
        if (_fGoNewGameing <= _fGoNewGameTime)
        {
            _bGoNewGameing = true;
            _fGoNewGameing += Time.deltaTime;
        }
        //時間到
        else
        {
            _fGoNewGameing = 0.0f;
            _bGoNewGame = false;
            _bGoNewGameing = false;
            Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Temp");
        }
        return _bGoNewGameing;
    }

    public void StartMenuBtn()
    {
        nowMenu = AllMenu.Menu;
        _gStart_Stuff.SetActive(true);
        _gStart_Game.SetActive(true);
        _gStart_Help.SetActive(true);
        _gStuff.SetActive(false);
        _gStuff_Stuff.SetActive(false);
        _gPlay.SetActive(false);
        _gPlayer1.SetActive(false);
        _gPlayer2.SetActive(false);
        _gHelp_Help.SetActive(false);
        _gGame.SetActive(false);
        _gPlayer1Time.SetActive(false);
        _gPlayer2Time.SetActive(false);
        _gGame_Stuff.SetActive(false);
        _gGame_Game.SetActive(false);
        _gGame_Help.SetActive(false);
        _gHeya.SetActive(true);
        _gSoup.SetActive(true);
        //print("GoToStartMenu");
    }
    public void HelpBtn()
    {
        nowMenu = AllMenu.Help;
        _gStart_Stuff.SetActive(true);
        _gStart_Game.SetActive(true);
        _gStart_Help.SetActive(false);
        _gStuff.SetActive(false);
        _gStuff_Stuff.SetActive(false);
        _gPlay.SetActive(true);
        _gPlayer1.SetActive(true);
        _gPlayer2.SetActive(true);
        _gHelp_Help.SetActive(true);
        _gGame.SetActive(false);
        _gPlayer1Time.SetActive(false);
        _gPlayer2Time.SetActive(false);
        _gGame_Stuff.SetActive(false);
        _gGame_Game.SetActive(false);
        _gGame_Help.SetActive(false);
        _gHeya.SetActive(true);
        _gSoup.SetActive(true);
        //print("GoToHelp");
    }
    public void StuffBtn()
    {
        nowMenu = AllMenu.Staff;
        _gStart_Stuff.SetActive(false);
        _gStart_Game.SetActive(true);
        _gStart_Help.SetActive(true);
        _gStuff.SetActive(true);
        _gStuff_Stuff.SetActive(true);
        _gPlay.SetActive(false);
        _gPlayer1.SetActive(false);
        _gPlayer2.SetActive(false);
        _gHelp_Help.SetActive(false);
        _gGame.SetActive(false);
        _gPlayer1Time.SetActive(false);
        _gPlayer2Time.SetActive(false);
        _gGame_Stuff.SetActive(false);
        _gGame_Game.SetActive(false);
        _gGame_Help.SetActive(false);
        _gHeya.SetActive(true);
        _gSoup.SetActive(true);
        //print("GoToStuff");
    }
    public void GameBtn()
    {
        nowMenu = AllMenu.Game;
        _gStart_Stuff.SetActive(false);
        _gStart_Game.SetActive(false);
        _gStart_Help.SetActive(false);
        _gStuff.SetActive(false);
        _gStuff_Stuff.SetActive(false);
        _gPlay.SetActive(false);
        _gPlayer1.SetActive(false);
        _gPlayer2.SetActive(false);
        _gHelp_Help.SetActive(false);
        _gGame.SetActive(true);
        _gPlayer1Time.SetActive(true);
        _gPlayer2Time.SetActive(true);
        _gGame_Stuff.SetActive(true);
        _gGame_Game.SetActive(true);
        _gGame_Help.SetActive(true);
        _gHeya.SetActive(false);
        _gSoup.SetActive(false);

        _gCamera.GetComponent<AudioSource>().clip = _audioGame;
        _gCamera.GetComponent<AudioSource>().Play();
        //print("GoToGame");
    }
    public void PlayerWin(Player.AllPlayer _whichPlayer)
    {
        nowMenu = AllMenu.End;
        switch (_whichPlayer)
        {
            case Player.AllPlayer.noPlayer:
                break;
            case Player.AllPlayer.player1:
                _bPlayer1Win = true;
                break;
            case Player.AllPlayer.player2:
                _bPlayer2Win = true;
                break;
        }
    }


}
