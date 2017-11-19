using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNotifier : MonoBehaviour
{
    public static TextNotifier instance;

    void Start()
    {
        this.GetComponent<Text>().enabled = false;
    }

    public void SetTextMessage(string text)
    {
        CancelInvoke("RemoveText");

        this.GetComponent<Text>().text = text;
        this.GetComponent<Text>().enabled = true;

        Invoke("RemoveText", 3);
    }

    public void RemoveText()
    {
        this.GetComponent<Text>().enabled = false;
    }
}
