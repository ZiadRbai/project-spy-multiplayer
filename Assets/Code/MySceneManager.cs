using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public void ChangeRoomScene(string nextScene)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonView photonView = GameObject.FindGameObjectWithTag("PhotonView").GetComponent<PhotonView>();
            photonView.RPC("ChangeScene", RpcTarget.All, nextScene);
        }
    }

    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
   
    public void SpyWin(string sceneName)
    {

        PhotonView photonView = GameObject.FindGameObjectWithTag("PhotonView").GetComponent<PhotonView>();
        photonView.RPC("ChangeScene", RpcTarget.All, sceneName);

    }
}
