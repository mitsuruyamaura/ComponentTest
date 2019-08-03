using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : MonoBehaviour
{
    string call;
    void Start()
    {
        call = "こんにちは";
        Debug.Log(call);
    }

    // Update is called once per frame
    void Update()
    {
        if (call == "こんにちは") {
            string reply = "こんばんは";
            call = reply;
            Debug.Log(call);
        }
    }
}
