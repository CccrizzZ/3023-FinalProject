using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadLevel : MonoBehaviour
{


    //play click sound
    //load level

    public void OnLoadLevelButtonClicked()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    IEnumerator DelayLoad()
    {
        
        yield return new WaitForSeconds(0.5f);
        
    }   

}
