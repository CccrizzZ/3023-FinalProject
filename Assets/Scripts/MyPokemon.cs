using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPokemon : MonoBehaviour
{
    // References for ability
    public GameObject bubble;
    public GameObject laser;
    public GameObject thunder;
    public GameObject explosion;

    // Reference for enemy
    public GameObject enemy;
    EnemyPokemon ep;
    

    // Reference for canvas
    public Canvas CanvasRef;

    public bool PlayerTurn;

    void Awake() {
        PlayerTurn = true;
        ep = enemy.GetComponent<EnemyPokemon>();
    }

    void Update()
    {
        if (PlayerTurn)
        {
            CanvasRef.gameObject.SetActive(true);

        }
        else
        {
            CanvasRef.gameObject.SetActive(false);

        }


    }


    IEnumerator WaitForSs (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ep.attacked = false;

    }




    public void A1()
    {
        // bubble
        Instantiate(bubble, enemy.transform);
        Debug.Log("Used Bubble!");
        PlayerTurn = false;
        StartCoroutine(WaitForSs(1));
    }

    public void A2()
    {
        // laser
        Instantiate(laser, transform.position - new Vector3(0.2f,0.0f,0) , Quaternion.identity);
        Debug.Log("Used Laser!");
        PlayerTurn = false;
        StartCoroutine(WaitForSs(1));


    }
    
    
    
    public void A3()
    {
        // thunder
        Instantiate(thunder, enemy.transform);
        Debug.Log("Used Thunder!");
        PlayerTurn = false;
        StartCoroutine(WaitForSs(2));


    }
    


    public void A4()
    {
        // explosion
        Instantiate(explosion, enemy.transform);
        Debug.Log("Used Explotion!");
        PlayerTurn = false;
        StartCoroutine(WaitForSs(1));

        
    }
}
