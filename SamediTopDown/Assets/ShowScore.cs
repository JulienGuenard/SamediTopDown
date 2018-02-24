﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShowScore : NetworkBehaviour
{
    [SyncVar]
    public int J1Score = 0;
    [SyncVar]
    public int J2Score = 0;
    public int localId;

    public override void OnStartClient()
    {
        Debug.Log("aa");
        if (isServer)
            localId = 0;
        else
            localId = 1;
    }

    public void AddScore()
    {
        Debug.Log(localId);
        if(localId == 1)
        {
            J1Score += 1;
        }
        else if (localId == 0)
            J2Score += 1;
    }

    private void Update()
    {
        GetComponent<Text>().text = J1Score + " : " + J2Score;
    }
}
