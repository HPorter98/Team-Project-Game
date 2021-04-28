using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 position;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = rigidbody.GetRelativeVector(Vector2.up * 8);
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
