using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject PipeObject;
    [SerializeField]
    float RandomHeight;

    private int _score;
    [SerializeField]
    Text ScoreText;

    [SerializeField]
    Text StartText;

    [SerializeField]
    AudioSource PointSound;

    void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        InvokeRepeating("CreatePipe", 0, 2);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 1;
            StartText.enabled = false;
        }
    }

    public void CreatePipe()
    {

        GameObject pipeInstatiated = Instantiate(PipeObject, transform.position, Quaternion.identity);

        float rndY = Random.Range(-RandomHeight, RandomHeight);
        Vector3 pos = this.transform.position;
        pos.y = rndY;

        pipeInstatiated.transform.position = pos;

    }

    public void StopPipe()
    {
        CancelInvoke("CreatePipe");
    }

    public void SetScore(int score)
    {
        _score += score;
        PointSound.Play();
    }

    void OnGUI()
    {
        ScoreText.text = _score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}

