using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : FirstPersonController
{
    public Text message;
    public int numberOfPages = 8;

    public void PickUpPage() {
        numberOfPages--;
        message.text = "Pages remaining: " + numberOfPages;

        if (numberOfPages <= 0) {
            message.text = "You escape the slender!";
            Invoke ("Reset", 4f);
        }
    }

    public void Captured() {
        message.text = "Caught!";
        Invoke ("Reset", 4f);
    }

    void Reset() {
        UnityEngine.SceneManagement.SceneManager.LoadScene (0);
    }

    public int GetNumberOfPages() {
        return numberOfPages;
    }

    // Use this for initialization
    private void Start()
    {
        base.Start();
        message.text = "Pages remaining: " + numberOfPages;
    }
} 
