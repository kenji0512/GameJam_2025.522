using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngin.UI
using UnityEngine.SceneManagement;

public class GameOver_SC : MonoBehaviour
{
    //ボタンをクリックで『Start』へ移動
    public void ButtonClick()
    {
        SceneManager.LoadScene("Start");
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
