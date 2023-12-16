using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuggingFace.API.Examples; // example namespace
using System.Text.RegularExpressions;

public class Spider : MonoBehaviour
{
    // ExamPlayerController examPlayerController;
    GameObject[] spiders;
    public float spiderSpeed = 10.0f;
    // bool moveSpiders = false;
    bool spidersLeft = false;
    bool spidersUp = false;
    SpeechRecognitionExample speechRecognitionExample;
    // Start is called before the first frame update
    void Start()
    {
        // examPlayerController = GameObject.Find("Player").GetComponent<ExamPlayerController>();
        speechRecognitionExample = GameObject.Find("SpeechRecognitionExampleUI").GetComponent<SpeechRecognitionExample>();
        speechRecognitionExample.OnResponse += ManageSpiders;
        // examPlayerController.OnReachChaise += MakeSpidersMove;

    }

    // Update is called once per frame
    void Update()
    {
        // if (moveSpiders) {
        //     SpidersChase();
        // }
        if (spidersLeft) {
            SpidersLeft();
        }
        if (spidersUp) {
            SpidersUp();
        }
    }

    void ManageSpiders(string response) {
        Debug.Log(response);
        bool containsYes = Regex.IsMatch(response, @"yes", RegexOptions.IgnoreCase);
        bool containsNo = Regex.IsMatch(response, @"no", RegexOptions.IgnoreCase);
        if (containsYes) {
            Debug.Log("yes, moving left");
            spidersLeft = true;
        }
        if (containsNo) {
            Debug.Log("no, moving up");
            spidersUp = true;
        }
    }
    // void MakeSpidersMove() {
    //     moveSpiders = true;
    // }

    // void SpidersChase() {
    //     spiders = GameObject.FindGameObjectsWithTag("Spider");
    //     GameObject player = GameObject.Find("Player");
    //     foreach(GameObject spider in spiders) {
    //         spider.transform.Translate(Vector3.Normalize(player.transform.position - spider.transform.position)
    //          * spiderSpeed * Time.deltaTime);
    //     }

    // }
    void SpidersUp() {
        spiders = GameObject.FindGameObjectsWithTag("Spider");
        foreach(GameObject spider in spiders) {
            spider.transform.position = new Vector3(spider.transform.position.x, spider.transform.position.y + 0.2f, spider.transform.position.z);
        }

    }

    void SpidersLeft() {
        spiders = GameObject.FindGameObjectsWithTag("Spider");
        foreach(GameObject spider in spiders) {
            spider.transform.position = new Vector3(spider.transform.position.x - 0.2f, spider.transform.position.y, spider.transform.position.z);
        }

    }

}
