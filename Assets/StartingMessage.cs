using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingMessage : MonoBehaviour
{
    public GameObject textField;
    void Start()
    {
        StartCoroutine(timeToKeepMessage());
    }

    IEnumerator timeToKeepMessage()
    {
        yield return new WaitForSeconds(1);
        textField.SetActive(false);
    }
}
