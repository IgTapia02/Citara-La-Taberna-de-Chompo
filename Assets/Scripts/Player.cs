using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);

    }
}
