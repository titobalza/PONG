using UnityEngine;
using System.Collections;

public class GoalSound : MonoBehaviour {

    // Una variable para guardar el clip de audio
    public AudioClip goalClip;

    // Use this for initialization
    void Start () {
        // Obtener el componente de AudioSource
        AudioSource audio = GetComponent<AudioSource>();
        // Asignar el clip de audio
        audio.clip = goalClip;
        // Ajustar el volumen y el tono si quieres
        audio.volume = 0.5f;
        audio.pitch = 1.2f;
    }
}
