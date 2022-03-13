using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _transform;
    private Transform _ballPosition;

    [SerializeField] private float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _ballPosition = GameObject.FindWithTag("Ball").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 normalized =_ballPosition.transform.position - _transform.position;
        Vector3.Normalize(normalized);
        _transform.Translate(0, normalized.y * moveSpeed * Time.deltaTime, 0);
    }
}
