using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timmer : MonoBehaviour
{
    public TextMeshProUGUI Tempo;
    public float Tiempo = 0.0f;
    public bool DebeAumentar = true;

    void Update()
    {
        // Se comprueba si debe aumentar el valor primero...
        DebeAumentar = (Tiempo <= 0.0f) ? true : false;

        // Luego se efectua el aumento.
        if (DebeAumentar) Tiempo += Time.deltaTime;
        else Tiempo -= Time.deltaTime;

        // Se asigna el color dependiendo del tiempo restante.
        Tempo.color = (Tiempo <= 10.0f) ? Color.red : Color.green;

        Tempo.text = "Tiempo:" + " " + Tiempo.ToString("f0");

        if (Tiempo <= 0.0f)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}