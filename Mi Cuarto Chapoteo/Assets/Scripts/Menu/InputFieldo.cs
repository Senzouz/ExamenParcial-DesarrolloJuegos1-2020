using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldo : MonoBehaviour
{

    [SerializeField] Button btnPrint;
    [SerializeField] Button btnUsers;
    [SerializeField] Button btnPlay;
    [SerializeField] InputField ipField;
    int i = 0;

    void Start()
    {
        FirebaseDB.init();
        btnPrint.onClick.AddListener(() => xprint());
        btnUsers.onClick.AddListener(() => goUsers());
        btnPlay.onClick.AddListener(() => goPlay());
        if (!PlayerPrefs.HasKey("userID"))
            PlayerPrefs.SetInt("userID", i);
        else i = PlayerPrefs.GetInt("userID");

    }

    void xprint()
    {
        User newUser = new User(ipField.text, i.ToString());
        string json = JsonUtility.ToJson(newUser);
        print(ipField.text);
        print(json);
        FirebaseDB.reference.Child("users").Child(newUser.id).SetRawJsonValueAsync(json);
        i++;
        PlayerPrefs.SetInt("userID", i);
    }

    void goUsers()
    {
        SceneManager.LoadScene(2);
    }

    void goPlay()
    {
        SceneManager.LoadScene(1);
    }

}
