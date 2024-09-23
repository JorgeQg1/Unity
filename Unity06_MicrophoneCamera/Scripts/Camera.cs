using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour {
    
    public GameObject television;
    
    private WebCamTexture webcamTexture;
    private AudioSource audioRecord;

    private List<Texture2D> record = new List<Texture2D>();
    private bool alreadyPlayed = false;
    private int framesCounter = 0;

    void Start() {
        webcamTexture = new WebCamTexture();
        audioRecord = GetComponent<AudioSource>();
        Debug.Log("DeviceName: " + webcamTexture.deviceName);
    }

    void Update() {
        if (webcamTexture.isPlaying) {
            Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
            texture.SetPixels(webcamTexture.GetPixels());
            texture.Apply(texture);
            FlipTextureVertically(texture);
            record.Add(texture);

            if (Input.GetKey(KeyCode.S)) {
                webcamTexture.Stop();
                Microphone.End(null);
                alreadyPlayed = true;
                audioRecord.Play();
            }
        } else {
            if (alreadyPlayed) {
                if (framesCounter + 1 < record.Count) {
                    framesCounter++;
                } else {
                    framesCounter = 0;
                }
                television.GetComponent<Renderer>().materials[1].mainTexture = record[framesCounter];
            } else {
                webcamTexture.Play();
                audioRecord.clip = Microphone.Start(null, true, 100, 44100);
            }
        }
    }

    public void FlipTextureVertically(Texture2D original) {
        var originalPixels = original.GetPixels();

        var newPixels = new Color[originalPixels.Length];

        var width = original.width;
        var rows = original.height;

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < rows; y++)
            {
                newPixels[x + y * width] = originalPixels[x + (rows - y -1) * width];
            }
        }

        original.SetPixels(newPixels);
        original.Apply();
    }
}
