using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class studentInfo : MonoBehaviour
{
    [SerializeField]
    public Text Chris;
    [SerializeField]
    public Text Ivan;

    // Start is called before the first frame update
    void Start()
    {
        Chris.text = "Beining Liu 101193350";
        Ivan.text = "Ivan Kravchenko 101183016";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
