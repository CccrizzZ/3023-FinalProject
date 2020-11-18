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


    bool canMove;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
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





        if (Physics2D.OverlapCircle(transform.position, 0.1f, GrassLayer) != null && isMoving)
        {
            if (Random.Range(0, 10000) <= 8)
            {
                SceneManager.LoadScene("BattleScene");
            }
        }

        if(SceneManager.GetActiveScene().name == "GamePlayScene")
        {
            GetComponent<SpriteRenderer>().enabled = true;
            canMove = true; 


        }
        else if(SceneManager.GetActiveScene().name == "BattleScene")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            canMove = false;

        } 


    }
}













