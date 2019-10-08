using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    public int score = 0;
    public int winningScore = 4;
    public Text scoreText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoreCube")
        {
            Debug.Log("thats a score collision");
            score++;
            ScoreText();
            Destroy(other.gameObject); 
        }

    }

    void ScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score > winningScore)
        {
            winText.text = "You Got Enough! ESC";
        }

    }

    // Update is called once per frame
    void Update()
    {
        float cancel = Input.GetAxis("Cancel");

        if (cancel > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
