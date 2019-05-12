using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;


    public GameObject dethParticle;
    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    public float respawnDelay;

    private CameraController myndavel;

    private float gravityStore;

    public HealthManager healthManager;

    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<PlayerController>();

        myndavel = FindObjectOfType<CameraController>();

        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(dethParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        myndavel.isFollowing = false;

        /*  (this is not needed now)
         -------------- gravity 5 is stored ----------------------
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        --------------- gravity changed to 0 ----------------------
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        */
        powerPoint.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        /*  (this is not needed now)
        --------- gravity changed back to 5 using gravityStore witch stored our gravity 5 --------------------
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        */
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        myndavel.isFollowing = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

    }
}
