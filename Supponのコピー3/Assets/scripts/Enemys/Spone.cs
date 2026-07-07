using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spone : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    private int Spn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Spn % 50 == 0)
        {
            Instantiate(cube,new Vector3(0, 0.18f, 0), Quaternion.identity);
            Spn = 0;
        }
        Spn = Spn + 1;
    }
}