using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;

    //Smooth camera following
    private void FixedUpdate()
    {

        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;

    }
    public void GameOver()
    {
        int sco = score.playerScore();
        gameOver.Setup(sco);
    }

    public GameOverScreen gameOver;
    public ScoreManager score; 
}
