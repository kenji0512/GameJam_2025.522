using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTake : MonoBehaviour
{
    public static SceneTake Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��I�u�W�F�N�g��ێ�
        }
        else
        {
            Destroy(gameObject); // ���łɑ��݂���ꍇ�͍폜�i�d��������h���j
        }
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
