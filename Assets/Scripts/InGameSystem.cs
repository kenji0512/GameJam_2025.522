using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSystem : MonoBehaviour
{
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        _gameManager?.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        _gameManager?.UpdateTimer();
    }
}
