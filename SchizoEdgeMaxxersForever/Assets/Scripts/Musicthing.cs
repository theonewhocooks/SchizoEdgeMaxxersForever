using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicthing : MonoBehaviour
{
    public GameObject audiosource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopMusic()
    {
        audiosource.SetActive(false);
    }
}
