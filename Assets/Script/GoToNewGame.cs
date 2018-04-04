using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewGame : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        SceneManager.LoadScene("HeyYah");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
