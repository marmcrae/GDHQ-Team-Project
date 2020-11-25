using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.8f)
        {
            float randomX = Random.Range(-9.8f, 9.8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log("player destroy");
            other.transform.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Debug.Log("Laser destroy");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
