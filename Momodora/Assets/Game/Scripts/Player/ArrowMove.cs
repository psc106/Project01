using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    private Rigidbody2D arrowRigidbody;
    private BoxCollider2D arrowCollider;
    private GameObject monster;

    private float arrowSpeed = default;

    void Awake()
    {
        arrowRigidbody = GetComponent<Rigidbody2D>();
        arrowCollider = GetComponent<BoxCollider2D>();

        arrowSpeed = 30f;
    }

    void Start()
    {
        arrowRigidbody.AddForce(arrowSpeed * transform.right, ForceMode2D.Impulse);

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            monster = collider.gameObject;
            monster.GetComponent<Test>().Hit(10, 1);

            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 1f);
        }
    }
}
