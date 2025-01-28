using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmover : MonoBehaviour
{
    public Transform objectPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = objectPosition.position;
        transform.rotation = objectPosition.rotation;
    }
}
