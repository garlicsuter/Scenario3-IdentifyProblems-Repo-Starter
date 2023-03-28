using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountCircles : MonoBehaviour
{
    // Portions written using ChatGPT prompt:
    // "write a unity c sharp script that when a UI button is pressed, count the numbe
    // of circle game objects that are colliding with scratches game objects, then coun
    // the number of circle game objects that are not touching scratches game objects.
    public GameObject[] circleObjects;
    public GameObject[] scratchObjects;
    public TextMeshProUGUI circleCorrectText;
    public TextMeshProUGUI nonScratchedCountText;
    //public TextMeshProUGUI missedCountText;

    //private int missedCount;
    private int circleCount;
    private int nonScratchedCount;
    private int circleCorrect;

    public void OnButtonPress()
    {
        circleObjects = GameObject.FindGameObjectsWithTag("circleStay");
        circleCount = circleObjects.Length;
        Debug.Log("circleCount: " + circleCount);
        nonScratchedCount = 0;
        foreach (GameObject circle in circleObjects)
        {
            bool isTouchingScratch = false;
            foreach (GameObject scratch in scratchObjects)
            {
                if (circle.GetComponent<Collider>().bounds.Intersects(scratch.GetComponent<Collider>().bounds))
                {
                    isTouchingScratch = true;
                    Debug.Log("THEY COLLIDED");
                    break;
                    
                }
                //else
                //{
                //    missedCount++;
                //    break;
                //}
            }

            if (isTouchingScratch)
            {
                circleCorrect++;
                Debug.Log("circleCorrect++ " + circleCorrect);
            }
            else
            {
                nonScratchedCount++;
                Debug.Log("nonScratchedCount: " + nonScratchedCount);
            }
            Debug.Log("circleCorrect: " + circleCorrect + " nonScratchCount: " + nonScratchedCount);
        }

        circleCorrectText.text = circleCorrect.ToString();
        nonScratchedCountText.text = nonScratchedCount.ToString();
        //missedCountText.text = missedCount.ToString();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
