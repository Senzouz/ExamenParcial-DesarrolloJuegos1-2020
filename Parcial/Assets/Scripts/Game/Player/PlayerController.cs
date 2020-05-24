using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    
    [SerializeField] GameObject uno;
    [SerializeField] GameObject dos;
    [SerializeField] GameObject tres;
    [SerializeField] GameObject cuarto;
    [SerializeField] GameObject quinto;
    private GameObject monsterGO;

    private int score = 0;

    [SerializeField] Text scoreText;

    private int lives = 4;

    [SerializeField] Text lifeText;

    void Awake()
    {
        if(instance == null)
            instance = this;
        string monster = PlayerPrefs.GetString("player");
        Vector2 position = transform.position;

        if (monster == "1")
        {
            monsterGO = uno;
        }
        if (monster == "2")
        {
            monsterGO = dos;
        }
        if (monster == "3")
        {
            monsterGO = tres;
        }
        if (monster == "4")
        {
            monsterGO = cuarto;
        }
        if (monster == "5")
        {
            monsterGO = quinto;
        }
        Instantiate(monsterGO, position, Quaternion.identity);
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        lifeText.text = "HP: " + lives;
        if(lives <= 0)
        {
            YouLose();
        }
    }

    public void scoreUP()
    {
        score += 10;
    }

    public void reduceLife()
    {
        lives -= 1;
    }

    void YouLose()
    {
        SceneManager.LoadScene("GameOver");
    }
}
