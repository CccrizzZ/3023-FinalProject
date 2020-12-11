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
    public bool canMove;
    float x;
    float y;

    [SerializeField]
    Rigidbody2D rigidBody;

    float speed = 1.0f;
    public GameObject MusicMgrRef;
    MusicManager AUmgr;
    Vector2 movementVector;
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
            movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementVector *= speed;
            rigidBody.velocity = movementVector;  
            isMoving = true;
            
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
            isMoving = false;
            // x = 0;
            // if
        }


        // // move the player
        // transform.position = new Vector3(transform.position.x + x * Time.deltaTime, transform.position.y, transform.position.z);
        // transform.position = new Vector3(transform.position.x , transform.position.y + y * Time.deltaTime, transform.position.z);

  


        // determine if the player is moving
        // if(x!=0 || y!=0)
        // {
        //     isMoving = true;
        // }
        // else
        // {
        //     isMoving = false;
        // }








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
                Debug.Log("walking");
                if (Random.Range(0, 10000) <= 200)
                {
                    Debug.Log("Encounterd");
                    canMove = false;
                    StartCoroutine(TransitionToBattleScene(2.0f));
                }
            }
        }




    }
}













