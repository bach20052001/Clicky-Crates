using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficult : MonoBehaviour
{
    [SerializeField] private List<Button> levels = new List<Button>();

    private void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            int index = i;
            levels[i].onClick.AddListener(delegate { OnClickHandler(index);});
        }
    }

    private void OnClickHandler(int index)
    {
        switch (index)
        {
            case (int) Level.EASY:
                this.PostEvent(GameEvent.OnClickLevelButton, Level.EASY);
                break;
            case (int) Level.NORMAL:
                this.PostEvent(GameEvent.OnClickLevelButton, Level.NORMAL);
                break;
            case (int) Level.HARD:
                this.PostEvent(GameEvent.OnClickLevelButton, Level.HARD);
                break;
        }
        gameObject.SetActive(false);
    }
}
