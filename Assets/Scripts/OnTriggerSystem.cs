using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSystem : MonoBehaviour
{
    BoxCollider2D _boxCollider2d;

    private void Start()
    {
        _boxCollider2d = transform.parent.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerRed" && gameObject.tag == "Red")
        {
            _boxCollider2d.isTrigger = true;
        }

        if (collision.gameObject.tag == "PlayerBlue" && gameObject.tag == "Red")
        {
            _boxCollider2d.isTrigger = false;
        }

        if (collision.gameObject.tag == "PlayerBlue" && gameObject.tag == "Blue")
        {
            _boxCollider2d.isTrigger = true;
        }

        if (collision.gameObject.tag == "PlayerRed" && gameObject.tag == "Blue")
        {
            _boxCollider2d.isTrigger = false;
        }

    }
}
