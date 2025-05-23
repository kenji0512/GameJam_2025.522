using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject[] Gimmic_Ground;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerRed" || col.gameObject.tag == "PlayerBlue")
        {
            foreach (GameObject go in Gimmic_Ground)
            {
                if (go.activeSelf)
                {
                    go.SetActive(false);
                }
                else
                {
                    go.SetActive(true); //オブジェクトを表示
                }
            }
                       
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerRed" || col.gameObject.tag == "PlayerBlue")
        {
            foreach (GameObject go in Gimmic_Ground)
            {
                if (go.activeSelf)
                {
                    go.SetActive(false);
                }
                else
                {
                    go.SetActive(true); //オブジェクトを表示
                }
            }
        }
    }
}
