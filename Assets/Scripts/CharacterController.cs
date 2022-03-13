using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private Transform _transform;
    [SerializeField] private float _moveSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }
    }
}
