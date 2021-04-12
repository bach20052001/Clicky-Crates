using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject missingText;


    private int score;
    private int missing;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.gameObject.SetActive(true);
        gameOver.SetActive(false);

        this.RegisterListener(GameEvent.OnHitProp, (param) => OnHitPropHandler());
        this.RegisterListener(GameEvent.OnHitBomb, (param) => OnHitBombHandler());
        this.RegisterListener(GameEvent.OnPropFallingOutScreen, (param) => OnPropFallingOutScreenHandler());
    }

    private void OnPropFallingOutScreenHandler()
    {
        if (missing < 5)
        {
            missing++;
        }
        missingText.GetComponent<TextMeshProUGUI>().text = missing.ToString();

        if (missing == 5)
        {
            gameOver.SetActive(true);
            GameManager.Instance.TransitionState(GameBaseState.GAMEOVER);
        }
    }

    private void OnHitBombHandler()
    {
        gameOver.SetActive(true);
    }

    private void OnHitPropHandler()
    {
        score += 10;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
