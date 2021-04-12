using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float timeInterval = 2;

    [SerializeField] private BoxCollider Background;

    public List<GameObject> targets;

    private Vector3 origin;
    private float distance;
    private readonly int N = 4;
    private readonly float yConstrain = 4f;
    private readonly float zConstrain = 4f;
    private int prevRandom;

    IEnumerator SpawnObject()
    {
        while (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            yield return new WaitForSeconds(timeInterval);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index], RandomPosition(), targets[index].transform.rotation);
        }
    }

    private void Awake()
    {
        this.RegisterListener(GameEvent.OnClickLevelButton, (param) => OnClickLevelButtonHandler(param));
    }

    void Start()
    {
        Background = GameObject.FindGameObjectWithTag("Background").GetComponent<BoxCollider>();
        origin = Background.gameObject.transform.position - new Vector3(3 * Background.size.x / 8, yConstrain, zConstrain);
        distance = Background.size.x / 4;
        StartCoroutine(SpawnObject());
     }

    private Vector3 RandomPosition()
    {
        int temp = Random.Range(0, N);
        while (temp == prevRandom)
        {
            temp = Random.Range(0, N);
        }

        prevRandom = temp;

        return origin + new Vector3(prevRandom * distance, 0, 0);
    }

    private void OnClickLevelButtonHandler(object param)
    {
        timeInterval /= ((int)param + 1);
    }
}
