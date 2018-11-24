using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLanternLight : MonoBehaviour {

    public GameObject[] redPointLights;
    public GameObject pulseParticle;
    public Material lanternMat;
    public Material ringMat;

    private Color finalColor;
    private bool lightUp = true;
    private float matIntensity = 1f;

	
	void Update () {
		if (lightUp) {
            // Light
            for (int i = 0 ; i < redPointLights.Length ; i++) {
                if (redPointLights[i].GetComponent<Light>().intensity > 3.5f) {
                    redPointLights[i].GetComponent<Light>().intensity += 0.005f;
                }
                else {
                    redPointLights[i].GetComponent<Light>().intensity += 0.05f;
                }
            }
            if (redPointLights[0].GetComponent<Light>().intensity > 4.5f) {
                lightUp = false;
            }

            // Material
            if (matIntensity < 1.5f) {
                matIntensity += 0.014f;
            }
            finalColor = lanternMat.color * matIntensity;

            // Particle
            pulseParticle.SetActive(true);
        }
        else if (!lightUp) {
            for (int i = 0 ; i < redPointLights.Length ; i++) {
                if (redPointLights[i].GetComponent<Light>().intensity < 1f) {
                    redPointLights[i].GetComponent<Light>().intensity -= 0.005f;
                }
                else {
                    redPointLights[i].GetComponent<Light>().intensity -= 0.05f;
                }
            }
            if (redPointLights[0].GetComponent<Light>().intensity < 0.2f) {
                lightUp = true;
            }

            // Material
            if (matIntensity > 0.2f) {
                matIntensity -= 0.025f;
            }
            finalColor = lanternMat.color * matIntensity;

            // Particle
            pulseParticle.SetActive(false);
        }

        lanternMat.SetColor("_EmissionColor", finalColor);
        ringMat.SetColor("_EmissionColor", finalColor);
    }

}