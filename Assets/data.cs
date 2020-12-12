using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    [SerializeField]
    public bool activated5 = false;
    [SerializeField]
    public bool activated6 = false;

    private data() { }

    static data instance;
    public static data Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<data>();
            }
            return instance;
        }
        private set { }
    }





    // Start is called before the first frame update
    void Start()
    {
        data[] datas = FindObjectsOfType<data>();
        foreach(data d in datas)
        {
            if(d != Instance)
            {
                Destroy(d.gameObject);
            }
        }

        DontDestroyOnLoad(transform.root);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
