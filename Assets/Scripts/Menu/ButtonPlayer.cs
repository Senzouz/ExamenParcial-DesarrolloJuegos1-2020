using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlayer : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] string player;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => GoGame());
    }


    void GoGame()
        {
            PlayerPrefs.SetString("player", player);
            SceneManager.LoadScene("Game");
        }

}
