using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_inout : MonoBehaviour
{
    public GameObject _fPlayer1;
    public GameObject _fPlayer2;
    [SerializeField]
    private float _fPlayer1Y;
    [SerializeField]
    private float _fPlayer2Y;
    [SerializeField]
    private Vector3 new_posi;
    [SerializeField]
    private Vector3 Bottom_posi = new Vector3(0, -1.4f, -10f);
    [SerializeField]
    private Vector3 Top_posi = new Vector3(0, 1.46f, -10f);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void CameraUpdate()
    {

        _fPlayer1Y = _fPlayer1.transform.position.y;
        _fPlayer2Y = _fPlayer2.transform.position.y;
        if (_fPlayer1Y <= 0.0f && _fPlayer2Y <= 0.0f)
        {
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 3.55f, Time.deltaTime);
            new_posi = Vector3.Lerp(gameObject.transform.position, Bottom_posi, Time.deltaTime);
            gameObject.transform.position = new_posi;
        }
        else if (_fPlayer1Y > 0.0f || _fPlayer2Y > 0.0f)
        {
            gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 6.5f, Time.deltaTime);
            new_posi = Vector3.Lerp(gameObject.transform.position, Top_posi, Time.deltaTime);
            gameObject.transform.position = new_posi;
        }
    }
}
