using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Vector3 pos;
    public LayerMask GrassLayer;
    bool isMoving;

    bool transition;
    bool canMove;
    float x;
    float y;



    public GameObject MusicMgrRef;
    MusicManager AUmgr;

    void Awake() {
        AUmgr = MusicMgrRef.GetComponent<MusicManager>();
        transition = false;      
    }

    IEnumerator TransitionToBattleScene (float seconds)
    {
        transition = true;
        AUmgr.PlayEncounterTransition();
        Debug.Log("Encountered");

        yield return new WaitForSeconds(seconds);
        
        
        transition = false;
        SceneManager.LoadScene("BattleScene");


    }

    // Update is called once per frame
    void Update()
    {
        // if player can move set the x and y velocity
        if (canMove)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            
        }
        else
        {
            x = 0;
            y = 0;
        }


        // move the player
        transform.position = new Vector3(transform.position.x + x * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x , transform.position.y + y * Time.deltaTime, transform.position.z);
    
  


        // determine if the player is moving
        if(x!=0 || y!=0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }








        // don't move if in battle scene
        if(SceneManager.GetActiveScene().name == "GamePlayScene")
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (!transition)
            {
                canMove = true;
                AUmgr.PlayOverworldMusic();
            }
        }
        else if(SceneManager.GetActiveScene().name == "BattleScene")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            canMove = false;
            AUmgr.PlayBattleSceneMusic();
        } 





        // random encounter mechanism
        if (Physics2D.OverlapCircle(transform.position, 0.1f, GrassLayer) != null && isMoving)
        {
            if (Time.frameCount % 60 == 0)
            {
                if (Random.Range(0, 10000) <= 200)
                {
                    canMove = false;
                    StartCoroutine(TransitionToBattleScene(2.0f));
                }
            }
        }




    }
}













