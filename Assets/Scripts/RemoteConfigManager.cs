using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class RemoteConfigManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int scale;

    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"로그인 완료: {AuthenticationService.Instance.PlayerId}");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    //유저의 속성, 앱 속성 파라메터 정의
    private struct userAttr { };
    private struct appAttr { };

    // Remote Config 데이터 로드
    private async Task GetRemoteConfigDataAsync()
    {

    }
}
