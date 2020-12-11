using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultScreenManager : MonoBehaviour
{
    [SerializeField]
    public Image bg;


    [SerializeField]
    public Text resultText;

    [SerializeField]
    public MyPokemon player;

    [SerializeField]
    public EnemyPokemon enemy;

    Color color = new Color();


    // Start is called before the first frame update
    void Start()
    {
        color.a = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if(player.pHealth <= 0 && enemy.eHealth > 0)
        {

            bg.color = color;  
            resultText.text = "You Lose";
        }
        if(player.pHealth > 0 && enemy.eHealth <= 0)
        {
            bg.color = color;
            resultText.text = "You Win";
        }
    }
    
}
