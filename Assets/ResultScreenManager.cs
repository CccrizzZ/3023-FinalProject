using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResultScreenManager : MonoBehaviour
{
    public Button a5;
    public Button a6;

    [SerializeField]
    public GameObject savedData;


    [SerializeField]
    public Button backButton;


    [SerializeField]
    public Canvas self;

    [SerializeField]
    public Image bg;


    [SerializeField]
    public Text newAbility;

    [SerializeField]
    public Text resultText;

    [SerializeField]
    public MyPokemon player;

    [SerializeField]
    public EnemyPokemon enemy;

    Color color = new Color();




    // Start is called before the first frame update
    void Awake()
    {
        a5.gameObject.SetActive(false);
        a6.gameObject.SetActive(false);
        GameObject objRef = GameObject.FindGameObjectWithTag("data");
        data scriptRef = objRef.GetComponent<data>();
        if(scriptRef.activated5 == true)
        {
            Debug.Log("sfsfs");
            a5.gameObject.SetActive(true);
        }

        if (scriptRef.activated6 == true)
        {
            Debug.Log("sffffff");
            a6.gameObject.SetActive(true);
        }



        //bg.transform.position += new Vector3(10000, 0, 0);
        self.sortingOrder = -1;
        color.a = 1f;
        //self.transform.position -= new Vector3(100,0,0);
        bg.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.pHealth <= 0 && enemy.eHealth > 0)
        {
            bg.gameObject.SetActive(true);
            self.sortingOrder = 5;
            bg.color = color;  
            resultText.text = "You Lose";
        }
        if(player.pHealth > 0 && enemy.eHealth <= 0)
        {
            bg.gameObject.SetActive(true);
            self.sortingOrder = 5;
            bg.color = color;
            resultText.text = "You Win";
            GiveOutAbility();   
        }
    }

    bool activated = false;
    void MoveImage()
    {
        
        if(activated == false)
        {
            activated = true;
            bg.transform.position -= new Vector3(2100, 0, 0);
        }
    }

    void GiveOutAbility()
    {
        GameObject objRef = GameObject.FindGameObjectWithTag("data");
        data scriptRef = objRef.GetComponent<data>();

        int ability = Random.Range(5,6);
        if(ability == 5 && scriptRef.activated5 !=true)
        {
            //a5.gameObject.SetActive(true);
            newAbility.text = "You have got a slap ability";
            scriptRef.activated5 = true;
        }
        else if(ability == 6 && scriptRef.activated6 != true)
        {
            //a6.gameObject.SetActive(true);
            newAbility.text = "You have got a kick ability";
            scriptRef.activated6 = true;

        }
        if(scriptRef.activated5 != true && scriptRef.activated6 != true)
        {
            newAbility.text = "You have got all the abilities";
        }
    }

}
