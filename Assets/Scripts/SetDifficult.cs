using UnityEngine;
using UnityEngine.UI;

public class SetDifficult : MonoBehaviour
{
    private GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        GetComponent<Button>().onClick.AddListener(SetUp);
    }

    private void SetTime(float time)
    {
        manager.SetInterval(time);
    }
    private void SetUp()
    {
        string level = gameObject.name;
        switch (level)
        {
            case "Easy":
                SetTime(1);
                break;
            case "Medium":
                SetTime(0.75f);
                break;
            case "Hard":
                SetTime(0.5f);
                break;
            default:
                break;
        }
        manager.StartGame();
    }
}
