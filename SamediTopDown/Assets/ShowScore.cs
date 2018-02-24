using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShowScore : NetworkBehaviour
{
  [SyncVar(hook = "UpdateScoreJ1")]
    public int J1Score = 0;
  [SyncVar(hook = "UpdateScoreJ2")]
    public int J2Score = 0;
    public int localId;

    public override void OnStartClient()
    {
       
        if (isServer)
            localId = 0;
        else
            localId = 1;
    }

    public void AddScore()
    {
      Debug.Log(localId.ToString());
        if(localId == 1)
        {
            J1Score += 1;
        }
        else if (localId == 0)
            J2Score += 1;

    }

    void UpdateScoreJ1 (int J1Score)
    {
      GetComponent<Text>().text = J1Score + " : " + J2Score;
    }
  void UpdateScoreJ2 (int J2Score)
    {
      GetComponent<Text>().text = J1Score + " : " + J2Score;
    }

}
