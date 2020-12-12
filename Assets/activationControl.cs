using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activationControl : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("dgdf");
        transform.root.gameObject.SetActive(false);
    }
}
