using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGameplayLevelButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update



    public void OnLoadLevelClicked()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
