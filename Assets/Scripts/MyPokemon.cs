using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public int pHealth;
    public int pMana;

    public GameObject PhealthText;
    Text HealthText;

    public GameObject PManaText;
    Text ManaText;



    

    void Awake() {
        PlayerTurn = true;
        ep = enemy.GetComponent<EnemyPokemon>();
        pHealth = 100;
        pMana = 100;

        HealthText = PhealthText.GetComponent<Text>();
        ManaText = PManaText.GetComponent<Text>();
    }

    void Update()
    {
        HealthText.text = pHealth.ToString();
        ManaText.text = pMana.ToString();
        
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
        ep.eHealth -= 5;
        pMana -= 5;
        StartCoroutine(WaitForSs(1));
    }


    public void A2()
    {
        // laser
        Instantiate(laser, transform.position - new Vector3(0.2f,0.0f,0) , Quaternion.identity);
        Debug.Log("Used Laser!");
        PlayerTurn = false;
        ep.eHealth -= 10;
        pMana-=10;
        StartCoroutine(WaitForSs(1));
        

    }
    
    
    
    public void A3()
    {
        if (pMana >= 20)
        {
            // thunder
            Instantiate(thunder, enemy.transform);
            Debug.Log("Used Thunder!");
            PlayerTurn = false;
            ep.eHealth -= 20;
            pMana -= 20;
            StartCoroutine(WaitForSs(2));
        }
        else
        {
            Debug.Log("Insufficient Mana!");
        }


    }
    


    public void A4()
    {
        if (pMana >= 20)
        {
            // explosion
            Instantiate(explosion, enemy.transform);
            Debug.Log("Used Explotion!");
            PlayerTurn = false;
            ep.eHealth -= 15;
            pMana -= 15;
            StartCoroutine(WaitForSs(1));
        }
        else
        {
            Debug.Log("Insufficient Mana!");
        }
        
    }


    //abilities that can be randomly gained if winning the battle
    public void A5()
    {

    }


    public void A6()
    {

    }

    public void A7()
    {

    }

}
