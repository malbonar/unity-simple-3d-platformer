using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 moveOffset;

    private Vector3 _targetPos;
    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
        _targetPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);

        if (transform.position == _targetPos) 
        {
            _targetPos = _targetPos == _startPos ? _startPos + moveOffset : _startPos;
        }
    }
}
