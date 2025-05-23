using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoving : MonoBehaviour
{
   
    [SerializeField] float _speed = 1f;
    [SerializeField] float _radius = 1f;
    [SerializeField]MoveDirection _direction;
    Vector2 _initialPosition;
    void Start()
    {
        _initialPosition = transform.position;
    }

    void Update()
    {
        WallMoveOnUpdate();
    }


    void WallMoveOnUpdate()
    {
        float offset = _radius * Mathf.Sin(_speed * Time.time);
        Vector2 newPosition = _initialPosition;

        switch (_direction)
        {
            case MoveDirection.Horizontal:
                newPosition.x += offset;
                break;
            case MoveDirection.Vertical:
                newPosition.y += offset;
                break;
        }

        transform.position = newPosition;
    }

    public enum MoveDirection
    {
        Horizontal,
        Vertical
    }
}
