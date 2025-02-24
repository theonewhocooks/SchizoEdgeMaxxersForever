using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectmover : MonoBehaviour
{
    public Transform objectPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = objectPosition.rotation;
    }
}
