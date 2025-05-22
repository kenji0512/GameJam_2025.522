using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　　　//ボタンを使用するのでUI
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // ボタンをクリックするとScene『MainScene』に移動
    public void ButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
