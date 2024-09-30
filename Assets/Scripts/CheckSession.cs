using Unity.Services.Authentication;
using UnityEngine;

public class CheckSession : MonoBehaviour
{
    void Start()
    {
        var playerId = AuthenticationService.Instance.PlayerId;
        Debug.Log(playerId);
    }


}
