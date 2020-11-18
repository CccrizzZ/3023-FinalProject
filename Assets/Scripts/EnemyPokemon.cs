using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPokemon : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject playerRef;
    MyPokemon mypokemonRef;

    public bool attacked;

    void Start()
    {
        // set player reference
        mypokemonRef = playerRef.gameObject.GetComponent<MyPokemon>();

        // flag for attacked
        attacked = false;
        
        // set sprite randomly
        spriteRenderer = GetComponent<SpriteRenderer>();
        float random = Random.Range(1,7);
        if (random <= 2)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Avatars/gyarados");
        }
        else if (random <= 4)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Avatars/omastar");
        }
        else if (random <= 6)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Avatars/basculin");
        }

    }


    IEnumerator WaitForSeconds2 (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        mypokemonRef.PlayerTurn = true;
    }

    IEnumerator WaitForSeconds (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Attack();
    }

    void Update()
    {
        
        if (!mypokemonRef.PlayerTurn && attacked == false)
        {
            StartCoroutine(WaitForSeconds(4));
        }
    }

    void Attack()
    {
        if (attacked == false)
        {
            Debug.Log("Enemy attcked!");
            Instantiate(mypokemonRef.thunder, playerRef.transform);
            StartCoroutine(WaitForSeconds2(2));
            
        }
        attacked = true; 
        

    }

    // public void Flash()
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         WaitEnable();
    //         WaitDisable();
    //         Debug.Log("flash");
    //     }
    // }

    // IEnumerator WaitDisable()
    // {
    //     GetComponent<Renderer>().enabled = false;
    //     yield return new WaitForSeconds(0.2f);
    // }
    
    // IEnumerator WaitEnable()
    // {
    //     GetComponent<Renderer>().enabled = true;
    //     yield return new WaitForSeconds(0.2f);
    // }

    
}
