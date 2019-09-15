using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text CurTime;
    public Text EarthMass;
    public Text EarthMassNumber;
    public Text TimeElapsed;
    public Text MoonMass;
    public Text BombardmentLevel;
    public Text CoolTime;
    public Text FailText;

    public EarthStatSheet ESS;
    public EarthConsume ec;
    public MoonStatSheet MSS;
    public AsteroidSpawner asts;

    public float earthMass;
    public float startSpawnProb = 0.01f;
    public float spawnProb;
    public float spawnIncr = 0.0001f;
    public float delta = Mathf.Pow(10f, -5f);
    float initEarthScale = 0f;
    float inittime = 0f;
    float runtime = 0f;
    float winningtime = 0f;
    float winStartTime = 0f;
    bool winstarted = false;
	// Use this for initialization
    void Start () {
        initEarthScale = ESS.EarthMass;
        earthMass = ESS.EarthMass;
        inittime = Time.time;
        spawnProb = startSpawnProb;
        runtime = inittime;
        FailText.canvasRenderer.SetAlpha(0f);
    }
	
	// Update is called once per frame
	void Update () {
        Bombardment();
        runtime = Time.time - inittime;
        if(Random.Range(0, 1f) < spawnProb){
            GameObject go = asts.spawn(Random.Range(0, 3));
            if(go != null){
                spawnProb += spawnIncr;
            }
        }
        if ((-earthMass + ESS.EarthMass) > delta)
        {
            earthMass = ESS.EarthMass;
        }
		if (earthMass > 1f && earthMass < 2f)
		{
            if (!winstarted){
                winStartTime = Time.time;
                winstarted = !winstarted;
            }
			winningtime = Time.time - winStartTime;
            if (winningtime > 50f){
                FailText.text = "YOU WON!";
                FailText.canvasRenderer.SetAlpha(1f);
                ec.Lock();
                spawnProb = -1f;
            }
			CoolTime.text = (Mathf.Round(winningtime * 100f) / 100f).ToString();
		}
        if (earthMass > 2f){
            FailText.text = "YOU LOST!";
            FailText.canvasRenderer.SetAlpha(1f);
            ec.Lock();
            spawnProb = 1f;
        }
        TimeElapsed.text = (Mathf.Round(runtime * 100f) / 100f).ToString();
        EarthMassNumber.text = (Mathf.Round(earthMass * 1000f) / 1000f).ToString();
        if(Input.GetKeyDown(KeyCode.R)){
            Restart();
			ESS.SetMass(initEarthScale);
			earthMass = ESS.EarthMass;
            Restart();
        }
	}

    void Restart(){
        ESS.SetMass(initEarthScale);
		earthMass = ESS.EarthMass;
		inittime = Time.time;
		spawnProb = startSpawnProb;
		runtime = inittime;
		FailText.canvasRenderer.SetAlpha(0f);
        ec.Unlock();
        CoolTime.text = "_";
        EarthMassNumber.text = (Mathf.Round(earthMass * 1000f) / 1000f).ToString();
        asts.despawnAll();
    }

    void Bombardment(){
        if(spawnProb < 0.1){
            BombardmentLevel.text = "Everything's Normal";
            return;
        }
		if (spawnProb < 0.3)
		{
			BombardmentLevel.text = "Houston...  My God...";
			return;
		}
		if (spawnProb < 0.5)
		{
			BombardmentLevel.text = "Evolutionary Restart";
			return;
		}
		if (spawnProb < 0.7)
		{
			BombardmentLevel.text = "Barely Habitable";
			return;
		}
		BombardmentLevel.text = "Late Heavy Bombardment Round 2";
		return;
    }
}
