    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EscapeButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnEscapeButtonPressed() 
    {
        int chance = Random.Range(1, 10);
        if(chance < 3)
        {
            SceneManager.LoadScene("GamePlayScene");
        }
    }
    

}
