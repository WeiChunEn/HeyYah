using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Play_Time : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField]
    private float _Time;
    public Slider Player1_TimeSlider;
    public Slider Player2_TimeSlider;
    public float _fColorCook;

    public Color _colorRaw;
    public Color _colorCook;
    public Color _colorPlayer1;
    public Color _colorPlayer2;
    public GameObject _player1;
    public GameObject _player2;
    
    void Start()
    {
        _Time = 0;
        _fColorCook = 0.0f;
        _player1.GetComponent<SpriteRenderer>().color = _colorPlayer1;
        _player2.GetComponent<SpriteRenderer>().color = _colorPlayer2;
        _colorPlayer1 = _colorRaw;
        _colorPlayer2 = _colorRaw;
    }
    public void ColorUpdate()
    {
        if (_Time <= 60.0f)
        {
            _Time += 1.0f * Time.deltaTime;
            _fColorCook += 0.015f * Time.deltaTime;
            Player1_TimeSlider.value = _Time;
            Player2_TimeSlider.value = _Time;
            _player1.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(_colorPlayer1, _colorCook, _fColorCook);
            _player2.GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(_colorPlayer2, _colorCook, _fColorCook);
            if (_Time > 60.0f)
            {
                gameManager._bBothDead = true;
            }
        }
        //_player1.GetComponent<SpriteRenderer>().color = new Color(Mathf.Lerp(_colorPlayer1.r, _colorCook.r, 1.0f * Time.deltaTime),
        //    Mathf.Lerp(_colorPlayer1.g, _colorCook.g, 1.0f * Time.deltaTime),
        //    Mathf.Lerp(_colorPlayer1.b, _colorCook.b, 1.0f * Time.deltaTime));
        //_player2.GetComponent<SpriteRenderer>().color = new Color(Mathf.Lerp(_colorPlayer2.r, _colorCook.r, 1.0f * Time.deltaTime),
        //    Mathf.Lerp(_colorPlayer2.g, _colorCook.g, 1.0f * Time.deltaTime),
        //    Mathf.Lerp(_colorPlayer2.b, _colorCook.b, 1.0f * Time.deltaTime));
    }
}
