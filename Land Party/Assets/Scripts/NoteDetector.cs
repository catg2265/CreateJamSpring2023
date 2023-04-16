using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteDetector : MonoBehaviour {
    public AudioClip audioClip;
    public int sampleSize = 1024;
    public float threshold = 0.1f;

    private AudioSource audioSource;
    private float[] samples;
    private List<float> notes = new List<float>();

    void Start() {
        audioSource = GetComponent<AudioSource>();
        samples = new float[sampleSize];
        audioSource.clip = audioClip;
        audioSource.Play();
    }
/*
    void Update() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        for (int i = 0; i < sampleSize; i++) {
            if (samples[i] > threshold) {
                float note = 440 * Mathf.Pow(2, i / 12.0f);
                notes.Add(note);
                Debug.Log("New Note Added!: " + note);
            }
        }
    }

    void OnGUI() {
        GUILayout.Label("Notes detected:");
        GUILayout.Label(notes.Count.ToString());
        //foreach (float note in notes) {
        //    GUILayout.Label(note.ToString());
        //}
    }
    */
}
