using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Player player;
    public Aisles aisles;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        aisles = GetComponentInChildren<Aisles>();
        animator = player.gameObject.GetComponent<Animator>();

        MovePlayer(aisles.getRandomAisle());
        animator.SetBool("AllowMove", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerAtEndOfAisle()
    {
        //here the game controller is going to puppeteer the player and camera around alittle to make the aisle transition smoother
        MovePlayer(player.GetNextAisle());
        animator.SetBool("AllowMove", true);
    }

    public void MovePlayer(GameObject aisle)
    {
        player.currentIsle = aisle;
        player.transform.position = aisle.GetComponent<Aisle>().start.transform.position;
    }
}
