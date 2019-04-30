using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public PlayerController thePlayer;

    public GameObject deathSplosion;

    public int gemCount;

    public Text gemText;

    public Image life1;
    public Image life2;
    public Image life3;

    public Sprite lifeFull;
    public Sprite lifeHalf;
    public Sprite lifeEmpty;

    public int maxHealth;
    public int healthCount;

    private bool respawning;



    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();

        gemText.text = "Gems: " + gemCount;

        healthCount = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        healthCount = maxHealth;
        respawning = false;

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddGems(int gemsToAdd)
    {
        gemCount += gemsToAdd;

        gemText.text = "Gems: " + gemCount;

    }

    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
    }
}
