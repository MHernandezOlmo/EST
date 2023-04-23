using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SolarPediaController : MonoBehaviour
{
    //[SerializeField] GameObject indexPrefabs;
    [SerializeField] TextMeshProUGUI _entryTitle;
    [SerializeField] TextMeshProUGUI _entryCredits;
    [SerializeField] TextMeshProUGUI _content;
    [SerializeField] Image _image;
    [SerializeField] GameObject _contentGO;
    [SerializeField] GameObject _indexGO;
    [SerializeField] private GameObject[] _contentList;
    [SerializeField] private GameObject _solarPediaEntryTitle;
    [SerializeField] private GameObject _contentHolder;
    [SerializeField] private VerticalLayoutGroup _vlayout;
    [SerializeField] private ScrollRect _scroll;
    int state;
    bool changed;
    [SerializeField]
    List<Sprite> _images;
    bool showing;
    [SerializeField] private Canvas _canvas;
    List<List<string>> entries;
    List<string> entryTitles;
    List<List<string>> _credits;
    List<List<string>> _contents;
    [SerializeField] private Sprite _greenButton;
    [SerializeField] private Sprite _blueButton;
    public void ShowFinalContent(int entry, int subentry)
    {
        StartCoroutine(EntryRefresh(entry, subentry));   
        foreach(SolarpediaEntryTitle set in FindObjectsOfType<SolarpediaEntryTitle>())
        {
            if(set.SubEntryIndex == subentry)
            {
                set.GetComponent<Image>().sprite = _greenButton;
            }
            else
            {
                set.GetComponent<Image>().sprite = _blueButton;
            }
        }
    }
    public void ShowFastFinalContent(int entry, int subentry)
    {
        StartCoroutine(FastEntryRefresh(entry, subentry));
        foreach (SolarpediaEntryTitle set in FindObjectsOfType<SolarpediaEntryTitle>())
        {
            if (set.SubEntryIndex == subentry)
            {
                set.GetComponent<Image>().sprite = _greenButton;
            }
            else
            {
                set.GetComponent<Image>().sprite = _blueButton;
            }
        }
    }
    public string GetDirectoryName(int entry, int subentry)
    {
        string mainPath = Application.dataPath + "/Resources/SolarpediaSprites";
        string resourcesPath = "SolarpediaSprites/";
        DirectoryInfo dir = new DirectoryInfo(mainPath);
        DirectoryInfo[] info = dir.GetDirectories();
        string entryDirectoryName = "";
        foreach (DirectoryInfo f in info)
        {   
            if(int.Parse(f.Name.Split('_')[0]) == entry)
            {
                entryDirectoryName = f.Name;
            }
        }
        mainPath += "/" + entryDirectoryName;
        resourcesPath += entryDirectoryName+"/";
        DirectoryInfo subDir = new DirectoryInfo(mainPath);
        DirectoryInfo[] subInfo = subDir.GetDirectories();
        string subEntryDirectoryName = "";
        foreach (DirectoryInfo f in subInfo)
        {
            if (int.Parse(f.Name.Split('_')[0]) == subentry)
            {
                subEntryDirectoryName = f.Name;
            }
        }
        mainPath += subEntryDirectoryName;
        resourcesPath += subEntryDirectoryName;
        return resourcesPath;
        
    }
    IEnumerator FastEntryRefresh(int entry, int subentry)
    {
        Color transparentWhite = new Color(1, 1, 1, 0);
        _entryTitle.color = transparentWhite;
        _content.color = transparentWhite;
        _entryTitle.text = entryTitles[entry];
        _entryTitle.color = new Color(0, 0, 0, 0);
        _content.text = _contents[entry][subentry];

        string mainDirectory = GetDirectoryName(entry, subentry);


        //Sprite sprite = Resources.Load<Sprite>($"{mainDirectory}/img");
        //TextAsset mytxtData = (TextAsset)Resources.Load($"{mainDirectory}/credit");
        Sprite sprite = Resources.Load<Sprite>($"SolarpediaSprites/{entry}/{subentry}/img");
        TextAsset mytxtData = (TextAsset)Resources.Load($"SolarpediaSprites/{entry}/{subentry}/credit");
        string credits = "";
        if (mytxtData != null)
        {
            credits = mytxtData.text;
        }
        if(sprite != null)
        {
            _image.gameObject.SetActive(true);
            _image.sprite = sprite;
            _image.overrideSprite= sprite;

            float aspectRatio = _image.sprite.rect.width / _image.sprite.rect.height;
            Vector2 size = _image.rectTransform.sizeDelta;
            size.x = size.y * aspectRatio;
            _image.rectTransform.sizeDelta = size;

            if (!string.IsNullOrEmpty(credits))
            {
                _entryCredits.text = credits;
                _entryCredits.gameObject.SetActive(true);
            }
            else
            {
                _entryCredits.gameObject.SetActive(false);
            }
        }
        else
        {
            _image.gameObject.SetActive(false);
        }

        if (entry == 3)
        {
            _image.color = transparentWhite;
        }

        yield return null;
        _vlayout.enabled = false;
        _vlayout.enabled = true;
        yield return null;
        _scroll.normalizedPosition = new Vector2(0, 1);
        for (float i = 0; i < 0.25f; i += Time.unscaledDeltaTime)
        {
            _entryTitle.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _entryCredits.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _content.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _image.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            yield return null;
        }

        _image.color = Color.white;
        _content.color = Color.white;
        _entryTitle.color = Color.white;
        _entryCredits.color = Color.white;
        _content.color = Color.white;
    }
    IEnumerator EntryRefresh(int entry, int subentry)
    {
        Color transparentWhite = new Color(1, 1, 1, 0);

        for (float i = 0; i<0.25f; i += Time.unscaledDeltaTime)
        {
            //_entryTitle.color = Color.Lerp(Color.white, transparentWhite, i/0.25f);
            _entryCredits.color = Color.Lerp(Color.white, transparentWhite, i / 0.25f);
            _content.color = Color.Lerp(Color.white, transparentWhite, i/0.25f);
            _image.color = Color.Lerp(Color.white, transparentWhite, i / 0.25f);
            yield return null;
        }
        _image.color = transparentWhite;
        //_entryTitle.color = transparentWhite;
        _content.color = transparentWhite;
        //_entryTitle.text = entryTitles[entry];
        //_entryTitle.color = new Color(0, 0, 0, 0);
        _content.text = _contents[entry][subentry];
        _entryCredits.color = transparentWhite;

        string mainDirectory = GetDirectoryName(entry, subentry);

        Sprite sprite = Resources.Load<Sprite>($"SolarpediaSprites/{entry}/{subentry}/img");
        TextAsset mytxtData = (TextAsset)Resources.Load($"SolarpediaSprites/{entry}/{subentry}/credit");
        string credits = "";

        if (mytxtData != null)
        {
            credits = mytxtData.text;
            _entryCredits.text = credits;
            _entryCredits.gameObject.SetActive(true);
        }
        else
        {
            _entryCredits.gameObject.SetActive(false);
        }
        if (sprite != null)
        {
            float aspectRatio = sprite.rect.width / sprite.rect.height;
            Vector2 size = _image.rectTransform.sizeDelta;
            size.x = size.y * aspectRatio;
            _image.gameObject.SetActive(true);
            _image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
            _image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
            _image.sprite = sprite;
            _image.overrideSprite= sprite;
            float targetAP = 700 - (size.x / 2f);
            _entryCredits.rectTransform.anchoredPosition= new Vector2(targetAP, _entryCredits.rectTransform.anchoredPosition.y);
        }
        else
        {
            _image.gameObject.SetActive(false);
        }
        _image.sprite = sprite;
        
        yield return null;
        _vlayout.enabled = false;
        _vlayout.enabled = true;
        yield return null;
        _scroll.normalizedPosition = new Vector2(0, 1);
        
        for (float i = 0; i < 0.25f; i += Time.unscaledDeltaTime)
        {
            //_entryTitle.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _entryCredits.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _content.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);

            _image.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            yield return null;
        }

        _image.color = Color.white;

        //_entryTitle.color = Color.white;
        _entryCredits.color = Color.white;
        _content.color = Color.white;
        //_entryTitle.color = Color.white;
        _content.color = Color.white;
    }
    void Start()
    {
        SolarPedia slrpd = new SolarPedia();

        entryTitles = new List<string>();

        entryTitles.Add("Internal structure");
        entryTitles.Add("The solar atmosphere");
        entryTitles.Add("Solar magnetic fields");
        entryTitles.Add("The Sun in numbers");
        entryTitles.Add("Solar photosphere");
        entryTitles.Add("Solar chromosphere");
        entryTitles.Add("Corona");
        entryTitles.Add("Space weather");
        entryTitles.Add("Observatories");
        entryTitles.Add("Ground-based telescopes");
        entryTitles.Add("Space missions");
        entryTitles.Add("Telescope systems");
        entryTitles.Add("Optics");
        entryTitles.Add("Solar instruments");
        entryTitles.Add("Solar observations");


        entries = new List<List<string>>();
        entries.Add(new List<string>() { "Core", "Radiative zone", "Tachocline", "Convection zone" });
        entries.Add(new List<string>() { "Photosphere", "Chromosphere", "Transition Region", "Corona" });
        entries.Add(new List<string>() { "General description", "Solar Dynamo" });
        entries.Add(new List<string>() { "Basis statistics", "Composition" });
        entries.Add(new List<string>() { "Active regions", "Sunspots", "Umbra", "Penumbra", "Pores", "Bright Points", "Granulation" });
        entries.Add(new List<string>() { "Spicules", "Filaments and Prominences" });
        entries.Add(new List<string>() { "Coronal loops", "Coronal rain" });
        entries.Add(new List<string>() { "Flares", "Coronal mass ejections", "Solar wind", "Solar energetic particles", "Aurora", "Geomagnetic storm" });
        entries.Add(new List<string>() { "Lomnický štít", "Pic du Midi", "Teide Observatory", "Roque de los Muchachos" });
        entries.Add(new List<string>() { "Lunette Jean Rösch", "CLIMSO coronagraph", "Einstein Tower", "GREGOR", "SST", "EST"});
        entries.Add(new List<string>() { "Solar Orbiter", "Parker Solar Probe", "HINODE",   "SUNRISE", "SOHO" });
        entries.Add(new List<string>() { "Types of solar telescopes", "Primary mirror", "Secondary mirror", "Heat rejecter", "Optical transfer system", "Building", "Dome", "Coelostat" });
        entries.Add(new List<string>() { "Wavelength", "Beam splitter", "Intereference filters", "Polarization of light", "Spectral lines" });
        entries.Add(new List<string>() { "CCD camera", "Spectrograph", "Polarimeter", "Coronagraph" });
        entries.Add(new List<string>() { "Getting rid of heat", "Seeing", "Minimising seeing", "Adaptive optics", "Spectroscopy", "Spectropolarimetry", "Field Measurements", "Magnetogram", "Chromospheric lines", "Photospheric lines", "H-alpha line" });

        _credits = new List<List<string>>();
        _credits.Add(new List<string>() { "Core", "Radiative zone", "Convection zone" });
        _credits.Add(new List<string>() { "Photosphere", "Chromosphere", "Transition Region", "Corona" });
        _credits.Add(new List<string>() { "General description", "Solar Dynamo" });
        _credits.Add(new List<string>() { "Basis statistics", "Composition" });
        _credits.Add(new List<string>() { "Active regions", "Sunspots", "Umbra", "Penumbra", "Pores", "Bright Points", "Granulation" });
        _credits.Add(new List<string>() { "Spicules", "Filaments and Prominences" });
        _credits.Add(new List<string>() { "Coronal loops", "Coronal rain" });
        _credits.Add(new List<string>() { "Flares", "CMEs", "Solar wind", "Solar energetic particles", "Aurora", "Geomagnetic storm" });
        _credits.Add(new List<string>() { "Lomnický štít Observatory", "Pic du Midi Observatory", "Teide Observatory", "Roque de los Muchachos Observatory" });
        _credits.Add(new List<string>() { "Lunette Jean Rösch", "CLIMSO coronagraph", "Einstein Tower", "GREGOR", "Swedish Solar 1-m Telescope", "European Solar Telescope" });
        _credits.Add(new List<string>() { "Solar Orbiter", "Parker Solar Probe", "HINODE", "SUNRISE", "SOHO" });
        _credits.Add(new List<string>() { "Types of solar telescopes", "Primary mirror", "Secondary mirror", "Heat rejecter", "Optical transfer system", "Building", "Dome", "Coelostat" });
        _credits.Add(new List<string>() { "Wavelength", "Beam splitter", "Intereference filters", "Polarization of light", "Spectral lines" });
        _credits.Add(new List<string>() { "CCD camera", "Spectrograph", "Polarimeter", "Coronagraph" });
        _credits.Add(new List<string>() { "Getting rid of heat", "Seeing", "Minimising seeing", "Adaptive optics", "Spectroscopy", "Spectropolarimetry", "Measuring solar magnetic fields", "Magnetogram", "Common chromospheric lines", "Common photospheric lines", "Halpha line" });


        _contents = new List<List<string>>();
        _contents.Add(new List<string>()
        { //internal structure
            "The core is the deepest region of the Sun. It covers the innermost 25% of the solar radius (the solar radius is 696,340 km). This is the densest and hottest region of the Sun with a temperature of 15.6 million degrees. It is not possible to observe the solar interior directly.\n\nHere nuclear fusion takes place and transforms hydrogen into helium, releasing a lot of energy. Fusion in the Sun happens through the proton-proton chain reaction. Every second, the Sun converts 700 million tons of hydrogen into helium. About 0.7% of the mass is lost in the process and converted into energy.",
            "The radiative zone lies above the core extending outward to about 70% of the Sun's radius. The temperature is close to 7 million degrees at the bottom part and around 2 million degrees in the upper part. In this zone the energy is transported outwards by radiation. In the radiative zone the density of the plasma is so high that particles can only travel short distances before they interact with other particles, or they are absorbed. The average time for a particle to travel from the core through the radiative zone and up to the solar surface is about 171,000 years.",
            "The tachocline is the transition region between the radiative interior and the differentially rotating outer convective zone. This causes the region to have a very large shear as the rotation rate changes rapidly.\n\nThe convective exterior rotates as a normal fluid with differential rotation with the poles rotating slowly and the equator rotating quickly. The radiative interior exhibits solid-body rotation. The tachocline is located at the base of the convection zone, at about 70% of the solar radius (measured from the core) and has a thickness of 4% of the solar radius.",
            "The outermost layer of the solar interior is the convection zone, which extends from the tachocline up to the visible surface of the Sun (from approximately 70% to 100% of the solar radius).\n\nThe bottom region of this layer has a temperature close to 2 million degrees.  Energy is transported by convection, which is a way of distributing heat or energy via circular motions from the lower layers of the Sun (where the plasma is hotter) to the surface (where it is cooler). A similar process occurs in a pot of boiling water.",
        });
        _contents.Add(new List<string>()
        { //The Solar Atmosphere
            "Photosphere means ‘light sphere’ in Ancient Greek. It is the layer of the solar atmosphere closest to the surface. The thickness of the photosphere is about 500 km, very thin when compared with the radius of the Sun. The mean temperature there is 5770 K. This means that the Sun will emit most of its energy in the visible range, but also in other wavelengths. Did you ever think about why the human eye is sensitive to visible light?\n\nThanks to Isaac Newton and his experiment with a prism in 1665, we can study the solar light in different colors. A wide range of features can be observed on the photosphere, such as granulation, bright faculae, or dark magnetic features like pores and sunspots.",
            "The chromosphere is an irregular layer situated above the photosphere. Its name means ‘sphere of color’. The temperature of the chromosphere increases with height from 6000 up to 20,000 degrees C. The thickness of the chromosphere is about 2000 km.\n\nWe can observe the chromosphere during solar eclipses or using the light of spectral lines formed within this layer. The chromosphere is magnetically dominated, and shows features such as the chromospheric network, plage, fibrils, spicules, prominences at the limb and filaments on the disk. These features are very dynamic and change constantly. Large brightenings and other magnetic features can be seen in the chromosphere during solar flares or filament eruptions.",
            "TThe transition region is an irregular and very thin layer of the solar atmosphere between the chromosphere and the corona. The temperature rapidly increases with height from 20000 up to one million degrees C.\n\nThe typical ions that we can find in the transition region are Si IV, O IV, or C IV, among others, meaning that these atoms have three of their electrons stripped off. The predominant emission light of these ions is mainly ultraviolet light. Our planet is very well protected against ultraviolet radiation as most of it is absorbed by the Earth atmosphere. Due to this, we need to observe ultraviolet light from space.Typical features observed in the transition region are some types of spicules and small localised ultraviolet brightenings.",
            "The solar corona is the outermost and hottest layer of the solar atmosphere. The temperature is around 1-2 million degrees C and can be higher in areas associated with active regions. At these high temperatures both hydrogen and helium (the two dominant elements) are completely stripped off their electrons. Even minor elements like carbon, nitrogen, and oxygen are stripped down to bare nuclei. Only the heavier trace elements like iron and calcium are able to retain a few of their electrons in this intense heat.\n\nThe corona can be observed from Earth during a total eclipse of the Sun. It looks like a white ‘crown’ enclosing the Sun. Its shape usually depends on the phase of the solar cycle. When the solar activity is close to its maximum, the shape is symmetric. When it is close to a solar minimum, the shape is elongated near the solar equator. The typical features observed in the corona are plumes, streamers, and coronal mass ejections.",
        });
        _contents.Add(new List<string>()
        {//Solar Magnetic Fields
            "Solar magnetic fields are generated at the base of the convection zone by the solar rotation and convection, which create a systematic flow of charged particles (that is, electric currents). The field is amplified in the tachocline until it eventually becomes buouyant, rising to the solar surface where they are seen as active regions with sunspots and pores of opposite polarity.\n\nThanks to observations we know there is a solar activity cycle where the number of sunspots increases and decreases over time. This cycle is the consequence of the recycling of magnetic fields by plasma flows in the solar interior.\n\nThe key to understanding the processes that take place in the Sun is magnetism. All observed solar activity has its origin in the solar magnetic field.",
            "The solar dynamo is the physical process that generates the magnetic field in the solar interior. The Sun’s interior acts as an electric generator producing electric currents and magnetic fields. The dynamo transforms kinetic energy into electromagnetic energy. The exact dynamo mechanisms that are taking place in the solar interior are not fully understood and this is still a current field of research.\n\nWe observe variations produced by the solar magnetic field related to the quasi-periodic 11 years sunspot cycle. The number and size of sunspots increases, reaches a maximum, and then decreases.\n\nOther observational evidence of the solar dynamo includes, for example, Hale’s law(in one of the hemispheres, active regions have the same leading polarity while in the other hemisphere they have the opposite leading polarity), Joy’s law(the tilt of the sunspot groups changes with the phase of the solar cycle), the butterfly diagram (the latitude of the sunspots changes), or the reversal of the polar magnetic field close to the maximum of the solar cycle.",
        });
        _contents.Add(new List<string>()
        {//The Sun in numbers
            "The Sun is a star of spectral type G2V situated at the center of the Solar System. Its radius is about 696,340 km. This means that the diameter of the Sun is 109 times the diameter of the Earth.\n\nThe mass of the Sun is around 2 x 1030 kg, or 333,000 times the Earth’s mass. The Sun contains 99.86% of the total mass of the Solar System. The volume and the mean density are 1412000 x 1012 km3 and 1408 kg/m3 respectively.\n\nThe Sun-Earth average distance is around 150 million km. The age of the Sun is about 4.6 billion years. Because of its mass, the surface gravity is about 274 m/s2. The temperature of the core is 15 million K, decreasing down to 5700 K in the photosphere and increasing again up to 2 million K or more in the corona.",
            "The chemical composition of the Sun is mainly hydrogen (H) and helium (He). Approximately 71-75% is H and around 24-27% is He. A very small percentage of the Sun (1%) is made of heavy elements (called metals) such as iron, silicon, carbon, oxygen, nitrogen, magnesium, sulfur, etc.\n\nThe fusion of H into He started when the Sun was formed. In the core of the Sun, the fraction of helium is much larger, 64%, as most of the hydrogen has already been converted into helium. The core fuses 700 million tons of H into He every second. In this process, 4 million tons of matter are converted into energy every second. The mean energy production is 0.1925 x 10<sup>-3</sup> J/kg s."
        });
        _contents.Add(new List<string>()
        {//Sola Photosphere
            "An active region is a region in the Sun’s atmosphere which has a strong and complex magnetic field. This magnetic field presents two different polarities, positive and negative. In those areas, magnetic fields from the interior of the Sun emerge through the photosphere into the chromosphere and the corona. Usually, the two polarities grow rapidly and separate from each other\n\nSunspots are often visible in them, as well as faculae, bright points, prominences, and filaments to mention a few. Active regions can be the source of violent eruptions such as coronal mass ejections and solar flares. The number and location of active regions on the solar surface at any given time is dependent on the solar cycle. They can be as small as few thousand km and as big as 150000 km. And they even get names, such as NOAA 11158, for example.",
            "Sunspots are areas in the photosphere of the Sun that appear darker than the surroundings. This is because they are cooler (can be up to 2000 C cooler) than the quiet Sun. In sunspots, the process of convection is altered by the presence of strong magnetic fields, which do not allow the bubbles of hot gas coming from the interior of the Sun to emerge normally.\n\nSunspots have a darker inner area called umbra, and an outer brighter ring named penumbra with a very filamentary appearance. While the umbra has strong vertical magnetic fields, the penumbra has weaker fields which bend until they are nearly horizontal. They can be observed in many different sizes and shapes, from round to elongated, and from a few thousand km to monster sunspots of up to 100,000 km in diameter. They can last from only a few days to several months.",
            "The umbra is the darker central part of a sunspot, where magnetic fields are stronger and vertical. These magnetic fields can reach up to 4000 Gauss and the temperatures vary between 3000 and 4500 C. Despite the strong fields, some convective motions manage to happen in the umbra. Such phenomena can be observed in the form of umbral dots or amazing structures called light bridges. Both phenomena are intrusions of convective gas into the magnetic field of the umbra.",
            "The penumbra is the outer ring of a sunspot and surrounds the darker umbra. The temperature in the penumbra is about 5500 C (remember that the rest of the photosphere has a temperature of about 5800 C). It is therefore brighter than the umbra. Its magnetic field is around 1000 G and bends until is almost horizontal at the edge of the sunspot. It is characterized by a filamentary aspect.",
            "Pores are sunspots without a penumbra and are sometimes called “naked” sunspots. A pore appears when a strong magnetic field emerges through the solar surface and stops the convective transport of heat from the solar interior: that is why pores look dark. If the magnetic flux increases, the field would become inclined at the edge of the pore, a penumbra would be developed, and the pore would then transform into a sunspot.\n\nPores are \"small\" (1000 - 6000 km in diameter) but they include small bright structures, which indicate that convection from below is not completely suppressed.",
            "Bright points are very small strong magnetic elements that are located on the surface of the Sun between the granules (in the areas called intergranular lanes where the gas moves downwards into the solar interior). They are very small compared to other magnetic features observed in the solar surface, having typically less than 300 km in diameter. They are observed as bright features, often come in chains of many points and are very dynamical, even presenting swirling motions. And they can be found anywhere in the solar surface.\n\nThey represent features with intense magnetic fields (of about 1000-2000 Gauss). They appear bright in intensity because they are less dense than the surroundings, so that we observe deeper into the solar atmosphere where the temperature is higher.",
            "The solar photosphere shows a grainy pattern which is due to convective motions of the gas on the solar surface. Convection is a very efficient way to transport heat from the subsurface layers of the Sun, which are hot, to the surface, which is cooler. The same process happens in a pot of boiling water in the kitchen.\n\nBright granules are convective cells formed by hot gas that rises in the atmosphere and releases its heat before sinking back to the surface through the darker lanes observed at the borders of the granules (called intergranular lanes).\n\nGranules occur in a variety of sizes and shapes on the solar surface. Their average diameter is 1500-2000 km. They are very dynamic and have lifetimes of 5 to 10 minutes. At any time, the solar surface is covered by about 4 million granules."
        });

        _contents.Add(new List<string>()
        {//Solar Chromosphere
            "Spicules are thin, elongated jets a few hundred kilometers wide. They were discovered in 1877 by Father Angelo Secchi at the Observatory of the Roman College in Rome, but scientists are still debating their origin. \n\nAt any one time more than 100,000 spicules are present in the solar atmosphere. They pepper the entire surface of the Sun just above the photosphere and can reach a maximum height of 10,000 km at the top of the chromosphere. They can move at speeds of more than 100 km/s. These structures are found all over the solar surface, but can be observed most easily near the limb of the Sun.\n\nThey live only for a few minutes and have both a swaying and a torsional motion. They are believed to transfer mass from the chromosphere to the transition region and corona.They loosely follow the magnetic field lines sticking out of the Sun.",
            "Solar filaments or prominences are made out of thin plasma threads located inside of large, elongated structures in the chromosphere and corona of the Sun. Both terms refer to the same structures, but receive different names depending on where they are observed on the Sun.\n\nOn the solar disk, the structures are called filaments, while above the solar limb, they are called prominences. They are best seen using an H-alpha filter, visible even with amateur telescopes, and resemble dark clouds which lie in the upper atmosphere, the chromosphere and corona.\n\nHowever, they are not like clouds on Earth which are mainly made of water. The filament structure itself is confined due to the magnetic field lines.Their lifetime spans from a few days to several weeks and their formation process is still not well understood.",
        });


        _contents.Add(new List<string>()
        { //Corona
            "Coronal loops are bright, curving structures that appear as arcs above the Sun's surface. Hot electrified gas called plasma causes these loops to glow, as the plasma flows along the curving lines of powerful magnetic fields, giving the coronal loops their characteristic shapes.\n\nCoronal loops are often, but not always, associated with sunspots. They can be \"rooted\" in sunspots, arcing between pairs of sunspots with opposite magnetic poles. Coronal loops come in many sizes, with the largest extending upwards many thousands of kilometers above the Sun’s surface into the solar corona, the Sun's upper atmosphere. Some loops are extremely hot, having temperatures well above a million degrees Kelvin.",
            "The hot solar corona hosts large amounts of cool and dense material called coronal rain. This spectacular phenomenon is seen as cool material seemingly appearing out of nowhere and streaming down along coronal loops - think of it like snowflakes in the oven! It occurs when hot plasma in the solar corona cools and condenses in strong magnetic fields, usually associated with regions that produce solar flares. The plasma is attracted to the magnetic fields where it condenses and slowly falls back to the Sun’s surface.\n\nMany mysteries still surround this phenomenon, for example we don’t know why it is so clumpy and stranded in structure. These and many other important questions make coronal rain a prime target for next generation instrumentation such as the European Solar Telescope.",
        });
        _contents.Add(new List<string>()
        { //Space Weather
            "Flares are our solar system’s largest explosive events, releasing the equivalent amount of energy of the entire Earth’s power consumption in a year! A solar flare is an intense burst of radiation coming from the release of magnetic energy associated with sunspots. They are seen as bright areas on the Sun, and they can last from minutes to hours. We typically see a solar flare by the photons (or light) it releases, at almost every wavelength of the electromagnetic spectrum.\n\nFlares can cause space weather impacts at Earth such as disruptions to radio communication (particularly high frequency) and GPS navigation systems, which is due to changes occurring in the ionosphere.",
            "The outer solar atmosphere, the corona, is structured by strong magnetic fields. Where these fields are closed, often above groups of sunspots, the confined solar atmosphere can suddenly and violently release bubbles of gas and magnetic fields called coronal mass ejections (CMEs). A large CME can contain a billion tons of matter (plasma) that can be accelerated to several thousands of kilometers per second in a spectacular explosion. This solar material streams out through the solar system, impacting any planet or spacecraft in its path. CMEs are sometimes associated with solar flares but can occur independently.\n\nIf directed at Earth CMEs can cause geomagnetic storms that can disrupt our power grids. CMEs can travel speeds of hundreds or thousands of kilometers per second, and very fast CMEs could take around 18 hours to a day to arrive at Earth.",
            "The solar wind is a continuous flow of electrically charged particles (plasma) from the Sun’s outer atmosphere (corona). Its particles can escape the Sun's gravity because of their high energy resulting from the high temperature of the corona, which in turn is a result of the coronal magnetic field. The solar wind reaches speeds of hundreds of kilometers per second as it travels out through the solar system in a spiral like fashion due to the rotation of the Sun.\n\nEmitted in all directions, some of the solar wind is constantly buffeting our planet, causing beautiful displays known as the aurora in the Earth’s upper atmosphere at high latitudes near the magnetic poles.",
            "Solar energetic particles (SEPs) are high-energy particles, such as protons and electrons, that are ejected from the Sun. They originate from either a solar flare site or by shock waves associated with CMEs. They move at very high speeds - fractions of the speed of light - and can travel from the Sun to the Earth in tens of minutes.\n\nSEPs are a radiation hazard for spacecraft, astronauts, and airline passengers flying over the poles. They can also cause damage to electronics and detectors on spacecraft in orbit if not properly protected.",
            "Auroras are the most visible effect of the Sun's activity on the Earth's atmosphere, natural displays of light in the sky that can be seen with the unaided eye at night. An auroral display in the Northern Hemisphere is called the aurora borealis or Northern Lights, and in the Southern Hemisphere is the aurora australis or Southern Lights.\n\nCharged particles from the solar wind and CMEs stream down Earth’s magnetic field lines toward the magnetic poles. Energy is released when the charged particles strike atoms and molecules in the atmosphere and some of this energy appears in the form of auroras.\n\nThe most common color in an aurora is green, but displays that occur extremely high in the sky may be red or purple. Most auroras occur about 75 to 300 kilometers above the Earth, and some extend lengthwise across the sky for thousands of kilometers.",
            "The Earth's magnetosphere is created by our own magnetic field and protects us from most of the particles the Sun emits. When a CME or high-speed solar wind stream arrives at Earth it hits the magnetosphere, and if the arriving solar magnetic field is directed southward, it interacts strongly with the oppositely oriented magnetic field of the Earth in the form of a geomagnetic storm. The Earth's magnetic field is then peeled open like an onion allowing energetic solar wind particles to stream down the field lines to hit the atmosphere over the poles (often causing auroral displays). At the Earth's surface a magnetic storm is seen as a rapid drop in the Earth's magnetic field strength."
        });
        _contents.Add(new List<string>()
        {//Observatories
            "Location: Tatranská Lomnica, Slovakia.\nThe Lomnický Štít Observatory is located on top of the second-highest peak of the High Tatras mountains. It was built in the period 1957-1962. The observatory is equipped with a special type of astronomical telescope called coronagraph. Such instrument allows observing the upper part of the solar atmosphere, the corona, by creating an artificial eclipse.\n\nThe measurements have mainly been used to monitor the changes in the solar coronal activity. In 2011 and 2016, two new detectors (Comp-s and SCD) were installed on the coronagraphs. Both instruments use a tunable filter with a polarimeter, which allows to observe coronal and chromospheric structures.",
            "Location: Pic du Midi, France\nThe Pic du Midi Observatory is located in the Pyrenees mountains, at 2870m altitude. The scientific adventure at Pic du Midi started around 1870, first just as a meteorological observatory.\n\nIn the 1930s, Bernard Lyot built the first coronagraph and started making the first pictures, then movies, of solar prominences and the corona. The solar corona was seen out of an eclipse at Pic du Midi for the first time.\n\nAfter the 2nd World War, the Turret telescope, later called Jean Rösch, was built.This instrument provided the best images of the solar photosphere for years and the first clear picture of solar convection.\n\n150 years later, the Pic du Midi observatory keeps observing the Sun with CLIMSO, a set of coronagraphs that keeps our star under surveillance.",
            "Teide Observatory is dedicated mainly to the study of the Sun. The excellent sky conditions for astronomy occurring there are the result of its geographical location on an island in the middle of the Atlantic Ocean and the influence of the trade winds.\n\nThe observatory hosts some of the best European solar telescopes: GREGOR, the Vacuum Tower Telescope (VTT) or THÉMIS.\n\nThe Solar Laboratory “Pirámide” contains several instruments to study the Sun's interior through helioseismology. In 1979, Teide Observatory became the birthplace of helioseismology, a technique that provides us with an insight into the interior of our star through the study of its internal and surface vibrations.\n\nTeide Observatory also hosts other instruments, including night-time telescopes, robotic and remotely operated telescopes, and experiments to measure the cosmic microwave background radiation. With their help, the most important comets of recent years have been monitored, including the collision of comet P/Shoemaker-Levy with Jupiter. Large-scale maps of the Galactic centre have been compiled as well.",
            "Location: La Palma, Spain\nRoque de los Muchachos Observatory (ORM) is one of the largest telescope arrays in the world. It stands on the rim of the Caldera de Taburiente National Park (La Palma, Spain). The observations carried out for decades at ORM have confirmed this site as one of the best locations in the world for solar observations.\n\nThe ORM hosts two solar telescopes, the Swedish 1-m Solar Telescope (SST) and the Dutch Open Telescope (DOT).Due to its outstanding characteristics, ORM has been designed as the final location to build the European Solar Telescope.\n\nThe observatory also hosts the Gran Telescopio Canarias, the largest optical - infrared telescope in the world with a 10.4m primary mirror, along with twenty other telescopes and instruments for various kinds of studies, including night - time observations, robotic observations, and high energy astrophysics.Important advances in the study of the Universe have been made with these telescopes, ranging from the detection of the most distant galaxy to confirmation of the existence of black holes and the accelerated expansion of the Universe.",
        });
        _contents.Add(new List<string>()
        {//Ground-based telescopes
            "Location: Observatoire du Pic de Midi. French Pyrenees. France\nThis telescope was built right after the 2nd World War by Jean Rösch to take advantage of the pristine conditions for solar observations at Pic du Midi. It is made of just one lens of 40 cm in diameter mounted on a tube, which stands out beyond the main building. Inside the dome, photographic films or astronomical instrumentation are placed at the primary focus of the lens.\n\nThe dome and the tube are closed, resembling a tank turret. This structure was designed to protect the telescope and to avoid the deterioration that classic domes cause in the quality of the images.\n\nIt was the first telescope to clearly show solar granulation and bright points in intergranular lanes, unveiling convection and the presence of magnetic fields in the Sun.After 50 years of observations, the telescope stopped its scientific work, and nowadays it is used for student practice.",
            "Location: Observatoire du Pic de Midi. French Pyrenees. France\nCLIMSO is a suite of solar telescopes installed at Pic du Midi observatory. In the late 90s it was purchased by an association of amateur astronomers, and nowadays it is dedicated to the continuous surveillance of the Sun.\n\nIt consists of four main instruments. Two of them are telescopes of refractor type. They take full images of the solar disk and allow for views of the mid and the low chromosphere. These telescopes are used to locate solar filaments and magnetically active regions in the Sun.\n\nIn addition, CLIMSO is equipped with two coronagraphs. They are instruments that create artificial solar eclipses to observe the corona and the prominences. With a diametre of 20 cm, CLIMSO’s coronagraphs are some of the largest ones in operation in the world.\n\nCLIMSO data are freely available through the Virtual Solar Observatory, covering well over one complete solar cycle.",
            "Location: Potsdam, Germany\nThe Einstein Tower was the first solar tower telescope constructed in Europe in the early 1920s. It was built to demonstrate an Einstein’s theory, detecting the “gravitational redshift”, but with no success.\n\nThe building features an inner wooden tower which supports the telescope lens and the coelostat on its top, while the mechanically detached, solid outer tower supports the dome and provides shielding from wind forces. A folding flat mirror directs the sunlight towards the spectrograph in the basement of the building. The basement is underground and provides a stable environment for high-precision measurements of the light.\n\nFor many years, the Einstein Tower was used to perform observations of magnetic fields in sunspots. One of the major findings was the discovery of so - called delta spots (sunspots with opposite polarities inside one penumbra) by Künzel in the 1960s. This telescope is still operational and is used to test new spectropolarimetric instrumentation.",
            "Location: Observatorio del Teide, Tenerife, Spain\nGREGOR is Europe's largest solar telescope. It started scientific operations in 2014. With a primary mirror of 1.5 meters of diameter, GREGOR is an open telescope with a fully retractable dome. This allows to avoid disturbances in the observations caused by the excess of heating. In this way, the natural air flow cools the telescope structure without introducing turbulence and vibrations, which would decrease the image quality significantly.\n\nAtmospheric turbulence does also alter the observations, so its effects are compensated by “GAOS”, the GREGOR adaptive optics system. The function of an adaptive optics system is to measure and correct the aberrations introduced by the atmosphere in real time.\n\nGREGOR collects data from the photosphere and the overlying chromosphere. It can see structures of about 50 km on the solar surface. Data gathered by GREGOR let the solar astronomers to measure magnetic fields and gas motions in the Sun with high precision.",
            "Location: Observatorio del Roque de los Muchachos, Spain\nThe Swedish 1-m Solar Telescope (SST) is located on the island of La Palma, and it started operations in 2002. It is mounted in a tall tower, and is a refractor telescope, so the main optical element is not a mirror, but a 1m diameter lens.\n\nThe SST is a vacuum telescope which means that air is pumped out of its tube. This avoids heated air in the light path that would destroy the image quality. It is the first solar telescope to reach a spatial resolution of 0.1 arcseconds. That means that it can see things as small as 70 kilometres on the Sun. This immediately allowed scientists to discover new structures in sunspots.\n\nSince then, the SST has been equipped with more advanced instruments that make images of the Sun in different wavelengths and also measure the polarization of sunlight. In that way, it is possible to determine temperatures, velocities, and magnetic fields in the solar atmosphere.",
            "The European Solar Telescope (EST) is a next generation large-aperture solar telescope. It will be located in the Roque de los Muchachos Observatory, at the island of La Palma (Canary Islands, Spain), a first-class site for astronomical observations.\n\nWith a 4.2-metre primary mirror, EST will be the largest ground-based infrastructure for solar observation in Europe.Its main objective is to study the magnetic and dynamic coupling of the solar atmosphere.It will specialise in high spatial and temporal resolution, using several spectroscopic and spectropolarimetric instruments simultaneously to produce 2D spectral information. This will allow diagnostics of the thermal, dynamic and magnetic properties of the solar plasma over many scale heights.\n\nThe EST project is promoted by the European Association for Solar Telescopes, which is formed by 26 research institutions from 18 European countries.EST was included in the ESFRI Roadmap in 2016 and is therefore considered a strategic European research infrastructure.Construction is planned for 2024, after the end of the preparatory work currently being carried out."
        });
        _contents.Add(new List<string>()
        {//Solar orbiter
            "Solar Orbiter is an ESA mission in collaboration with NASA, launched on 10 February 2020 from Cape Canaveral (Florida, USA). It is a complex scientific laboratory that takes images of the Sun from closer than any spacecraft before and, for the first time, will look at the uncharted solar polar regions.\n\nSolar Orbiter combines six remote sensing instruments and four in-situ instruments. They will study the Sun and the heliosphere as a complex system where all the phenomena taking place in the interplanetary medium have their origin in our star.\n\nThanks to Solar Orbiter, scientists hope to find answers to questions like what drives the Sun’s 11-year cycle, what heats the solar corona to millions of degrees Celsius, what generates the solar wind, and why it accelerates to speeds of hundreds of kilometres per second, or how does it all affect our planet.",
            "Parker Solar Probe is the NASA's mission launched on August 12, 2018, to improve the understanding of the Sun. It travels through the Sun’s atmosphere, closer to the surface than any spacecraft before it, facing hard heat and radiation conditions to provide the closest-ever observations of a star.\n\nThe spacecraft uses Venus’ gravity during seven flybys over nearly seven years to gradually bring its orbit closer to the Sun. The spacecraft will fly through the Sun’s atmosphere as close as 6 million km to our star’s surface, well within the orbit of Mercury and more than seven times closer than any spacecraft has come before.\n\nParker Solar Probe employs a combination of in situ measurements and imaging to study the corona in the hope of expanding our knowledge of the origin and evolution of the solar wind. It will also make critical contributions to our ability to forecast changes in Earth's space environment that affect life and technology on Earth.",
            "Hinode is a Japanese space mission launched on September 23, 2006, and developed by ISAS/JAXA, collaborating with the National Astronomical Observatory of Japan (NAOJ), NASA, and Science and Technology Facilities Council (UK), to study the Sun. It follows a Sun-synchronous orbit around Earth at an altitude of 650 km. The orbit allows Hinode to observe the Sun continuously for nine months at a time.\n\nHinode explores the magnetic fields of the Sun to improve understanding of what powers the solar atmosphere and drives solar eruptions. Hinode’s Solar Optical Telescope is the first space-borne instrument to measure the strength and direction of the Sun’s magnetic field on the Sun’s surface, the photosphere.\n\nCombined with two other instruments, the EUV imaging spectrometer (EIS) and the X-ray/EUV telescope (XRT), the mission is designed to understand the causes of eruptions in the solar atmosphere and relate those eruptions to the intense heating of the corona and the mechanisms that drive the constant outflow of solar radiation, the solar wind.",
            "The SUNRISE balloon-borne observatory is a mission developed by a German-Spanish-American consortium led by Max-Planck Institute for Solar System Research (MPS).\n\nThe first two flights of SUNRISE took place in June 2009 and June 2013 from Kiruna (Sweden) to the northern coast of Canada with an approximate duration of five and a half days each. The observatory carried two post-focal instruments: a UV camera and an imaging spectropolarimeter.\n\nWith its aperture of 1 meter and nearly 25 meters focal length, the SUNRISE telescope uses innovative mirror technologies, active in-flight alignment, and image stabilization systems. Thanks to its high spatial resolution, the telescope is capable of resolving structures smaller than 100 km on the solar surface.\n\nThe third edition of the mission is being prepared for June 2022 and includes Japanese contributions.While keeping the basics of the telescope and the instrument platform, SUNRISE will be provided with a new gondola system and three new post-focal instruments: two slit-spectrograph-based and one filtergraph-based spectropolarimeter working at UV, IR, and visible wavelengths.",
            "The Solar & Heliospheric Observatory (SOHO), is a project of international collaboration between ESA and NASA to study the Sun from its deep core to the outer corona and the solar wind.\n\nSOHO was launched on December 2, 1995. The twelve instruments on board were provided by European and American scientists to answer several fundamental questions about the Sun. For example: what is the structure and dynamics of the solar interior; why does the solar corona exist, and how is it heated to the extremely high temperature of about 1 000 000°C; or where is the solar wind produced and how is it accelerated.\n\nThe spacecraft moves around the Sun in step with the Earth by slowly orbiting around the First Lagrangian Point (L1), where the combined gravity of the Earth and Sun keep SOHO in an orbit locked to the Earth-Sun line. The L1 point is approximately 1.5 million kilometres away from Earth, in the direction of the Sun.There, SOHO enjoys an uninterrupted view of our daylight star."
        });
        _contents.Add(new List<string>()
        {//Telescopes subsystems
            "Telescopes are optical instruments used to observe distant astronomical objects. They were invented in the 17th century. There are two types of telescopes: refracting and reflecting telescopes. Refracting telescopes use lenses to collect and focus the light, forming an image of the object, while reflecting telescopes use mirrors.\n\nIt is relatively easy to build large mirrors of high optical quality, so the largest solar telescopes currently in operation are reflecting telescopes. Examples include the 1.5 metre GREGOR telescope (Tenerife, Spain), the 4 metre Daniel K. Inouye Solar Telescope (Maui, USA), and the future 4 metre European Solar Telescope (La Palma, Spain).\n\nRefracting telescopes tend to be smaller, but they provide excellent image quality because of their simpler design and the lack of any central obscuration. A good example is the 1 metre Swedish Solar Telescope (La Palma, Spain), which has the largest lens in operation in the world.",
            "The first mirror (M1) of a reflecting telescope is called the primary mirror. The larger it is, the more light it collects and the higher the resolving power of the telescope is. In solar observations it is important to have as much light as possible, to be able to take images of the Sun at high speed and to observe very weak signals more easily.\n\nThe primary mirror is curved and sends the light to the secondary mirror. This is a critical element of a solar telescope. It must have very good optical quality and must remain at the same temperature as the surrounding air, to avoid turbulence and image degradation. For that reason, it usually has a dedicated cooling system. Also, the primary mirror must keep its shape independently of the telescope pointing. This is achieved with mechanical actuators that correct the gravitational deformations of the mirror.\n\nThe European Solar Telescope will have a 4.2 m primary mirror with a central hole of 800 mm in diametre and a total weight of 2,400 kilograms.",
            "The secondary mirror (M2) is the second mirror encountered by the light in a reflecting telescope. It can be a curved or a flat mirror, supported by a spider at the end of the telescope tube.\n\nThe secondary mirror is smaller and can be moved more easily than the primary mirror. For that reason, it is used to set the telescope focus.\n\nThe European Solar Telescope will have an active secondary mirror of 800 mm in diametre. It will be used not only to focus but also to correct the image motion caused by wind shaking and the image blurring caused by air turbulence.",
            "The primary mirror of a solar telescope concentrates the sunlight in the prime focus, a very small area which receives a huge energy flux and therefore can reach extremely high temperatures. A special device called heat rejecter is used to get rid of that energy and prevent overheating of the telescope structure and the surrounding air.\n\nHeat rejecters are flat mirrors inclined 45 degrees with respect to the light beam that are placed at the position of the prime focus. A small central hole allows the light corresponding to the desired field of view to go through, while the rest is reflected by the mirror, thus eliminating excess energy.\n\nThe heat rejecter removes most of the unwanted energy, but not all. The heat rejecter mirror absorbs one percent of the light and gets heated.For that reason, heat rejecters have dedicated cooling systems based on liquid coolants or air.",
            "The light follows a complicated path inside a solar telescope. It is collected by the primary mirror and sent to the secondary mirror, which reflects it back to the primary mirror. It is then picked by a third mirror, or M3, which can be placed in front or behind the primary mirror. Usually, M3 reflects the light out of the telescope, along the elevation axis. A system of mirrors then transfers the light to the interior of the building, until it reaches the optical labs where the instruments are located.\n\nThe optical transfer system consists of M3 and all the other mirrors or lenses used to send the light to the instruments. Each mirror receives an individual number next to the letter M. In the case of the European Solar Telescope, it will have 4 mirrors and two lenses in a vacuum tank. These four mirrors will be part of the multi-conjugated adaptive optics system of the telescope and will change shape very quickly to minimise image blurring caused by turbulence in the Earth’s atmosphere. In addition, these four mirrors will be arranged such that they do not introduce instrumental polarisation.",
            "Solar telescopes are placed atop high towers to avoid heating from the ground, which destroys the image quality. Far from the ground, open telescopes are also exposed to the wind flow, which helps maintain the telescope at the ambient temperature and prevents image degradation.\n\nThe building supports the telescope structure and the dome, and houses the optical transfer system and the instrument rooms. Solar telescopes have large focal lengths to produce highly amplified images of the solar surface. Having a tower helps accommodate such long focal distances.\n\nIn the case of the European Solar Telescope, the height of the building will be 44 metres with the dome closed and the primary mirror will be located 38 metres above the ground.",
            "The dome protects the telescope during the night, bad weather conditions and maintenance periods. It must withstand harsh environmental conditions.\n\nClassical domes are closed, having only a small aperture through which sunlight can enter the telescope. They protect the telescope from unwanted vibrations caused by the wind. They also minimise heating and turbulence within the dome, preventing image blurring. Some domes are isolated from the exterior with a glass window to keep the air inside at constant temperature.\n\nDomes can also be open. Made of a special fabric, they are fully retractable, leaving the telescope and the mirror exposed to the air. This is the best solution to maintain the telescope structure and mirrors at ambient temperature. The normal air flow through the telescope removes heat and minimises turbulence.\n\nThe first solar telescope with an open dome was the Dutch Open Telescope on La Palma (Spain). The European Solar Telescope will also have an open dome to deliver the best image quality possible.",
            "Coelostats are devices used to collect and  send sunlight to the interior of a solar tower by means of two mirrors. The first mirror follows the Sun during the day with the help of a motor and reflects the light to the second mirror, which is mounted on a pillar and does not move. The second mirror is responsible for directing the light inside the building.\n\nCoelostats provide a simple way to feed solar instruments. They can be found in both large and small telescopes. Examples include the German Vacuum Tower Telescope (VTT, Tenerife, Spain), the Einstein Tower (Potsdam, Germany) and the spectroheliograph of the Astronomical and Geophysical Observatory of the University of Coimbra (Coimbra, Portugal)."
        });
        _contents.Add(new List<string>()
        {//Optics
            "Light is a form of energy. Similar to waves that you would see at the beach, light also travels as a wave. Like ocean waves, light waves have peaks and valleys, and scientists will often refer to something known as the ‘wavelength’ to describe the properties of the light.\n\nThe wavelength of light is measured as the distance between two points from identical positions in back-to-back waves. For example, we can measure the wavelength of light as the distance from one peak in the wave to the peak of the next wave. Therefore, light with shorter wavelengths will have their peaks and valleys repeated more frequently. Also, light with shorter wavelengths (e.g., gamma rays and x-rays) will have more energy than those at longer wavelengths (e.g., microwaves and radio waves).\n\nWe can see the effect of different wavelengths of light when looking at visible light as different wavelengths will have different colours. You can see this very clearly when looking at a rainbow, where the red colour is from light at a longer wavelength than the violet light which has a shorter wavelength.\n\nIn solar physics, the wavelength of the light we are observing is important as it can give us a clue about the region where the light has come from. For example, what the temperature of the region of the Sun is and what elements (e.g., helium) are present in that region. Wavelength of light is a property of the light that we can measure from the Sun that can be used then to tell us more about the Sun.",
            "A beam splitter is a type of device that splits a beam of light in two. There are various ways to do this, but one of the most common methods is to use a cube made of two triangular prisms. The glass of the cube is chosen to have specific properties that allow part of the light entering the cube to be reflected, while the rest of the light passes through the cube without changing direction.\n\nIn a telescope, a beam splitter can be used to split incoming light towards different instruments. Special beam splitters can also be used to polarise the light.",
            "Interference filters help us isolate specific wavelengths of light. They consist of multiple thin layers of materials specially chosen to let light through at specific wavelengths while blocking other wavelengths. Using interference filters to look at specific wavelengths allows us to produce images from different regions of the solar atmosphere.\n\nBy carefully selecting a collection of interference filters for different wavelengths, we can build up images at different heights of the solar atmosphere and observe how certain features on the Sun appear in different layers as well as observe the motion of material between regions in the Sun.",
            "Light is a special type of wave, known as an electromagnetic wave. Electromagnetic waves can travel through the vacuum of space. Electromagnetic waves have both electric and magnetic components. Unpolarised light is an electromagnetic wave that vibrates in many different random planes along the direction that the wave is travelling in. When light is polarised, it will only oscillate in one particular plane. Light can be partially polarised when it is scattered by molecules in Earth’s atmosphere. Our eyes cannot detect the difference between polarised and unpolarised light, but we can see its effects in the brightness and colour of clear skies.\n\nAlso, we can see the effects of polarised light when using a polariser. A polariser is a device that lets light vibrating in a certain plane through while blocking all other directions of vibration.Polarised sunglasses use polarisers to block light and reduce glare. If you took two pairs of polarised sunglasses and rotated one pair with respect to the other while light was passing through, when held at the right angle, all light passing through the sunglasses would be blocked. This is due to the fact that the polarised lens in the first pair of sunglasses polarises the light, so it vibrates only in one plane. Then when you move the second pair, the polarised lens of the second pair will eventually be aligned in the correct direction to block the polarised light completely from the first pair.\n\nIn solar physics, we use the polarisation of light to work out the magnetic fields of various magnetic structures on the Sun such as sunspots.",
            "Atoms consist of electrons that orbit a nucleus. Orbiting electrons can be found in different energy levels around the nucleus. When an electron moves from a higher energy level to a lower one some light is emitted. The light emitted has a very specific wavelength depending on the levels that the electron moves between. The light emitted is referred to as a spectral emission line. Likewise, an electron can absorb incoming light and can move from a lower energy level to a higher one, as it has absorbed energy from the incoming light. Again, this absorption corresponds to a specific wavelength of light based on the energy levels that the electron moves between. This is known as a spectral absorption line. Each atom has different energy levels which correspond to different wavelengths. Therefore, spectral lines act as a sort of ‘fingerprint’ for different elements and can allow us to identify elements based on its unique spectrum of lines.\n\nIn solar physics, spectral lines are used to observe specific regions of the solar atmosphere. Different regions will have different quantities of atoms and different temperatures, which will correspond to different spectral lines. By using an interference filter, we can limit the wavelength of the light that we observe to those of a given spectral line. This allows us to observe the region in the solar atmosphere where this spectral line is formed. Therefore, we can use the spectral line as a method of looking at specific regions of the solar atmosphere.\n\nWe can gather more information from spectral lines as we know what the expected wavelength of a spectral line is. For example, we can use the concept of a Doppler shift to work out how fast material on the Sun is moving, upwards or downwards, using the spectral line. You can visualise a Doppler shift by considering the sound of ambulance sirens as it passes by. The sound of the ambulance will have a higher pitch as it speeds towards you and then will change to a lower pitch after it has passed. This is due to the change in wavelength of the sound of the siren due to the motion of the ambulance. As it speeds towards you the wave is compressed but after it passes by it stretches out as the ambulance gets further away. On the Sun, a similar phenomenon is observed with spectral lines. If material is moving away from you, the observer, then the wavelength of the spectral line will move to a longer wavelength, which is redder in the colour spectrum (so we refer to it as a ‘red shift’). If the material is moving towards you, the spectral line will have a shorter wavelength and will be bluer than it normally is (so we refer to it as a ‘blue shift’). Therefore, as well as showing us different regions of the solar atmosphere, spectral lines can help us work out how fast material is moving."
        });
        _contents.Add(new List<string>()
        {//Solar instruments
            "A CCD camera is a type of digital camera known as a Charge-coupled Device (hence the acronym CCD). Basically, it is an instrument for recording images, that works by converting incoming light to an electric charge which can be read by a computer.\n\nIf you were to look at the surface of a CCD under a microscope, you would see a series of dot-like structures on a grid. These dots are what is known as a photodiode and are the device that converts the incoming light to an electrical current. Each dot (or photodiode) is one pixel, which is the smallest unit of the image. You may hear that a CCD or an image has a certain pixel size, this tells you how many photodiodes there are on your sensor. The grid of photodiodes then is used to reproduce the image that has been recorded by the CCD. The grid of photodiodes has their electrical currents quickly read out by the CCD which is passed on to a computer that can save and store the image.\n\nWhen the electrical current has been read out, the photodiodes are now able to take a new image and, so, we can build up a movie by continuously taking images with the CCD.  When reading out the electrical currents, small errors can be added to the image due to the temperature of the camera (and other factors). Normally we try to correct these errors by taking additional ‘calibration’ images using the CCD. In solar physics, CCD cameras are extremely important in taking images of the Sun and converting them to a digital format that can be read and analysed by a scientist using special computer software.",
            "A spectrograph is an instrument that separates incoming light by its wavelength and then records the resulting spectrum. As each atom has its own spectrum (made up of spectral emission and spectral absorption lines) we can use that to identify atoms that produced the incoming light and therefore determine the chemical composition. A lot of our knowledge on the chemical composition of the universe is through the use of spectrographs.\n\nThere are several different types of spectrographs, with different designs and methods for splitting the incoming light. A common method uses something known as a diffraction grating. A diffraction grating is an optical component that splits and diffracts(causes a slight bending) the incoming light into different beams travelling in different directions. Diffraction can be achieved when light passes through glass with a series of ridges or by passing through a device using small, closely spaced slits. The split light is then reflected onto a CCD camera to be read by a computer. Like spectral lines, spectrographs can give us information on the speed of the material on the Sun through Doppler shifts and can be used to give us an idea of the temperature of the region on the Sun.",
            "Polarimeters are devices used to measure the direction of polarisation (or polarisation state) of incoming light. Basically, a polarimeter works by using a special filter that only allows light with a specific direction of polarisation through. This is then measured by a CCD camera. In more advanced polarimeters, the direction of polarisation that is allowed by the filter can be varied to allow light with different polarisation states through. This then gives a complete picture of how the incoming light is polarised.\n\nThe polarisation state of the incoming light is very important for scientists to measure. When studying the Sun, the polarisation of the light can tell scientists about magnetic fields that are present in the Sun.",
            "Light from the Sun appears mostly from a region at the surface known as the photosphere. This light is very intense and the glare from the light obscures the view to other regions of the solar atmosphere. A coronagraph is a device that helps block this light so that it is easier to see light from fainter regions of the solar atmosphere such as the corona (which is where the device gets its name). The corona is a region at the top of the solar atmosphere and extends millions of kilometres into space. The corona is visible during a total solar eclipse. During an eclipse then, the moon acts as a sort of coronagraph, blocking out light from the bright photosphere at the surface of the Sun for the duration that the moon completely covers the Sun. Remember, never look directly at the Sun with the naked eye, as the intense light can permanently damage your eyes.\n\nMan-made coronagraphs also exist. One possible design is to use a mirror with a hole in it. The desired light from the corona is reflected from the mirror to a CCD camera, but the unwanted light passes through the hole in the mirror. The solar corona is a very important region of the Sun for scientists as we do not fully understand it. Coronagraphs then are one possible method for us to study the corona.",
        });
        _contents.Add(new List<string>()
        {//Solar observations
            "The Sun is the main source of heat on Earth and assures humans a habitable environment. However, when pointing a telescope to the Sun, all the collected light concentrates on the primary focus of the telescope. Part of that light falls outside of the field of view recorded by the cameras.\n\nThe excess of light produces heat of up to 2000 Watt for the EST. This negatively affects the image quality of the telescope. Therefore, the telescope needs a cooling system to get rid of that heat. The engineers of the EST are currently exploring new ways of doing it.",
            "Light coming from the Sun has a long journey until it reaches a solar telescope on Earth. While in space, the light travels relatively undisturbed. However, once it reaches the Earth’s atmosphere, it suffers distortions when it passes through turbulent air flows in the sky. Therefore, the image quality at the telescope gets worse, resulting in blurry images. One solution to this problem is the use of an adaptive optics system.",
            "Heat produces turbulence in the air, which blurs the images recorded by a telescope. There are several ways to minimise these effects and therefore enhance the image quality during the observations.\n\nSolar telescopes are always mounted on top of high buildings, far away from the ground which gets heated by sunlight. In addition, buildings, the telescope itself and the surroundings of the building are painted in white, to reduce the amount of Sun’s heat they absorb as much as possible. Often telescopes have domes which can be pulled back to assure stable air flows through the telescope. When using closed domes, the interior is acclimatized to have a constant temperature.\n\nThe location of the telescope is also crucial to have good seeing conditions. Dry,  high-altitude areas have the best atmospheric conditions, as well as areas with a stable atmosphere like mountains on islands surrounded by the ocean or large lakes.\n\nFinally, adaptive optics systems are used at modern telescopes to correct in real time the distortions of the image introduced by the turbulent atmosphere.",
            "An adaptive optics system is used to minimise the seeing effects produced by the Earth’s atmosphere and hence increase the image quality of the observations. A conventional adaptive optics system consists of three elements: a wavefront sensor of the light, a deformable mirror correcting ground-layer turbulence, and a processing unit.\n\nHow does it work? The sensor measures the incoming wavefront of the light every several milliseconds and, using specific algorithms, the processing unit calculates the ideal deformation of the mirror to correct the aberrations. This allows astronomers to compensate for the negative effects on the image quality produced by turbulent flows in the Earth’s atmosphere (seeing).",
            "Spectroscopy is a technique employed to study electromagnetic radiation (light) as a function of wavelength or frequency. The light can be split into different wavelength bands. In the visible light this would correspond to the different colours.\n\nThe most useful bands to study the Sun are: radio waves, infrared, visible light, ultraviolet, X-rays and gamma-rays. Each individual band comprises specific wavelengths that correspond to transitions of atoms, like hydrogen, helium and iron, among others. Therefore, by analysing certain spectral transitions with spectroscopy, astronomers can obtain information about the atoms themselves. In addition, this allows them to obtain the properties of the solar atmosphere where the atoms are embedded in, like for example the velocity and the temperature of the gas they are part of.",
            "Spectropolarimetry is a technique to measure and interpret the polarisation of electromagnetic radiation (light) in spectral lines. Polarisation is an intrinsic property of the light, together with its wavelength (colour) and intensity (brightness). It describes the vibration of the magnetic and electric fields making up the electromagnetic wave,  A number of physical processes are able to modify the polarisation of the light, like for example the presence of magnetic fields. Therefore, using spectropolarimetry we can determine the magnetidc properties of features on the Sun, such as sunspots, filaments or flares.",
            "Currently, there is no direct way to measure the magnetic field on the Sun. It is too hot on the solar surface to have an instrument there to measure the magnetic field!\n\nHowever, by analysing the light coming from the Sun with a polarimeter, astronomers can obtain quite precise values of the magnetic field, even its orientation. This instrument allows us to measure the polarisation of spectral lines from the Sun, that is, the direction in which the electrical and magnetic fields are oscillating. Combining the information from the different directions of oscillations and some mathematical formulae, solar physicists infer the magnitude and direction of the magnetic field.",
            "A magnetogram is a map of the solar magnetic field strength. Magnetograms are often shown in black and white, each one representing a different polarity of the magnetic field. Since astronomers cannot measure the magnetic field directly on the Sun, they make use of spectropolarimetry together with the Zeeman effect to construct a magnetogram. For instance, the Solar Dynamics Observatory satellite generates a magnetogram of the Sun about every minute.",
            "Astronomers use a number lines in the solar spectrum to study the chromosphere of the Sun. Among them, the hydrogen H-alpha line at 656.3 nm is well known because it shows the beauty of the solar chromosphere in all its details. Another popular spectral line is the calcium line at 854.2 nm, one of the few lines which has been studied and modelled in detail, and therefore can be used to infer many physical parameters of the solar chromosphere, such as its temperature and magnetic field. Of great interest is also the helium triplet at about 1083.0 nm. Although not easy to interpret, it has been the subject of many studies and provides excellent information about the magnetic fields in chromospheric phenomena such as filaments or flares.",
            "The photosphere hosts many interesting spectral lines. Among the most popular ones is the iron 617.3 nm line, which is used for example by the Solar Dynamics Observatory (SDO) to produce magnetograms of the whole Sun using spectropolarimetric techniques. A popular line pair is the iron 630.1 and 630.2 nm spectral lines. The Hinode spacecraft provides magnetograms using these lines. In addition, ground-based telescopes often observe the near-infrared lines of iron at 1564.8 nm and of silicon at 1082.7 nm. There are many more spectral lines suitable to be studied in the photosphere and most of these lines cover different heights in the atmosphere. Therefore, studying several lines simultaneously allows us to better determine the properties of the photosphere.",
            "Hydrogen alpha (H-alpha) is a specific atomic transition of the hydrogen atom observed at a wavelength of 656.28 nm, in the red part of the spectrum. Hydrogen is the most abundant element in the universe. Therefore, the H-alpha spectral line is very popular among solar and night-time astronomers. On the Sun for example, the H-alpha line maps the chromosphere. When looking at the Sun with an H-alpha filter, we see a rich layer of dark solar features such as filaments, arch filament systems, spicules, fibrils, etc."
        });

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
            if (FindObjectOfType<PauseCanvasController>() != null)
            {
                FindObjectOfType<PauseCanvasController>().Continue();
            }
        }
    }
    public void ShowContent(int contentIndex)
    {
        for(int i = _contentHolder.transform.childCount-1; i>=0; i--)
        {
            Destroy(_contentHolder.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i< entries[contentIndex].Count; i++)
        {
            SolarpediaEntryTitle entry = Instantiate(_solarPediaEntryTitle, _contentHolder.transform).GetComponent<SolarpediaEntryTitle>();
            entry.Init(entries[contentIndex][i], contentIndex, i, this);
        }
        _contentGO.SetActive(true);
        _indexGO.SetActive(false);
        showing = true;
        ShowFastFinalContent(contentIndex, 0);
    }

    void Update()
    {
       
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
        //_image.sprite = _images[newValue];
        //_image.overrideSprite= _images[newValue];
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
