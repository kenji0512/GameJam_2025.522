using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject Gimmic_Ground;

    // Start is called before the first frame update
    void Start()
    {
        Gimmic_Ground.SetActive(false); //�I�u�W�F�N�g���\��
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Gimmic_Ground.SetActive(true); //�I�u�W�F�N�g��\��
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Gimmic_Ground.SetActive(false); //�I�u�W�F�N�g��\��
        }
    }
}
