using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;�@�@�@//�{�^�����g�p����̂�UI
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // �{�^�����N���b�N�����Scene�wMainScene�x�Ɉړ�
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
