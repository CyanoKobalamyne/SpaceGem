using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    private LevelManager theLevelManager;
    public int gemValue;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddGems(gemValue);
            Destroy(gameObject);
        }
    }
}

