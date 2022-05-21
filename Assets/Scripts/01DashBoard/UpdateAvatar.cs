using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class UpdateAvatar : MonoBehaviour
{
    [SerializeField] Text _avatarAtama;

    private void Start()
    {
        _avatarAtama.enabled = false;
    }
    public void UpdateAvatarOnClick()
    {
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {
            ImageUrl = _avatarAtama.text
        },
        Success =>
        {
            SceneManager.LoadScene(1);
            Debug.Log("Avatar Güncellendi");
        },
        Error =>
        {
            Debug.Log("Avatar Güncellenirken hata oluþtu");
        });
    }



    public void Avatar1OnClick()
    {
        _avatarAtama.text = "https://www.gravatar.com/userimage/221185370/30dddf5e0c214af8ca6f4d0d4e86128f?size=120";
    }

    public void Avatar2OnClick()
    {
        _avatarAtama.text = "https://www.gravatar.com/userimage/221185370/db0c490d8d906c792840f182fba9b0d7?size=120";
    }
}
