using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuggingFace.API.Examples; // example namespace
using System.Text.RegularExpressions;

public class Spider : MonoBehaviour
{
    // ExamPlayerController examPlayerController;
    GameObject[] spiders;
    GameObject selectedSpider;
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
        spiders = GameObject.FindGameObjectsWithTag("Spider");
        speechRecognitionExample.OnResponse += ManageSpiders;
        selectedSpider = spiders[0];
        // examPlayerController.OnReachChaise += MakeSpidersMove;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Spider 1 selected");
            selectedSpider = spiders[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("Spider 2 selected");
            selectedSpider = spiders[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("Spider 3 selected");
            selectedSpider = spiders[2];
        }
        if (spidersLeft) {
            SpidersLeft();
            spidersLeft = false;
        }
        if (spidersUp) {
            SpidersUp();
            spidersUp = false;
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
        selectedSpider.transform.position = new Vector3(selectedSpider.transform.position.x, selectedSpider.transform.position.y + 0.3f, selectedSpider.transform.position.z);

    }

    void SpidersLeft() {
        spiders = GameObject.FindGameObjectsWithTag("Spider");
        selectedSpider.transform.position = new Vector3(selectedSpider.transform.position.x - 0.3f, selectedSpider.transform.position.y, selectedSpider.transform.position.z);
    }

}
