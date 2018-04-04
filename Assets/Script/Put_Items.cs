using UnityEngine;

public class Put_Items : MonoBehaviour
{
    public GameObject[] food;
    public int _iAllKindFood = 0;
    [SerializeField]
    private float[] _fProbility;
    [SerializeField]
    private bool _bOpen;
    [SerializeField]
    private float _fStartTime = 0.0f;
    [SerializeField]
    private float _fAppearTime = 5.0f;
    [SerializeField]
    private float _fRndX = 0.0f;
    [SerializeField]
    private int _iRnd;
    [SerializeField]
    private int _iNum;

    public GameObject _gGame;
    void Start()
    {
        _iAllKindFood = food.Length;

    }

    public void FoodUpdate()
    {
        _fStartTime += Time.deltaTime;
        if (_fStartTime >= _fAppearTime)
        {
            _fStartTime = 0.0f;
            appear();

        }
    }
    void appear()
    {

        _iNum = Random.Range(1, 4);
        for (int i = 0; i < _iNum; i++)
        {

            _fRndX = Random.Range(-5.0f, 5.0f);
            _iRnd = Random.Range(0, _iAllKindFood);
            if (Random.Range(0.0f, 1.0f) > _fProbility[_iRnd])
            {
                GameObject _food;
               _food =Instantiate(food[_iRnd], new Vector2(_fRndX, gameObject.transform.position.y), food[_iRnd].transform.rotation);
                _food.transform.parent = _gGame.transform;
            }
            else
            {
                i--;
            }
        }
    }
}
