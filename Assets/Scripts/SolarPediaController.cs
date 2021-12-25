using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolarPediaController : MonoBehaviour
{
    //[SerializeField] GameObject indexPrefabs;
    [SerializeField] TextMeshProUGUI _entryTitle;
    [SerializeField] TextMeshProUGUI _content;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] Image _image;
    [SerializeField] GameObject _contentGO;
    [SerializeField] GameObject _indexGO;
    int state;
    bool changed;
    [SerializeField]
    List<Sprite> _images;
    bool showing;
    void Start()
    {
        SolarPedia slrpd = new SolarPedia();
        SetValue(0);
    }
    public void Back()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.Back);
        if (showing)
        {
            showing = false;
            _contentGO.SetActive(false);
            _indexGO.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<PauseCanvasController>().Continue();
        }
    }
    public void ShowContent()
    {
        _contentGO.SetActive(true);
        _indexGO.SetActive(false);
        showing = true;
    }

    void Update()
    {
        if(state == 2)
        {
            if (scrollbar.value > 0.5f)
            {
                _image.sprite = _images[2];
                _image.overrideSprite = _images[2];
            }
            else
            {
                _image.sprite = _images[5];
                _image.overrideSprite = _images[5];
            }
            
        }
    }

    public void SetValue(int newValue)
    {
        return;
        state = newValue;
        switch (newValue)
        {
            case 0:
                _entryTitle.text = "Layer and Composition";
                _content.text = "The atmosphere of the sun is composed of several layers, mainly the photosphere, the chromosphere and the corona. It's in these outer layers that the sun's energy, which has bubbled up from the sun's interior layers, is detected as sunlight.";
                break;

            case 1:
                _entryTitle.text = "Photosphere";
                _content.text = "The photosphere is the deepest layer of the Sun that we can observe directly. It reaches from the surface visible at the center of the solar disk to about 250 miles (400 km) above that. The temperature in the photosphere varies between about 6500 K at the bottom and 4000 K at the top (11,000 and 6700 degrees F, 6200 and 3700 degrees C). This layer is where the sun's energy is released as light. Because of the distance from the sun to Earth, light reaches our planet in about eight minutes. Most of the photosphere is covered by granulation. It is marked by bright, bubbling granules of plasma and darker, cooler sunspots, which emerge when the sun's magnetic field breaks through the surface. Sunspots appear to move across the sun's disk. Observing this motion led astronomers to realize that the sun rotates on its axis. Since the sun is a ball of gas with no solid form, different regions rotate at different rates. The sun's equatorial regions rotate in about 24 days, while the polar regions take more than 30 days to make a complete rotation. The photosphere is also the source of solar flares: tongues of fire that extend hundreds of thousands of miles above the sun's surface. Solar flares produce bursts of X-rays, ultraviolet radiation, electromagnetic radiation and radio waves.";
                break;

            case 2:
                _entryTitle.text = "Chromosphere";
                _content.text = "The chromosphere is a layer in the Sun between about 250 miles (400 km) and 1300 miles (2100 km) above the solar surface (the photosphere). The temperature in the chromosphere varies between about 4000 K at the bottom and 8000 K at the top, so in this layer it actually gets hotter if you go further away from the Sun, unlike in the lower layers, where it gets hotter if you go closer to the center of the Sun.The chromosphere emits a reddish glow as super-heated hydrogen burns off. But the red rim can only be seen during a total solar eclipse, or with sophisticated telescopes. At other times, light from the chromosphere is usually too weak to be seen against the brighter photosphere. But rather than being just a homogenous shell of plasma, it resembles the troposphere of our own planet Earth with complex storms and other phenomena roiling its volume from minute to minute. The reason for this is that the magnetic fields formed at or below the surface of the photosphere are not confined to the solar surface, but extend through-out the chromosphere. Magnetic arcs, prominences and other carpets of magnetic activity repeatedly form and dissolve, releasing energy and stirring up the chromospheric plasma. Solar physicists call the chromosphere and the narrow region above it the solar ‘interface region’. It is a complex zone of plasma and magnetic field, which transmits matter and energy between the photosphere and the corona.";
                break;

            case 3:
                _entryTitle.text = "Transition Region";
                _content.text = "The transition region is a very narrow (60 miles / 100 km) layer between the chromosphere and the corona where the temperature rises abruptly from about 8000 to about 500,000 K (14,000 to 900,000 degrees F, 7700 to 500,000 degrees C).";
                break;
            case 4:
                _entryTitle.text = "The Corona";
                _content.text = "The corona is the outermost layer of the Sun, starting at about 1300 miles (2100 km) above the solar surface (the photosphere). The temperature in the corona is 500,000 K (900,000 degrees F, 500,000 degrees C) or more, up to a few million K. The corona cannot be seen with the naked eye except during a total solar eclipse, or with the use of a coronagraph. It appears as white streamers or plumes of ionized gas that flow outward into space.  The corona does not have an upper limit. As the gases cool, they become the solar wind. Why the corona is up to 300 times hotter than the photosphere, despite being farther from the solar core, has remained a long-term mystery. Recent research suggests that tiny explosions known as nanoflares may help push the temperature up by providing sporadic bursts reaching up to 18 million F (10 million C). Giant super-tornados may also play a role in heating the sun's outer layer. These solar twisters are a combination of hot flowing gas and tangled magnetic field lines, ultimately driven by nuclear reactions in the solar core.";
                break;
            
        }
        _image.sprite = _images[newValue];
        _image.overrideSprite= _images[newValue];
        StartCoroutine(wait());
    }
    public IEnumerator wait()
    {
        yield return 0;

        _content.rectTransform.anchoredPosition = new Vector2(0, 0);
    }   
}


[System.Serializable]
public class SolarPedia
{
    public List<SolarPediaIndex> indexes;
    public SolarPedia()
    {
        indexes = new List<SolarPediaIndex>();
        indexes.Add(new SolarPediaIndex());
        indexes.Add(new SolarPediaIndex());
        indexes.Add(new SolarPediaIndex());
        indexes.Add(new SolarPediaIndex());
        indexes.Add(new SolarPediaIndex());
    }
}

[System.Serializable]
public class SolarPediaIndex
{
    public List<SolarPediaContent> content;
    public string title;
    public SolarPediaIndex()
    {

        content = new List<SolarPediaContent>();
        content.Add(new SolarPediaContent(0, "Holi"));
        content.Add(new SolarPediaContent(1, "Holi2"));
        content.Add(new SolarPediaContent(2, "Holi3"));
        content.Add(new SolarPediaContent(3, "Holi4"));
        content.Add(new SolarPediaContent(4, "Holi5"));
    }
}

[System.Serializable]
public class SolarPediaContent
{
    public int _type;
    public string _content;

    public SolarPediaContent(int type, string content)
    {
        _type = type;
        _content = content;
    }

}
