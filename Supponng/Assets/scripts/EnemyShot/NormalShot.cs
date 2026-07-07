using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class NormalShot : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private SphereCollider BC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
