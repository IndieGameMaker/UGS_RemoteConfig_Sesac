using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;

public class RemoteConfigManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int scale;

    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += async () =>
        {
            Debug.Log($"로그인 완료: {AuthenticationService.Instance.PlayerId}");

            // Loading Remote Config Data ...
            await GetRemoteConfigDataAsync();
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        // Remote Config 콜백 연결
        RemoteConfigService.Instance.FetchCompleted += (response) =>
        {
            Debug.Log(JsonConvert.SerializeObject(response));
            moveSpeed = RemoteConfigService.Instance.appConfig.GetFloat("move_speed");
            rotateSpeed = RemoteConfigService.Instance.appConfig.GetFloat("rotate_speed");
            scale = RemoteConfigService.Instance.appConfig.GetInt("scale");
        };
    }

    //유저의 속성, 앱 속성 파라메터 정의
    private struct userAttr { };
    private struct appAttr { };

    // Remote Config 데이터 로드
    private async Task GetRemoteConfigDataAsync()
    {
        await RemoteConfigService.Instance.FetchConfigsAsync(new userAttr(), new appAttr());
    }
}
