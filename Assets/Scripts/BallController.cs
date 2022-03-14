using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _ballSpeed = 5;
    [SerializeField] private Text _playerScoreText;
    [SerializeField] private Text _enemyScoreText;
    
    private Transform _transform;
    private int _playerScore = 0;
    private int _enemyScore = 0;
    private float boost = 1;

    private Vector3 startDirection;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        startDirection = generateStartDirection();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(startDirection * _ballSpeed * boost * Time.deltaTime);
    }

    private Vector3 generateStartDirection()
    {
        Vector3 generatedVector3 = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        if (generatedVector3.x < 0.5f && generatedVector3.x > -0.5f || generatedVector3.y < 0.5f && generatedVector3.y > -0.5f)
        {
            generatedVector3 = generateStartDirection();
        }
        return generatedVector3;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startDirection.x *= -1;
            if (boost == 1)
            {
                boost *= 2;
            }
        }

        if (col.gameObject.tag == "HitBox")
        {
            startDirection.y *= -1;
        }

        if (col.gameObject.tag == "PlayerScored")
        {
            _playerScore++;
            scoreDisplayUpdate();
            resetGame();
        }
        
        if (col.gameObject.tag == "EnemyScored")
        {
            _enemyScore++;
            scoreDisplayUpdate();
            resetGame();
        }
    }

    private void resetGame()
    {
        _transform.position = Vector3.zero;
        startDirection = generateStartDirection();
        boost = 1;
    }

    private void scoreDisplayUpdate()
    {
        _playerScoreText.text = _playerScore.ToString();
        _enemyScoreText.text = _enemyScore.ToString();
    }

}
