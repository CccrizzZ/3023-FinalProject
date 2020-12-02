using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPokemon : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject playerRef;
    MyPokemon mypokemonRef;

    public bool attacked;
    
    public int eHealth;
    public int eMana;

    public GameObject TextUI; 
    Text HealthText;

    public GameObject ManaUI;
    Text ManaText;
    List<Ability> AbilityList;

    int totalweight;
    Ability ThunderAbility;
    Ability BubbleAbility;
    Ability Explosion;



    void Start()
    {
        // set health
        eHealth = 100;
        eMana = 100;

        HealthText = TextUI.GetComponent<Text>();
        ManaText = ManaUI.GetComponent<Text>();

     
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




        // Abilities
        AbilityList = new List<Ability>();
        BubbleAbility = new Ability("Bubble", 60);
        AbilityList.Add(BubbleAbility);
        ThunderAbility = new Ability("Thunder", 20);
        AbilityList.Add(ThunderAbility);
        Explosion = new Ability("Explosion", 20);
        AbilityList.Add(Explosion);
        foreach (var item in AbilityList)
        {
            totalweight += item.Weight;
        }
        Debug.Log(totalweight);


    }



    IEnumerator WaitForSeconds (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Attack();
    }

    void Update()
    {
        HealthText.text = eHealth.ToString();
        ManaText.text = eMana.ToString();

        if (!mypokemonRef.PlayerTurn && attacked == false)
        {
            StartCoroutine(WaitForSeconds(4));
        }
    }

    IEnumerator WaitForSeconds2 (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        mypokemonRef.PlayerTurn = true;
    }

    void Attack()
    {
        if (attacked == false)
        {
            Debug.Log("Enemy attcked!");
            WeightedRandomAttack();
            StartCoroutine(WaitForSeconds2(2));
            
        }
        attacked = true;
        

    }

    void WeightedRandomAttack()
    {


        // when low mana
        if (eMana < 15)
        {
            BubbleAbility.Weight = 100;
            ThunderAbility.Weight = 0;
            Explosion.Weight = 0;
        }
        else if (eMana < 20)
        {
            BubbleAbility.Weight = 60;
            ThunderAbility.Weight = 0;
            Explosion.Weight = 40;
        }
        else if (eHealth <= 50)
        {
            BubbleAbility.Weight = 20;
            ThunderAbility.Weight = 40;
            Explosion.Weight = 40;
        }
        
        
        Ability use = Choose();
        if (use.Name == "Thunder")
        {
            USEthunder();
        }
        else if (use.Name == "Bubble")
        {
            USEbubble();
        }
        else if(use.Name == "Explosion")
        {
            USEexplosion();
        }
        
    }

    Ability Choose()
    {
        float choice = Random.Range(0.0f, totalweight);
        Debug.Log(choice);

        var sum = 0;
        foreach (var item in AbilityList)
        {
            for (int i = sum; i < item.Weight + sum; i++)
            {
                if (i >= choice)
                {
                    return item;
                }
            }
            sum += item.Weight;
        }

        return null;
    }
    

    void USEbubble()
    {
        Instantiate(mypokemonRef.bubble, playerRef.transform);
        mypokemonRef.pHealth -= 5;

    }

    void USEthunder()
    {
        if (eMana >= 20)
        {
            Instantiate(mypokemonRef.thunder, playerRef.transform);
            mypokemonRef.pHealth -= 20;
            eMana -= 20;
        }
        else
        {
            Debug.Log("Enemy insufficient Mana"); 
        }
    }


    void USEexplosion()
    {
        if (eMana >= 15)
        {
            Instantiate(mypokemonRef.explosion, playerRef.transform);
            mypokemonRef.pHealth -= 15;
            eMana -= 15;
        }
        else
        {
            Debug.Log("Enemy insufficient Mana");
        }
    }



    public class Ability {
        public Ability(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name;
        public int Weight;
    }

}

