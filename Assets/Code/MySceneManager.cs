using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public void ChangeRoomScene(string nextScene)
    {
        PhotonView photonView = GameObject.FindGameObjectWithTag("PhotonView").GetComponent<PhotonView>();
        photonView.RPC("ChangeScene", RpcTarget.All, nextScene);
    }

    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}