using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
   public enum Season { NONE, SPRING, SUMMER, AUTUMN, WINTER };
   public enum Weather { NONE, SUNNY, HOTSUN, RAIN, SNOW };

   public Season currentSeason;
   public Weather currentWeather;

   [Header ("Time Settings")]
    public float seasonTime; //This is the actual seasonTime
    public float springTime; // Spring
    public float summerTime; // Summer
    public float autumnTime; // Autumn
    public float winterTime; // Winter

    [Header ("Light Settings")]
    public Light sunLight;
    private float defaultLightIntensity;
    public float summerLightIntensity;
    public float autumnLightIntensity;
    public float winterLightIntensity;
    private Color defaultLightColor;
    public Color summerColor;
    public Color autumnColor;
    public Color winterColor;

    

    public int currentYear;

    private void Start()
    {
        this.currentSeason = Season.SPRING;
        this.currentWeather = Weather.SUNNY;
        this.currentYear = 1;

        this.seasonTime = this.springTime;

        this.defaultLightColor = this.sunLight.color;
        this.defaultLightIntensity = this.sunLight.intensity;
    }

    public void ChangeSeason (Season seasonType)
    {
        if (seasonType != this.currentSeason)
        {
            switch (seasonType)
            {
                case Season.SPRING:
                    currentSeason = Season.SPRING;
                    break;
                case Season.SUMMER:
                    currentSeason = Season.SUMMER;
                    break;
                case Season.AUTUMN:
                    currentSeason = Season.AUTUMN;
                    break;
                case Season.WINTER:
                    currentSeason = Season.WINTER;
                    break;
            }
        }
    }

    public void ChangeWeather (Weather weatherType)
    {
        if (weatherType != this.currentWeather)
        {
            switch (weatherType)
            {
                case Weather.SUNNY:
                    currentWeather = Weather.SUNNY;
                    break;
                case Weather.HOTSUN:
                    currentWeather = Weather.HOTSUN;
                    break;
                case Weather.RAIN:
                    currentWeather = Weather.RAIN;
                    break;
                case Weather.SNOW:
                    currentWeather = Weather.SNOW;
                    break;
            }
        }
    }

    private void Update()
    {
        this.seasonTime -= Time.deltaTime;

        if (this.currentSeason == Season.SPRING)
        {
            ChangeWeather (Weather.SUNNY);

            LerpSunIntensity (this.sunLight, defaultLightIntensity);
            LerpLightColor (this.sunLight, defaultLightColor);
            
            if (this.seasonTime <= 0f)
            {
                ChangeSeason (Season.SUMMER);
                this.seasonTime =  this.summerTime;
            }
        }

        if (this.currentSeason == Season.SUMMER)
        {
            ChangeWeather (Weather.HOTSUN);

            LerpSunIntensity (this.sunLight, summerLightIntensity);
            LerpLightColor (this.sunLight, summerColor);

            
            if (this.seasonTime <= 0f)
            {
                ChangeSeason (Season.AUTUMN);
                this.seasonTime =  this.autumnTime;
            }
        }

        if (this.currentSeason == Season.AUTUMN)
        {
            ChangeWeather (Weather.RAIN);

            LerpSunIntensity (this.sunLight, autumnLightIntensity);
            LerpLightColor (this.sunLight, autumnColor);

            
            if (this.seasonTime <= 0f)
            {
                ChangeSeason (Season.WINTER);
                this.seasonTime =  this.winterTime;
            }
        }

        if (this.currentSeason == Season.WINTER)
        {
            ChangeWeather (Weather.SNOW);

            LerpSunIntensity (this.sunLight, winterLightIntensity);
            LerpLightColor (this.sunLight, winterColor);

            
            if (this.seasonTime <= 0f)
            {
                this.currentYear++;
                ChangeSeason (Season.SPRING);
                this.seasonTime =  this.springTime;
            }
        }
    }

    private void LerpLightColor (Light light, Color c)
    {
        light.color = Color.Lerp (light.color, c, 0.2f * Time.deltaTime);
    }

    private void LerpSunIntensity (Light light, float intensity)
    {
        light.intensity = Mathf.Lerp (light.intensity, intensity, 0.2f * Time.deltaTime);
    }
    
}
