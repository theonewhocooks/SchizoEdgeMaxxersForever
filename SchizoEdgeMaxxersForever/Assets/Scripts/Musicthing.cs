using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicthing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMusic()
    {
        gameObject.SetActive(false);
        Debug.Log("on");
    }

    public void StartMusic()
    {
        gameObject.SetActive(true);
        Debug.Log("off");
    }
}
