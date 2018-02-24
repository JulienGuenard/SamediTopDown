using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public Slider healthBar;
    public ShowScore UIScore;

    private NetworkStartPosition[] spawnPoints;

  void Start ()
  {
  if (isLocalPlayer)
      spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        UIScore = GameObject.FindObjectOfType<ShowScore>();
  }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 100;
        RpcRespawn();
            Debug.Log("Dead!");

              UIScore.AddScore(GetComponent<PlayerController>().playerID);

            
        }

    }

    void OnChangeHealth(int health)
    {
        Debug.Log("change");
        healthBar.value = health;
    }

    [ClientRpc]
    void RpcRespawn ()
    {
      Vector3 spawnPoint = Vector3.zero;
      if (spawnPoints != null && spawnPoints.Length > 0)
{
    spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
}
    }

}