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
            DontDestroyOnLoad(gameObject); // シーンをまたいでもオブジェクトを保持
        }
        else
        {
            Destroy(gameObject); // すでに存在する場合は削除（重複生成を防ぐ）
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
