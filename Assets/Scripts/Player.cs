using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.5f;
    [SerializeField]
    private GameObject _LazerPrefab;
    private float _fireRate = 0.15f;
    private float _nextFire = 0.1f;
    [SerializeField]
    private int _playerLives = 3;

    void Start()
    {
        transform.position = new Vector3(0, -1, 0);
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLazer();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);

        if (transform.position.y >= -1)
        {
            transform.position = new Vector3(transform.position.x, -1, 0);
        }

        else if (transform.position.y <= -4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }

        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }

        else if (transform.position.x <= -10)
        {
            transform.position = new Vector3(10, transform.position.y, 0);
        }


    }
    void FireLazer()
    {
        _nextFire = Time.time + _fireRate;
        Instantiate(_LazerPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);

    }

    public void Damage()
    {
        _playerLives--;

        if (_playerLives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
