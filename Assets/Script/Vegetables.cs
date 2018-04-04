using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour
{
    //public GameObject Vegetable;
    [SerializeField]
    private float _fCheckStart = 0.0f;
    [SerializeField]
    private float _fCheckTime = 1.0f;
    public GameObject veg_del;
    [SerializeField]
    private float _fposi;
    [SerializeField]
    private float _fRandomX;
    public GameObject _gA;
    public int _iMaxVeg = 0;
    public bool _bNewVeg = false;
    public float _fNewVeging = 0.0f;
    public float _fNewVegTime = 3.0f;

    public GameObject _gGame;
    // Use this for initialization
    void Start()
    {
        _fposi = gameObject.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {

        _fCheckStart += Time.deltaTime;
        if (_fCheckStart > 3.0f)
        {
            veg_del.SetActive(true);
        }
        //if (_fCheckStart > _fCheckTime)
        //{
        //    //veg_del.SetActive(false);
        //    _fCheckStart = 0.0f;
        //    put_vegetable();

        //    //Vegetable_end._bOpen = true;

        //}
        if (_bNewVeg)
        {
            NewVeg();
        }


    }
    public void put_vegetable()
    {

        //for (int i = 0; i <Vegetable_end.num; i++)
        //{
        _fRandomX = Random.Range(-5.0f, 5.0f);
        if (_iMaxVeg <= 3)
        {
            GameObject _veg = Instantiate(_gA, new Vector2(_fRandomX, _gA.transform.position.y), _gA.transform.rotation);

            _veg.transform.parent = _gGame.transform;
            _iMaxVeg++;
            _bNewVeg = true;
        }
        // transform.GetChild(i).gameObject.SetActive(true);
        //transform.GetChild(i).gameObject.transform.position = new Vector2(i,_fposi);






        //}
        //    Vegetable_end.num = 0;
    }

    bool NewVeg()
    {
        bool _bNewVeging = false;
        if (_fNewVeging <= _fNewVegTime)
        {
            _bNewVeging = true;
            _fNewVeging += Time.deltaTime;
            veg_del.SetActive(false);
        }
        //時間到
        else
        {
            _fNewVeging = 0.0f;
            _bNewVeg = false;
            _bNewVeging = false;
            veg_del.SetActive(true);
        }
        return _bNewVeging;
    }
}
