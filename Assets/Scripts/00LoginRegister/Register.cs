using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{

    #region Preference Class

    private RegisterBase _registerBase = new RegisterBase();
    private GetDefaultAvatarImage _getDefaultAvatarImage = new GetDefaultAvatarImage();
    private InputController _inputController = new InputController();

    #endregion Preference Class

    [Header("Default Avatar URL")]
    [SerializeField] private string _avatarUrl;

    [SerializeField] private InputField _username, _email, _password, _repeatPassword;
    [SerializeField] private GameObject _aSencPanel;
    [SerializeField] private Text _asencText;
    [SerializeField] private Button _registerButton;


    private bool _isUpdateAvatar , _guestLogin;

    public void RegisterOnClick()
    {
        StartCoroutine(ASencRegister());
    }

    public void RegisterInputController()
    {
        _inputController.RegisterInputControl(_email, _password, _repeatPassword, _username, _registerButton);
    }
    public void GuestOnClick()
    {
        StartCoroutine(AsyncGuestControl());
    }

    private IEnumerator ASencRegister()
    {
        _aSencPanel.SetActive(true);
        _registerBase.RegisterEmail(_username.text, _email.text, _password.text);
        yield return new WaitUntil(() => _registerBase.RegisterBase_Async);
        _asencText.text = "Default Avatar Yükleniyor";
        _getDefaultAvatarImage.GetDefaultAvatar(_avatarUrl);
        yield return new WaitUntil(() => _getDefaultAvatarImage._isAvatarUploaded);
        SceneManager.LoadScene(1);
    }
    IEnumerator AsyncGuestControl()
    {
        _aSencPanel.SetActive(true);
        _asencText.text = "Giriþ Baþarýlý Lütfen Bekleyiniz.";
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() { CreateAccount = _guestLogin, AndroidDeviceId = SystemInfo.deviceUniqueIdentifier },
              Result =>
              {
                  Debug.Log("Giriþ Baþarýlý..");

              },

              Error => { Debug.Log("Giriþ Baþarýsýz.."); }); ;

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
