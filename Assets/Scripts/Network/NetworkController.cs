using UnityEngine;
using System.Collections;

public class NetworkController : MonoBehaviour {

    private string gameVersion = "0.1";
    public GameObject player;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(gameVersion);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnJoinedLobby()
    {
        print("**************************************************************");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        print("** create room **");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        print("On vient de rejoindre une room");
        PhotonNetwork.Instantiate("Player", player.transform.position, Quaternion.identity, 0);
    }
}
