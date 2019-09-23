using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public GameObject player;
    public Text loseText;
    public Text loseDrop;

    private void Start()
    {
        loseText.text = "";
        loseDrop.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (health <= 0)
            {
                loseText.text = "You Lose!";
                loseDrop.text = "You Lose!";
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("Challenge1");
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
        }
    }
}
