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
    IEnumerator FastEntryRefresh(int entry, int subentry)
    {
        Color transparentWhite = new Color(1, 1, 1, 0);
        _entryTitle.color = transparentWhite;
        _content.color = transparentWhite;
        _entryTitle.text = entries[entry][subentry];
        _entryTitle.color = new Color(0, 0, 0, 0);
        _content.text = _contents[entry][subentry];
        Sprite sprite = Resources.Load<Sprite>($"SolarpediaSprites/{entry}/{subentry}/img");
        TextAsset mytxtData = (TextAsset)Resources.Load($"SolarpediaSprites/{entry}/{subentry}/credit");
        string credits = "";
        if (mytxtData != null)
        {
            credits = mytxtData.text;
        }
        if(sprite != null)
        {
            _image.enabled = true;
            _image.sprite = sprite;
            if (!string.IsNullOrEmpty(credits))
            {
                _entryCredits.text = credits;
                _entryCredits.enabled = true;
            }
            else
            {
                _entryCredits.enabled = false;
            }
        }
        else
        {
            _image.enabled = false;
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
            _entryTitle.color = Color.Lerp(Color.white, transparentWhite, i/0.25f);
            _entryCredits.color = Color.Lerp(Color.white, transparentWhite, i / 0.25f);
            _content.color = Color.Lerp(Color.white, transparentWhite, i/0.25f);
            _image.color = Color.Lerp(Color.white, transparentWhite, i / 0.25f);
            yield return null;
        }
        _image.color = transparentWhite;
        _entryTitle.color = transparentWhite;
        _content.color = transparentWhite;
        _entryTitle.text = entries[entry][subentry];
        _entryTitle.color = new Color(0, 0, 0, 0);
        _content.text = _contents[entry][subentry];
        _entryCredits.color = transparentWhite;
        Sprite sprite = Resources.Load<Sprite>($"SolarpediaSprites/{entry}/{subentry}/img") as Sprite;
        _image.sprite = sprite;
        string credits = "";
        TextAsset mytxtData = (TextAsset)Resources.Load($"SolarpediaSprites/{entry}/{subentry}/credit");
        
        if (mytxtData != null)
        {
            credits = mytxtData.text;
            _entryCredits.text = credits;
            _entryCredits.enabled = true;
        }
        else
        {
            _entryCredits.enabled = false;
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

        _entryTitle.color = Color.white;
        _entryCredits.color = Color.white;
        _content.color = Color.white;
        _entryTitle.color = Color.white;
        _content.color = Color.white;
    }
    void Start()
    {
        SolarPedia slrpd = new SolarPedia();
        entries = new List<List<string>>();
        entries.Add(new List<string>() { "Core", "Radiative zone", "Tachocline", "Convection zone" });
        entries.Add(new List<string>() { "Photosphere", "Chromosphere", "Transition Region", "Corona" });
        entries.Add(new List<string>() { "General description", "Solar Dynamo" });
        entries.Add(new List<string>() { "Basis statistics", "Composition" });
        entries.Add(new List<string>() { "Active regions", "Sunspots", "Umbra", "Penumbra", "Pores", "Bright Points", "Granulation" });
        entries.Add(new List<string>() { "Spicules", "Filaments and Prominences" });
        entries.Add(new List<string>() { "Coronal loops", "Coronal rain" });
        entries.Add(new List<string>() { "Flares", "CMEs", "Solar wind", "Solar energetic particles", "Aurora", "Geomagnetic storm" });
        entries.Add(new List<string>() { "Lomnický štít Observatory", "Pic du Midi Observatory", "Teide Observatory", "Roque de los Muchachos Observatory" });
        entries.Add(new List<string>() { "Lunette Jean Rösch", "CLIMSO coronograph", "Einstein Tower", "GREGOR", "Swedish Solar 1-m Telescope", "European Solar Telescope" });
        entries.Add(new List<string>() { "Solar Orbiter", "Parker Solar Probe", "HINODE",   "SUNRISE", "SOHO" });
        entries.Add(new List<string>() { "Types of solar telescopes", "Primary mirror", "Secondary mirror", "Heat rejecter", "Optical transfer system", "Building", "Dome", "Coelostat" });
        entries.Add(new List<string>() { "Wavelength", "Beam splitter", "Intereference filters", "Polarization of light", "Spectral lines" });
        entries.Add(new List<string>() { "CCD camera", "Spectrograph", "Polarimeter", "Coronograph" });
        entries.Add(new List<string>() { "Getting rid of heat", "Seeing", "Minimising seeing", "Adaptive optics", "Spectroscopy", "Spectropolarimetry", "Measuring solar magnetic fields", "Magnetogram", "Common chromospheric lines", "Common photospheric lines", "Halpha line" });

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
        _credits.Add(new List<string>() { "Lunette Jean Rösch", "CLIMSO coronograph", "Einstein Tower", "GREGOR", "Swedish Solar 1-m Telescope", "European Solar Telescope" });
        _credits.Add(new List<string>() { "Solar Orbiter", "Parker Solar Probe", "HINODE", "SUNRISE", "SOHO" });
        _credits.Add(new List<string>() { "Types of solar telescopes", "Primary mirror", "Secondary mirror", "Heat rejecter", "Optical transfer system", "Building", "Dome", "Coelostat" });
        _credits.Add(new List<string>() { "Wavelength", "Beam splitter", "Intereference filters", "Polarization of light", "Spectral lines" });
        _credits.Add(new List<string>() { "CCD camera", "Spectrograph", "Polarimeter", "Coronograph" });
        _credits.Add(new List<string>() { "Getting rid of heat", "Seeing", "Minimising seeing", "Adaptive optics", "Spectroscopy", "Spectropolarimetry", "Measuring solar magnetic fields", "Magnetogram", "Common chromospheric lines", "Common photospheric lines", "Halpha line" });


        _contents = new List<List<string>>();
        _contents.Add(new List<string>(){
            "The core is the deepest region of the Sun. It covers from the center up to 0.25 radius of the Sun (The radius of the Sun is about 696340 km). In the core you can find a very dense hot plasma, it is the hottest zone of the Sun with a temperature of around 15º million C. It is not possible to observe directly the solar interior.\nIn the core, nuclear fusion takes place and transforms the Hydrogen into Helium. This reaction is called the proton-proton chain reaction. The nuclear fuel produced during nuclear fusion can last up to 10<sup>10</sup> years.",
            "The radiative zone is a region of the solar interior. The temperature of the bottom part is close to 7º million C and the upper part is around 2º million C. In this zone of the Sun, the energy is transported outwards to the solar surface by radiation. The energy travels in form of electromagnetic radiation. In the radiative zone, the density of the plasma is very high. Due to the high density, the particles only can travel short distances before they interact with other particles or they are absorbed. A fun fact is that the average time for a particle to travel from the core, through the radiative zone up to the solar surface is about 171000 years.",
            "The outermost layer of the solar interior is the convection zone, which extends from the tachocline up to the visible surface of the Sun (from approximately 70% to 100% of the solar radius). The bottom region of this layer has a temperature close to 2 million degrees.  Energy is transported by convection, which is a way of distributing heat or energy via circular motions from the lower layers of the Sun (where the plasma is hotter) to the surface (where it is cooler). A similar process occurs in a pot of boiling water.",
            "The outset-most layer of the solar interior is the convection zone, just above the radiative zone, and it extends to the visible surface of the Sun. The bottom region of the convection zone has a temperature close to 2º million C. The lowest temperature allows the atoms to be partially ionized. Therefore, heavy ions such as calcium, iron, nitrogen, carbon, or oxygen can have some of their electrons. In this region, the opacity increases and leads out to convective motions. Convection is a way to transport heat or energy via circular current from the lower layers of the Sun, where the plasma is hotter, to the surface, which is cooler. The hottest plasma ascends while the coolest plasma descends. A similar process develops in a pot of boiling water.",
        });
        _contents.Add(new List<string>()
        {
            "The name of the photosphere comes from Ancient Greek, and means ‘light sphere’. It is part of the lowest layer of the solar atmosphere. The thick of this layer is about 500 km, very thin if you compare it with the radius of the Sun. The mean temperature of the photosphere is 5770 K. This means, that the Sun will emit most of the energy in the visible range, but also emits in the infrared and other wavelengths. Did you ever think about why the human eye is capable to see in the visible range?\nThanks to Isaac Newton and his experiment with a prism in 1665, we can study the solar radiative in different colors. A very wide kind of features can be observed on the photosphere, such as the granulation, the bright faculae, or the magnetic dark features like pores or sunspots",
            "The chromosphere is an irregular layer placed just between the photosphere and the transition region. Its name means ‘sphere of color’. The temperature of the chromosphere raises with height with a range of temperature between 6000º up to 20000 º C. The thick of the chromosphere is about 2000 km.\nWe can observe the chromosphere during a solar eclipse or the light of spectral lines formed within this solar layer. The chromospheric structures are very dynamic and are constantly changing. This solar region is magnetically dominated and the solar features that are more commonly observed are the chromospheric network of the magnetic field elements formed on the solar surface, dark plage close to sunspots, or filaments when observed or the solar disk or prominences at the limb. A big magnetic activity event in the chromosphere can be seen during solar flares or filament eruptions.",
            "The transition region is an irregular and very thin layer of the solar atmosphere situated between the chromosphere and the corona. The temperature rapidly increases with high from 20000º C up to 1º million C.\nThe typical ions that we can find in the transition region are S IV, O IV, or C IV among others. Each of them does not have three of their electrons. They are ionized. The predominant emission light of the ions formed in this region is mainly ultraviolet light. The Earth is very well protected against ultraviolet radiation and most of it is repelled by the atmosphere of the Earth.Because of this, we have to observe the ultraviolet light from space.The typical features that you can observe in the transition region are dark such as prominences.",
            "The solar corona is the outermost layer of the solar atmosphere, it is extremely hot. The temperature is around 1-2º million C and can be higher with regions associated with sunspots. This means that the hydrogen gas can be fully ionized (without electrons) and emit in X-rays, extreme ultraviolet, and radio radiation. Forbidden ions on Earth can be formed in the corona, such as Fe XIV or Ca XVI.\nThe corona can be observed from Earth during a total eclipse of the Sun. It looks like a white ‘crown’ enclosing the Sun. Its shape usually depends on the solar activity cycle. When the solar activity is close to its maximum, the shape is symmetric. When it is close to a solar minimum, the shape is elongated near the solar equator. The typical features observed are plumes, streamers, or magnetic loops.",
        });
        _contents.Add(new List<string>()
        {
            "The solar magnetic field is generated by motion and the dynamics of conductive plasma generated in the solar interior. These motions are generated through convection, transporting the energy due to the movement of the solar plasma. This means that the flows of electrically charged ions and electrons produce the magnetic fields in the Sun. Magnetic active regions on the solar surface containing pores or sunspots are zones where the magnetic field is very extreme. Thanks to the solar observations we know there is a sunspot cycle where the number and the size of it, increase or decrease over time. This cycle is the consequence of the recycling of magnetic fields by the flow of the plasma in the solar interior.\nThe key to understanding the processes that take place in the Sun is magnetism. Magnetic fields are present in all the solar features observed on the solar surface and above.",
            "Scientist believe that solar dynamo is a physical process that generates the magnetic field in the solar interior. The Sun’s interior acts as an electric generator producing electric current and magnetic fields. The dynamo transforms kinetic energy into electric magnetic energy. The exact dynamo mechanisms that are taking place in the solar interior and the transport or energy is not fully understood and it is in continued research.\nWe observe the variations produced by the solar magnetic field related to the quasi-periodic 11 years sunspot cycle. The number and size of the sunspots decrease or increase. Other observations related to the solar dynamo research are, for example, Joy’s law where the tilt of the sunspot groups changes, the latitude of the sunspots changes(butterfly diagram), the reversal of the polar magnetic field close to the maximum of the solar cycle, or the 22 - year magnetic cycle(Hales’s law).",
        });
        _contents.Add(new List<string>()
        {
            "The Sun is a spectral type G2V star placed at the center of the Solar System. The Sun radius is about 696340 km. This means that the diameter of the Sun is around 1,39 million km, 109 times the diameter of the Earth. The mass of the Sun is around 1988500 x 1024 kg, 333000 times more than the Earth. The Sun contains 99.86% of the total mass of the Solar System. The volume and the mean density are 1412000 x 1012 km3 and 1408 kg/m3 respectively. The solar-Earth medium distance is around 149.6 x 106 km. The age of the Sun is about 4.6 billion years. Because of the mass of the Sun, the surface gravity is about 274 m/s<sup>2</sup>. The temperature of the core of the Sun is 15 million K, decreasing down to 5700 k in the photosphere and increasing up to 2 million K or more at the corona.",
            "The chemical composition of the Sun is mainly Hydrogen (H) and Helium (He). Approximately there is about 71-75% is made of H and around 24-27% is He. A very small percentage of the Sun is made of heavy elements (called metals) such as iron, silicon, carbon, oxygen, nitrogen, magnesium, sulfur, etc.\nSince the Sun formed, the Sun started to fuse H into He. The Sun’s core composition amount of He change from 24% to 60% due to the fusion processes during the life of the Sun (4.6 billion years). The core of the Sun fuses 600 million tons of Hydrogen into Helium every second. During the process, 4 million tons of matter are converted into energy every second. The mean energy production is 0.1925 x 10<sup>-3</sup> J/kg s."
        });
        _contents.Add(new List<string>()
        {
            "An active region is a region in the Sun’s atmosphere which has a strong and complex magnetic field. Almost always this magnetic field presents two different polarities, positive and negative. In these areas, magnetic fields from the interior of the Sun emerge through the photosphere into the chromosphere and the corona. Usually, the two polarities grow rapidly and separate from each other.\nSunspots are often visible in them, as well as faculae, bright points, prominences, and filaments to mention a few. Active regions can be the source of violent eruptions such as coronal mass ejections and solar flares. The number and location of active regions on the solar surface at any given time is dependent on the solar cycle. They can be as small as few thousand km and as big as 150000 km. And they even get names, such as NOAA 11158, for example.",
            "Sunspots are areas in the photosphere of the Sun that appear darker than the surroundings. They appear darker because they are cooler (can be up to 2000 C cooler) than the quiet Sun. In sunspots, the process of convection is altered by the presence of strong magnetic fields, which do not allow the bubbles of hot gas coming from the interior of the Sun to emerge normally. \nSunspots have a darker inner area called umbra, and an outer brighter ring named penumbra with a very filamentary appearance. While the umbra has strong vertical magnetic fields, the penumbra has weaker fields which bend until they are nearly horizontal. They can be observed in many different sizes and shapes, from round to elongated, and from a size of a few thousand km to monster sunspots of up to 100000 km of diameter. They can last from only a few days to several months.",
            "The umbra is the darker central part of a sunspot, where magnetic fields are stronger and vertical. These magnetic fields can reach 4000 G and the temperatures vary between 3000 and 4500 C. In spite of the strong fields, some convective motions manage to happen in the umbra. Such phenomena can be observed in the shape of umbral dots or amazing structures called light bridges. Both phenomena are intrusions of convective gas into the magnetic field of the umbra.",
            "The penumbra is the outer ring of a sunspot and surrounds the darker umbra. The temperature in the penumbra is about 5500 C (remember that the rest of the photosphere has a temperature of about 5800 C). It is therefore brighter than the umbra. Its magnetic field is around 1000 G and bends until is almost horizontal at the edge of the sunspot. It is characterized by a filamentary aspect.",
            "A pore is a sunspot without a penumbra and are sometimes called “naked” sunspots. A pore appears when a strong magnetic field emerges through the solar surface and stops the convective transport of heat from the solar interior: that is why pores look dark. If the magnetic flux increases, the field would become inclined at the edge of the pore, a penumbra would be developed, and the pore would transform into a sunspot.\nPores are \"small\" (1000 - 6000 km in diameter) but they include small bright structures, which indicate that convection from below is not completely suppressed.",
            "Bright points are very small strong magnetic flux elements that are located on the surface of the Sun between the granules (in the areas called intergranular lanes where the gas moves downwards into the solar interior). They are very small compared to other magnetic features observed in the solar surface, having typically less than 300 km in diameter. They are observed as bright features, often come in chains of many points and are very dynamical, even presenting swirling motions. And they can be found anywhere in the solar surface. \nThey represent features with intense magnetic fields (of about 1000-2000 G). They appear bright in intensity because they are less dense than the surroundings, so that we observe deeper into the solar atmosphere where the temperature is higher.",
            "The solar photosphere shows a grainy pattern which is due to convective motions of the gas on the solar surface. Convection is a very efficient way to transport heat from the subsurface layers of the Sun, which are hot, to the surface, which is cooler. The same process happens in a pot of boiling water in the kitchen.\nBright granules are convective cells formed by hot gas that rises in the atmosphere and releases its heat before sinking back to the surface through the darker lanes observed at the borders of the granules (the so-called intergranular lanes).\nGranules occur in a variety of sizes and shapes on the solar surface. Their average diameter is 1500-2000 km. They are very dynamic and have lifetimes of 5 to 10 minutes. At any time, the solar surface is covered by about 4 million granules."
        });

        _contents.Add(new List<string>()
        {
            "Spicules are thin, elongated jets a few hundred kilometers wide. They were discovered in 1877 by Father Angelo Secchi of the Observatory of Roman Collegium in Rome, but scientists are still debating their origin.\nAt any one time more than 100,000 spicules are present in the solar atmosphere. They pepper the entire surface of the Sun just above the photosphere and can reach a maximum height of 10,000 km at the top of the chromosphere. They can move at speeds of more than 100 km/s. These structures are found all over the solar surface, but can be observed most easily near the limb of the Sun.\nThey live only for some minutes and have a swaying and torsional motion.They are believed to transfer mass from the chromosphere to the transition region and corona.They loosely follow the magnetic field lines sticking out of the Sun.",
            "Solar filaments or prominences are made out of thin plasma threads located inside of large elongated structures in the chromosphere and corona of the Sun. Both terms refer to the same phenomena, but receive different names depending on where they are observed on the Sun.\nOn the solar disk, they are called filaments, while above the solar limb, they are called prominences. They are best seen using an H-alpha filter, visible even with amateur telescopes, and resemble dark clouds which lie in the upper atmosphere, the chromosphere and corona.\nHowever, they are not like clouds on Earth which are mainly made out of water. The filament structure itself is confined due to the magnetic field lines.Their lifetime is of few days to several weeks and their formation process is still not well understood.",
        });


        _contents.Add(new List<string>()
        {
            "Coronal loops are bright, curving structures that appear as arcs above the Sun's surface. Hot electrified gas called plasma causes these loops to glow, as the plasma flows along the curving lines of powerful magnetic fields, giving the coronal loops their characteristic shapes.\nCoronal loops are often, but not always, associated with sunspots. They can be \"rooted\" in sunspots, arcing between pairs of sunspots with opposite magnetic poles. Coronal loops come in many sizes, with the largest extending upwards many thousands of kilometers above the Sun’s surface into the solar corona, the Sun's upper atmosphere.\nSome loops are extremely hot, having temperatures well above a million degrees Kelvin.",
            "The hot solar corona hosts large amounts of cool and dense material called coronal rain. This spectacular phenomenon is seen as cool material seemingly appearing out of nowhere and streaming down along coronal loops - think of it like snowflakes in the oven! It occurs when hot plasma in the solar corona cools and condenses in strong magnetic fields, usually associated with regions that produce solar flares. The plasma is attracted to the magnetic fields where it condenses and slowly falls back to the Sun’s surface.\nMany mysteries still surround this phenomenon, for example we don’t know why it is so clumpy and stranded in structure.These and many other important questions make coronal rain a prime target for next generation instrumentation such as the European Solar Telescope.",
        });
        _contents.Add(new List<string>()
        {
            "Flares are our solar system’s largest explosive events, releasing the equivalent amount of energy of the entire Earth’s power consumption in a year! A solar flare is an intense burst of radiation coming from the release of magnetic energy associated with sunspots. They are seen as bright areas on the Sun and they can last from minutes to hours. We typically see a solar flare by the photons (or light) it releases, at most every wavelength of the electromagnetic spectrum.\nFlares can cause space weather impacts at Earth such as disruptions to radio communication (particularly high frequency) and GPS navigation systems, which is due to changes occurring in the ionosphere.",
            "The outer solar atmosphere, the corona, is structured by strong magnetic fields. Where these fields are closed, often above groups of sunspots, the confined solar atmosphere can suddenly and violently release bubbles of gas and magnetic fields called coronal mass ejections (CMEs). A large CME can contain a billion tons of matter (plasma) that can be accelerated to several thousands of kilometres per second in a spectacular explosion. This solar material streams out through the solar system, impacting any planet or spacecraft in its path. CMEs are sometimes associated with solar flares but can occur independently.\nIf directed at Earth CMEs can cause geomagnetic storms that can disrupt our power grids. CMEs can travel speeds of hundreds or thousands of kilometers per second, and very fast CMEs could take around 18 hours to a day to arrive at Earth.",
            "The solar wind is a continuous flow of electrically charged particles (plasma) from the Sun’s outer atmosphere (corona). Its particles can escape the Sun's gravity because of their high energy resulting from the high temperature of the corona, which in turn is a result of the coronal magnetic field. The solar wind reaches speeds of hundreds of kilometers per second as it travels out through the solar system in a spiral like fashion due to the rotation of the Sun.\nEmitted in all directions, some of the solar wind is constantly buffeting our planet, causing beautiful displays known as the aurora in the upper atmosphere at high latitudes near the magnetic poles.",
            "Solar energetic particles (SEPs) are high-energy particles, such as protons and electrons, that are ejected from the Sun. They originate from either a solar flare site or by shock waves associated with CMEs. They travel at very high speeds - fractions of the speed of light - and can travel from the Sun to the Earth in tens of minutes. \nSEPs are a radiation hazard for spacecraft, astronauts, and airline passengers flying over the poles.They can also cause damage to electronics and detectors on spacecraft in orbit if not properly protected.",
            "Auroras are the most visible effect of the sun's activity on the Earth's atmosphere, natural displays of light in the sky that can be seen with the unaided eye at night. An auroral display in the Northern Hemisphere is called the aurora borealis or Northern Lights, and in the Southern Hemisphere is the aurora australis or Southern Lights.\nAuroras particles from the solar wind and CMEs stream down Earth’s magnetic fields lines toward the magnetic poles. Energy is released when the charged particles strike atoms and molecules in the atmosphere and some of this energy appears in the form of auroras.\nThe most common color in an aurora is green, but displays that occur extremely high in the sky may be red or purple. Most auroras occur about 50 to 200 miles above the Earth, and some extend lengthwise across the sky for thousands of miles.",
            "The Earth's magnetosphere is created by our magnetic field and protects us from most of the particles the sun emits. When a CME or high-speed solar wind stream arrives at Earth it hits the magnetosphere, and if the arriving solar magnetic field is directed southward it interacts strongly with the oppositely oriented magnetic field of the Earth in the form of a geomagnetic storm. The Earth's magnetic field is then peeled open like an onion allowing energetic solar wind particles to stream down the field lines to hit the atmosphere over the poles (often causing auroral displays). At the Earth's surface a magnetic storm is seen as a rapid drop in the Earth's magnetic field strength."
        });
        _contents.Add(new List<string>()
        {
            "Location: Tatranská Lomnica, Slovakia\nThe Lomnický Štít Observatory is located on top of the second-highest peak of The High Tatras mountains. It was built in the period 1957-1962. The observatory is equipped with a special type of astronomical telescope called coronagraphs. Such instruments allow observing the upper part of the solar atmosphere, the corona, by creating an artificial eclipse.\nThe measurements have mainly been used to monitor the changes in the solar coronal activity. In 2011 and 2016, two new detectors (Comp-s and SCD) were installed on the coronagraphs. Both instruments use a tunable filter with a polarimeter, which allows to observe coronal and chromospheric structures.\nPic du Midi Observatory\nLocation: Pic du Midi, France\nThe Pic du Midi Observatory is located in the Pyrenees mountains, at 2870m altitude. The scientific adventure at Pic du Midi started around 1870, first just as a meteorological observatory.\nIn the 1930s, Bernard Lyot built the first coronagraph and started making the first pictures, then movies, of solar prominences and the corona. The solar corona was seen out of an eclipse at Pic du Midi for the first time.\nAfter the 2nd World War, the Turret telescope, later called Jean Rösch, was built.This instrument provided the best images of the solar photosphere for years and the first clear picture of solar convection.\n150 years later, the Pic du Midi observatory keeps observing the Sun with CLIMSO, a set of coronagraphs that keeps our star under surveillance.",
            "Location: Pic du Midi, France\nThe Pic du Midi Observatory is located in the Pyrenees mountains, at 2870m altitude. The scientific adventure at Pic du Midi started around 1870, first just as a meteorological observatory.\nIn the 1930s, Bernard Lyot built the first coronagraph and started making the first pictures, then movies, of solar prominences and the corona. The solar corona was seen out of an eclipse at Pic du Midi for the first time.\nAfter the 2nd World War, the Turret telescope, later called Jean Rösch, was built.This instrument provided the best images of the solar photosphere for years and the first clear picture of solar convection.\n150 years later, the Pic du Midi observatory keeps observing the Sun with CLIMSO, a set of coronagraphs that keeps our star under surveillance.",
            "Teide Observatory is dedicated mainly to the study of the Sun. The excellent sky conditions for astronomy occurring there are the result of its geographical location on an island in the middle of the Atlantic Ocean and the influence of the trade winds.\nThe Observatory hosts some of the best European solar telescopes: GREGOR (see the “Ground-based-telescopes” section for more information), the Vacuum Tower Telescope(VTT) or THÉMIS; besides the Solar Laboratory “Pirámide”, that contains several instruments to study the Sun's interior through helioseismology.\nIn 1979, Teide Observatory became the birthplace of helioseismology, a technique that provides us with an insight into the interior of our star through the study of its internal and surface vibrations.\nTeide Observatory also hosts other instruments, including standard night-time telescopes, robotic and remotely operated telescopes, and experiments to measure the cosmic microwave background radiation.With their help, the most important comets of recent years have been monitored, including the collision of comet P/Shoemaker-Levy with Jupiter, and large-scale maps of the Galactic centre have been compiled.",
            "Location: La Palma, Spain\nRoque de los Muchachos Observatory (ORM) is one of the largest telescope arrays in the world. It stands on the rim of the Caldera de Taburiente National Park (Canary Islands, Spain). The observations carried out at ORM for decades have confirmed this site as one of the best locations in the world for solar observations. \nThe ORM hosts two solar telescopes, the Swedish 1 - m Solar Telescope(SST)(see the “Ground - based - telescopes” section for more information) and the Dutch Open Telescope(DOT).For its outstanding characteristics, ORM has been designed as the final location to build the European Solar Telescope.\nThe observatory also hosts the Gran Telescopio Canarias, the largest optical-infrared telescope in the world with a 10.4m primary mirror, along with twenty other telescopes and instruments for various kinds of studies, including night - time observations, robotic observations, and high energy astrophysics.Important advances in the study of the Universe have been made with these telescopes, ranging from the detection of the most distant galaxy to confirmation of the existence of black holes and the accelerated expansion of the Universe.",
        });
        _contents.Add(new List<string>()
        {
            "Location: Observatoire du Pic de Midi. French Pyrenees. France\nThis telescope was built right after the 2nd World War by Jean Rösch to take advantage of the pristine conditions for solar observations at Pic du Midi.It is made of just one lens of 40 cm in diameter mounted on a tube, which stands out beyond the main building.Inside the dome, photographic films or astronomical instrumentation are placed at the focus of the lens.\nThe dome and the tube are closed, resembling a tank turret.This structure was designed to protect the telescope and to avoid the deterioration that classic domes cause in the quality of the images.\nIt was the first telescope to clearly show solar Granulation, and the Bright Points in intergranular lanes, unveiling the convection and the presence of magnetic fields in the Sun.After 50 years of observations, the telescope stopped its scientific work, and nowadays it is used for student practice.",
            "Location: Observatoire du Pic de Midi. French Pyrenees. France\nCLIMSO is a suite of solar telescopes installed at Pic du Midi observatory. In the late 90s was purchased by an association of amateur astronomers, but nowadays it is dedicated to the continuous surveillance of the Sun.\nIt consists of four main instruments. Two of them are telescopes of the refractor type. They take full images of the solar disk and allow for views of the mid and the low chromosphere.These telescopes are used to locate solar filaments and magnetically active zones in the Sun.\nIn addition, CLIMSO counts on two coronographs.They are instruments that create artificial solar eclipses to observe the corona and the prominences.With a diameter of 20 cm, CLIMSO’s coronagraphs are some of the largest ones in operation in the world.\nCLIMSO data are freely available through a virtual solar observatory, covering well over one complete solar cycle.",
            "Location: Potsdam, Germany\nThe Einstein Tower was the first solar tower telescope constructed in Europe in the early 1920s. It was built to demonstrate an Einstein’s theory, detecting the “gravitational redshift”, but with no success.\nThe building features an inner wooden tower which supports the telescope lens and the coelostat on its top, while the mechanically detached, solid outer tower supports the dome and provides shielding from wind forces.A folding flat mirror directs the sunlight towards the spectrograph in the basement of the building.The basement is underground and provides a stable environment for high - precision measurements of the light.\nFor many years, the Einstein Tower was used to perform observations of magnetic fields in sunspots.One of the major findings was the discovery of so - called delta spots(sunspots with opposite polarities inside one penumbra) by Künzel in the 1960s.This telescope is still operational and is used to test new spectropolarimetric instrumentation.",
            "Location: Observatorio del Teide, Tenerife, Spain\nGREGOR is Europe's largest solar telescope. It started scientific operations in 2014. With a primary mirror of 1.5 meters of diameter, GREGOR is an open telescope with a fully retractable dome. This allows to avoid disturbances in the observations caused by the excess of heating. In this way, the natural air flow cools the telescope structure without introducing turbulence and vibrations, which would decrease the image quality significantly.\nAtmospheric turbulence does also alter the observations, so its effects are compensated by “GAOS”, the GREGOR adaptive optics system. The function of an adaptive optics system is to measure and correct the aberrations introduced by the atmosphere in real time.\nGREGOR collects data from the photosphere and the overlying chromosphere. It can see structures of about 50 km on the solar surface. Data gathered by GREGOR let the solar astronomers to measure magnetic fields and gas motions in the Sun with high precision.",
            "Location: Observatorio del Roque de los Muchachos, Spain\nThe Swedish 1-m Solar Telescope (SST) is located on the island of La Palma, and it started operations in 2002. It is mounted in a tall tower, and is a refractor telescope, so the main optical element is not a mirror, but a 1m diameter lens.\nThe SST is a vacuum telescope which means that air is pumped out of its tube. This avoids heated air in the light path that would destroy the image quality. It is the first solar telescope to reach a spatial resolution of 0.1 arcseconds. That means that it can see things as small as 70 kilometres on the Sun. This immediately allowed scientists to discover new structures in sunspots.\nSince then, the SST has been equipped with more advanced instruments that make images of the Sun in different wavelengths and also measure the polarization of sunlight. In that way, it is possible to determine temperatures, velocities, and magnetic fields in the solar atmosphere.",
            "The European Solar Telescope (EST) is a next generation large-aperture solar telescope. It will be located in the Roque de los Muchachos Observatory, at the island of La Palma (Canary Islands, Spain), a first-class site for astronomical observations.\nWith a 4.2-metre primary mirror, EST will be the largest ground-based infrastructure for solar observation in Europe.Its main objective is to study the magnetic and dynamic coupling of the solar atmosphere.It will specialise in high spatial and temporal resolution, using several spectroscopic and spectropolarimetric instruments simultaneously to produce 2D spectral information. This will allow diagnostics of the thermal, dynamic and magnetic properties of the solar plasma over many scale heights.\nThe EST project is promoted by the European Association for Solar Telescopes, which is formed by 26 research institutions from 18 European countries.EST was included in the ESFRI Roadmap in 2016 and is therefore considered a strategic European research infrastructure.Construction is planned for 2024, after the end of the preparatory work currently being carried out."
        });
        _contents.Add(new List<string>()
        {
            "Solar Orbiter is an ESA mission in collaboration with NASA, launched on 10 February 2020 from Cape Canaveral (Florida, USA). It is a complex scientific laboratory that takes images of the Sun from closer than any spacecraft before and, for the first time, will look at the uncharted solar polar regions.\nSolar Orbiter combines six remote sensing instruments and four in-situ instruments. They will study the Sun and the heliosphere as a complex system where all the phenomena taking place in the interplanetary medium have their origin in our star.\nThanks to Solar Orbiter, scientists hope to find answers to questions like what drives the Sun’s 11-year cycle, what heats the solar corona to millions of degrees Celsius, what generates the solar wind, and why it accelerates to speeds of hundreds of kilometres per second, or how does it all affect our planet.",
            "Parker Solar Probe is the NASA's mission launched on August 12, 2018, to improve the understanding of the Sun. It travels through the Sun’s atmosphere, closer to the surface than any spacecraft before it, facing hard heat and radiation conditions to provide the closest-ever observations of a star.\nThe spacecraft uses Venus’ gravity during seven flybys over nearly seven years to gradually bring its orbit closer to the Sun. The spacecraft will fly through the Sun’s atmosphere as close as 6 million km to our star’s surface, well within the orbit of Mercury and more than seven times closer than any spacecraft has come before.\nParker Solar Probe employs a combination of in situ measurements and imaging to study the corona in the hope of expanding our knowledge of the origin and evolution of the solar wind. It will also make critical contributions to our ability to forecast changes in Earth's space environment that affect life and technology on Earth.",
            "Hinode is a Japanese space mission launched on September 23, 2006, and developed by ISAS/JAXA, collaborating with the National Astronomical Observatory of Japan (NAOJ), NASA, and Science and Technology Facilities Council (UK), to study the Sun. It follows a Sun-synchronous orbit around Earth at an altitude of 650 km. The orbit allows Hinode to observe the Sun continuously for nine months at a time.\nHinode explores the magnetic fields of the Sun to improve understanding of what powers the solar atmosphere and drives solar eruptions. Hinode’s Solar Optical Telescope is the first space-borne instrument to measure the strength and direction of the Sun’s magnetic field on the Sun’s surface, the photosphere.\nCombined with two other instruments, the EUV imaging spectrometer (EIS) and the X-ray/EUV telescope (XRT), the mission is designed to understand the causes of eruptions in the solar atmosphere and relate those eruptions to the intense heating of the corona and the mechanisms that drive the constant outflow of solar radiation, the solar wind.",
            "SUNRISE balloon-borne observatory is a mission developed by a German-Spanish-American consortium led by Max-Planck Institute for Solar System Research (MPS).\nThe first two flights of SUNRISE took place in June 2009 and June 2013 from Kiruna (Sweden) to the northern coast of Canada with an approximate duration of five and a half days each. The observatory carried two post-focal instruments: a UV camera and an imaging spectropolarimeter.\nWith its aperture of 1 meter and nearly 25 meters focal length, the SUNRISE telescope uses innovative mirror technologies, active in-flight alignment, and image stabilization systems. Thanks to its high spatial resolution, the telescope is capable of resolving structures smaller than 100 km on the solar surface.\nThe third edition of the mission is being prepared for June 2022 and includes Japanese contributions.While keeping the basics of the telescope and the instrument platform, SUNRISE will be provided with a new gondola system and three new post- focal instruments: two slit - spectrograph - based and one filtergraph - based spectropolarimeter working at UV, IR, and visible wavelengths.",
            "The Solar & Heliospheric Observatory (SOHO), is a project of international collaboration between ESA and NASA to study the Sun from its deep core to the outer corona and the solar wind.\nSOHO was launched on December 2, 1995. The twelve instruments on board were provided by European and American scientists to answer several fundamental questions about the Sun. For example: what is the structure and dynamics of the solar interior; why does the solar corona exist, and how is it heated to the extremely high temperature of about 1 000 000°C; or where is the solar wind produced and how is it accelerated.\nThe spacecraft moves around the Sun in step with the Earth by slowly orbiting around the First Lagrangian Point(L1), where the combined gravity of the Earth and Sun keep SOHO in an orbit locked to the Earth-Sun line.The L1 point is approximately 1.5 million kilometres away from Earth, in the direction of the Sun.There, SOHO enjoys an uninterrupted view of our daylight star."
        });
        _contents.Add(new List<string>()
        {
            "Telescopes are optical instruments used to observe distant astronomical objects. They were invented in the 17th century. There are two types of telescopes: refracting and reflecting telescopes. Refracting telescopes use lenses to collect and focus the light, forming an image of the object, while reflecting telescopes use mirrors.\nIt is relatively easy to build large mirrors of high optical quality, so the largest solar telescopes currently in operation are reflecting telescopes. Examples include the 1.5 metre GREGOR telescope (Tenerife, Spain), the 4 metre Daniel K. Inouye Telescope (Maui, USA), and the future 4 metre European Solar Telescope (La Palma, Spain).\nRefracting telescopes tend to be smaller, but they provide excellent image quality because of their simpler design and the lack of any central obscuration. A good example of this type of telescopes is the 1 metre Swedish Solar Telescope (La Palma, Spain), which has the largest lens in operation in the world.",
            "The first mirror (M1) of a reflecting telescope is called the primary mirror. The larger it is, the more light it collects and the higher the resolving power of the telescope is. In solar observations it is important to have as much light as possible, to be able to take images of the Sun at high speed and to observe very weak signals more easily. \nM1 is curved and sends the light to the secondary mirror. This is a critical element of a solar telescope. It must have very good optical quality and must remain at the same temperature as the surrounding air, to avoid turbulence and image degradation. For that reason, it usually has a dedicated cooling system. Also, the primary mirror must keep its shape independently of the telescope pointing. This is achieved with mechanical actuators that compensate the gravitational deformations of the mirror.\nThe European Solar Telescope will have a 4.2 m primary mirror with a central hole of 800 m in diameter and a total weight of 2400 kilograms.",
            "The secondary mirror (M2) of a reflecting telescope is the second mirror encountered by the light. It can be a curved or a flat mirror, supported by a spider at the end of the telescope tube.\nM2 is smaller and can be moved more easily than the primary mirror. For that reason, it is used to set the telescope focus.\nThe European Solar Telescope will have an active secondary mirror of 800 mm in diameter. It will be used not only to focus but also to correct the image motion caused by wind shaking and the image blurring caused by air turbulence.",
            "The primary mirror of a solar telescope concentrates the sunlight in the prime focus, a very narrow area which receives a huge energy flux and therefore would be heated to extremely high temperatures. To prevent overheating of the telescope structure and the surrounding air, a special device called heat rejecter is used.\nHeat rejecters are flat mirrors inclined 45 degrees with respect to the light beam that are placed at the position of the prime focus. A small central hole allows the light corresponding to the desired field of view to go through, while the rest is reflected by the mirror, thus eliminating excess energy.\nThe heat rejecter removes most of the unwanted energy, but not all.The mirror absorbs one percent of the light and gets heated.For that reason, heat rejecters have dedicated cooling systems based on liquid coolants or air.",
            "The light follows a complicated path inside a solar telescope. It is collected by the primary mirror and sent to the secondary mirror, which reflects it back to the primary mirror. It is then picked by the third mirror, or M3, which can be placed in front or behind the primary mirror. Usually, M3 reflects the light out of the telescope, along the elevation axis. A system of mirrors then transfers the light to the interior of the building, until it reaches the optical labs where the instruments are located.\nThe optical transfer system consists of M3 and all the other mirrors or lenses used to send the light to the instruments. Each mirror receives an individual number next to the letter M. In the case of the European Solar Telescope, it will have 4 mirrors and two lenses in a vacuum tank. These four mirrors will be part of the Multi-Conjugated Adaptive Optics system of the telescope and will change shape very quickly depending on the atmospheric conditions. In addition, they will be arranged such that they do not introduce instrumental polarization.",
            "Solar telescopes are placed atop high towers to avoid heating from the ground, which destroys the image quality. Far from the ground, open telescopes are also exposed to the wind flow, which helps maintain the telescope at the ambient temperature and prevents image degradation.\nThe building supports the telescope structure and the dome, and houses the optical transfer system and the instrument rooms. Solar telescopes have large focal lengths to produce highly amplified images of the solar surface. Having a tower helps accommodate such long focal distances.\nIn the case of the European Solar Telescope, the height of the building will be 44 meters with the dome closed and the primary mirror will be located 38 meters above the ground.",
            "The dome protects the telescope during the night, bad weather conditions and maintenance periods. It must withstand harsh environmental conditions.\nClassical domes are closed, having only a small aperture through which sunlight can enter the telescope. They protect the telescope from unwanted vibrations caused by the wind. They also minimise heating and turbulence within the dome, preventing image blurring. Some domes are isolated from the exterior with a glass window to keep the air inside at constant temperature.\nDomes can also be open. Made of a special fabric, they are fully retractable, leaving the telescope and the mirror exposed to the air. This is the best solution to maintain the telescope structure and mirrors at ambient temperature. The normal air flow through the telescope removes heat and minimises turbulence.\nThe first solar telescope with an open dome was the Dutch Open Telescope on La Palma (Spain). The European Solar Telescope will also have an open dome to deliver the best image quality possible.",
            "Coelostats are devices used to collect sunlight and send it to the interior of a solar tower by means of two mirrors. The first mirror follows the Sun during the day with the help of a motor and reflects the light to the second mirror, which is mounted on a pillar and does not move. The second mirror is responsible for directing the light inside the building. Coelostats provide a simple way to feed solar instruments. They can be found in both large and small telescopes. Examples include the German Vacuum Tower Telescope (VTT, Tenerife, Spain), the Einstein Tower (Potsdam, Germany) and the spectroheliograph of the Astronomical and Geophysical Observatory of the University of Coimbra (Coimbra, Portugal).",
        });
        _contents.Add(new List<string>()
        {
            "Light is a form of energy. Similar to waves that you would see at the beach, light also travels as a wave. Like ocean waves, light waves have peaks and valleys, and scientists will often refer to something known as the ‘wavelength’ to describe the properties of the light. \nThe wavelength of light is measured as the distance between two points from identical positions in back-to-back waves. For example, we can measure the wavelength of light as the distance from one peak in the wave to the peak of the next wave. Therefore, light with shorter wavelengths will have their peaks and valleys repeated more frequently. Also, light with shorter wavelengths (e.g., gamma rays and x-rays) will have more energy than those at longer wavelengths (e.g., microwaves and radio waves).\nWe can see the effect of different wavelengths of light when looking at visible light as different wavelengths will have different colours. You can see this very clearly when looking at a rainbow, where the red colour is from light at a longer wavelength than the violet light which has a shorter wavelength.\nIn solar physics, the wavelength of the light we are observing is important as it can give us a clue about the region where the light has come from. For example, what the temperature of the region of the Sun is and what elements (e.g., Helium) are present in that region. Wavelength of light is a property of the light that we can measure from the Sun that can be used then to tell us more about the Sun.",
            "A beam splitter is a type of device that splits a beam of light in two. There are various ways to do this, but one of the most common methods is to use a cube made of two triangular prisms. The glass of the cube is chosen to have specific properties that allow part of the light entering the cube to be reflected, while the rest of the light passes through the cube without changing direction.\nIn a telescope, a beam splitter can be used to split incoming light towards different instruments. Special beam splitters can also be used to polarise the light.",
            "Interference filters help us isolate specific wavelengths of light. They consist of multiple thin layers of materials specially chosen to let light through at specific wavelengths while blocking other wavelengths. Using interference filters to look at specific wavelengths allows us to produce images from different regions of the solar atmosphere.\nBy carefully selecting a collection of interference filters for different wavelengths, we can build up images at different heights of the solar atmosphere and observe how certain features on the Sun appear in different layers as well as observe the motion of material between regions in the Sun as well.",
            "Light is a special type of wave, known as an electromagnetic wave. Electromagnetic waves can travel through the vacuum of space. Electromagnetic waves have both electric and magnetic components. Unpolarised light is an electromagnetic wave that vibrates in many different random planes along the direction that the wave is travelling in. When light is polarised, it will only oscillate in one particular plane. Light can be partially polarised when it is scattered by molecules in Earth’s atmosphere. Our eyes cannot detect the difference between polarised and unpolarised light, but we can see its effects in the brightness and colour of clear skies.\nAlso, we can see the effects of polarised light when using a polariser. A polariser is a device that lets light vibrating in a certain plane through while blocking all other directions of vibration.Polarised sunglasses use polarisers to block light and reduce glare. If you took two pairs of polarised sunglasses and rotated one pair with respect to the other while light was passing through, when held at the right angle, all light passing through the sunglasses would be blocked. This is due to the fact that the polarised lens in the first pair of sunglasses polarises the light, so it vibrates only in one plane. Then when you move the second pair, the polarised lens of the second pair will eventually be aligned in the correct direction to block the polarised light completely from the first pair.\nIn solar physics, we can use the polarisation of light to work out the magnetic fields of various magnetic structures on the Sun such as sunspots.",
            "Atoms consist of electrons that orbit a nucleus. Orbiting electrons can be found in different energy levels around the nucleus. When an electron moves from a higher energy level to a lower one some light is emitted. The light emitted has a very specific wavelength depending on the levels that the electron moves between. The light emitted is referred to as a spectral emission line. Likewise, an electron can absorb incoming light and can move from a lower energy level to a higher one, as it has absorbed energy from the incoming light. Again, this absorption corresponds to a specific wavelength of light based on the energy levels that the electron moves between. This is known as a spectral absorption line. Each atom has different energy levels which correspond to different wavelengths. Therefore, spectral lines act as a sort of ‘fingerprint’ for different elements and can allow us to identify elements based on its unique spectrum of lines.\nIn solar physics, spectral lines are used to observe specific regions of the solar atmosphere. Different regions will have different quantities of atoms and different temperatures, which will correspond to different spectral lines. By using an interference filter, we can limit the wavelength of the light that we observe to those of a given spectral line. This allows us to observe the region in the solar atmosphere where this spectral line is formed.Therefore, we can use the spectral line as a method of looking at specific regions of the solar atmosphere. \nWe can gather more information from spectral lines as we know what the expected wavelength of a spectral line is.For example, we can use the concept of a Doppler shift to work out how fast material on the Sun is moving, upwards or downwards, using the spectral line.You can visualise a Doppler shift by considering the sound of ambulance sirens as it passes by. The sound of the ambulance will have a higher pitch as it speeds towards you and then will change to a lower pitch after it has passed.This is due to the change in wavelength of the sound of the siren due to the motion of the ambulance. As it speeds towards you the wave is compressed but after it passes by it stretches out as the ambulance gets further away. On the Sun, a similar phenomenon is observed with spectral lines. If material is moving away from you, the observer, then the wavelength of the spectral line will move to a longer wavelength, which is redder in the colour spectrum(so we refer to it as a ‘red shift’).If the material is moving towards you, the spectral line will have a shorter wavelength and will be bluer than it normally is (so we refer to it as a ‘blue shift’). Therefore, as well as showing us different regions of the solar atmosphere, spectral lines can help us work out how fast material is moving."
        });
        _contents.Add(new List<string>()
        {
            "A CCD camera is a type of digital camera known as a Charge-coupled Device (hence the acronym CCD). Basically, it is an instrument for recording images, that works by converting incoming light to an electric charge which can be read by a computer.\nIf you were to look at the surface of a CCD under a microscope, you would see a series of dot-like structures on a grid. These dots are what’s known as a photodiode and are the device that converts the incoming light to an electrical current. Each dot (or photodiode) is one pixel, which is the smallest unit of the image. You may hear that a CCD or an image has a certain pixel size, this tells you how many photodiodes there are on your sensor. The grid of photodiodes then is used to reproduce the image that has been recorded by the CCD. The grid of photodiodes has their electrical currents quickly read out by the CCD which is passed on to a computer that can save and store the image.\nWhen the electrical current has been read out, the photodiodes are now able to take a new image and, so, we can build up a movie by continuously taking images with the CCD.  When reading out the electrical currents, small errors can be added to the image due to the temperature of the camera (and other factors). Normally we try to correct these errors by taking additional ‘calibration’ images using the CCD. In solar physics, CCD cameras are extremely important in taking images of the Sun and converting it to a digital format that can be read and analysed by a scientist using special computer software.",
            "A spectrograph is an instrument that separates incoming light by its wavelength and then records the resulting spectrum. As each atom has its own spectrum (made up of spectral emission and spectral absorption lines) we can use that to identify atoms that produced the incoming light and therefore determine the chemical composition. A lot of our knowledge on the chemical composition of the universe is through the use of spectrographs.\nThere are several different types of spectrographs, with different designs and methods for splitting the incoming light.A common method uses something known as a diffraction grating.A diffraction grating is an optical component that splits and diffracts(causes a slight bending of the incoming light) into different beams travelling in different directions.Diffraction can be achieved when light passes through glass with a series of ridges or by passing through a device using small, closely spaced slits. The split light is then reflected onto a CCD camera to be read by a computer. Like spectral lines, spectrographs can give us information on the speed of the material on the Sun through Doppler shifts and can be used to give us an idea of the temperature of the region on the Sun.\n",
            "Polarimeters are a device used to measure the direction of polarisation (or polarisation state) of incoming light. Basically, a polarimeter works by using a special filter that only allows light with a specific direction of polarisation through. This is then measured by a CCD camera. In more advanced polarimeters, the direction of polarisation that is allowed by the filter can be varied to allow light with different polarisation states through. This then gives a complete picture of how the incoming light is polarised. \nThe polarisation state of the incoming light is very important for scientists to measure.When studying the Sun, the polarisation of the light can tell scientists about magnetic fields that are present in the Sun.",
            "Light from the Sun appears mostly from a region at the surface known as the photosphere. This light is very intense and the glare from the light obscures the view to other regions of the solar atmosphere. A coronagraph is a device that helps block this light so that it is easier to see light from fainter regions of the solar atmosphere such as the corona (which is where the device gets its name). The corona is a region at the top of the solar atmosphere and extends millions of kilometres into space. The corona is visible during a total solar eclipse. During an eclipse then, the moon acts as a sort of coronagraph, blocking out light from the bright photosphere at the surface of the Sun for the duration that the moon completely covers the Sun. Remember, never look directly at the Sun with the naked eye, as the intense light can permanently damage your eyes.\nMan-made coronagraphs also exist. One possible design is to use a mirror with a hole in it. The desired light from the corona is reflected from the mirror to a CCD camera, but the unwanted light passes through hole in the mirror. The solar corona is a very important region of the Sun for scientists as we do not fully understand it.Coronagraphs then are one possible method for us to study the corona.",
        });
        _contents.Add(new List<string>()
        {
            "The Sun is our main source of heat on the planet and assures humans a habitable environment on Earth. However, when pointing a telescope to the Sun, all the collected light concentrates on the primary focus of the telescope. Part of that light falls outside of the field of view recorded by the cameras. \nThe excess of light produces heat of up to 2000 Watt for the EST. This negatively affects the image quality of the telescope.Therefore, the telescope needs a cooling system to get rid of the accumulated heat.The engineers of the EST are currently exploring new ways to get rid of the heat.",
            "The light, which comes from the Sun, has a long journey until it reaches a solar telescope on Earth. While in space, the light travels relatively undisturbed. However, once it reaches the Earth’s atmosphere, it suffers certain distortions due to its interaction with turbulent air flows in the sky. As a consequence, the image quality at the telescope gets worse resulting in blurry images. One solution to this problem is the use of an Adaptive Optics system.",
            "There are several ways to minimise the seeing effects and therefore enhance the image quality during the observations with the telescope. Solar telescopes are always mounted on top of high buildings, far away from the ground which gets heated by solar radiation. In addition, buildings, the telescope itself and the surroundings of the building are painted in white, to avoid absorption of the heat from the Sun. Heat produces turbulence in the air, which adds blurring effects to the images recorded by the telescope. Often telescopes have domes which can be pulled back to assure stable air flows through the telescope. When using closed domes, the interior is acclimatized to have a constant temperature. Last but not least, the location of the telescope is crucial to have good seeing conditions. Dry and high-altitude areas have the best atmospheric conditions, as well as areas with stable atmosphere like mountains on islands surrounded by the ocean or large lakes. From a technological point of view, an adaptive optics system is used at modern telescopes to correct in real time the distortions of the image introduced by the turbulent atmosphere.",
            "An adaptive optics system is used to minimise the seeing effects produced by the Earth’s atmosphere and hence increase the image quality of the observations. \nA conventional adaptive optics system consists of three elements: a wavefront sensor of the light, a deformable mirror correcting ground-layer turbulence, and a processing unit.\nHow does it work? The sensor measures the incoming wavefront of the light every several milliseconds and, using specific algorithms, the processing unit calculates the ideal deformation of the mirror to compensate for the aberrations. This allows the astronomers to compensate for the negative effects on the image quality produced by the turbulent air flows(seeing) in the Earth’s atmosphere.",
            "Spectroscopy is a technique employed to study electromagnetic radiation (light) as a function of wavelength or frequency. The light can be split into different wavelength bands. In the visible light this would correspond to the different colors. The most relevant bands to study the Sun are: radio waves, infrared, visible light, ultraviolet, X- and gamma-rays. Each individual band comprises specific wavelengths that correspond to transitions of atoms, among others: hydrogen, helium or ion. Therefore, by analysing with spectroscopy certain spectral transitions, astronomers can infer information about the atoms themselves. In addition, this allows to obtain the properties of the solar or stellar atmosphere where the atoms are embedded in.",
            "Spectropolarimetry is a technique to measure and interpret the polarization of electromagnetic radiation (light) as a function of wavelength or frequency. These signals are described with the so-called Stokes parameters. The polarization of the light is directly related to the magnetic and electric fields. Therefore, spectropolarimetry is a crucial method to infer information about these two fields. This allows us to understand the magnetic and electric properties of different solar phenomena, such as sunspots, filaments or flares.",
            "Currently, there is no direct way to measure the magnetic field on the Sun. It is too hot on the solar surface to have a local instrument to measure the magnetic field strength. However, by analysing the light which comes from the Sun, solar physicists are able to infer quite precise values of the magnetic field, even its orientation. The tools which are needed to deduce the magnetic field are: a polarimeter attached to the telescope. This instrument allows us to measure the polarization of spectral lines from the Sun; a special technique based on spectropolarimetry, where information from the polarization is extracted to infer the magnetic field strength.",
            "A magnetogram is a map of the magnetic field strength on the Sun. Magnetograms are often represented by black and white color, each one representing a different polarity of the magnetic field. Since astronomers cannot measure the magnetic field directly on the Sun, they make use of spectropolarimetry together with the Zeeman effect to construct a magnetogram. For instance, the Solar Dynamics Observatory satellite generates a magnetogram of the Sun about every minute.",
            "The chromosphere of the Sun hosts a few very popular spectral lines which are commonly used by astronomers. Among others, the hydrogen H-alpha line at 656.3 nm is well known because it shows the beauty of the solar chromosphere in all its details. Another popular spectral line is the calcium line at 854.2 nm, one of the few lines which has been intensively studied and modeled, and therefore can be used to infer many physical parameters such as temperatures and the magnetic field. Of great interest is also the helium triplet at about 1083.0 nm. Although not easy to interpret, it has been intensively studied and provides excellent information about the magnetic fields in chromospheric phenomena such as filaments or flares.",
            "The photosphere hosts many interesting spectral lines. Among the most popular ones is the iron 617.3 nm line, which is used for example by the Solar Dynamics Observatory (SDO) to produce magnetograms of the whole Sun, using spectropolarimetric techniques. A popular duo are the iron 630.1 and 630.2 nm spectral lines. For example, the Hinode spacecraft provides magnetograms using these lines. In addition to the previous lines, ground-based telescopes often focus on the near-infrared lines of iron at 1564.8 nm and silicon at 1082.7 nm. There are many more spectral lines suitable to be studied in the photosphere and many of these lines cover different heights in the solar atmosphere. Therefore, studying several lines simultaneously allows us to better study the Sun.",
            "Hydrogen alpha (Halpha) is a specific atomic transition of the hydrogen atom. The wavelength of this transition corresponds to 656.28 nm. This occurs when one electron falls from the third towards the second lowest energy level. Hydrogen is the most abundant element in the universe. Therefore, the Halpha spectral line is very prominent among solar and night-time astronomers. On the Sun for example, the Halpha line maps the chromosphere. When looking at the Sun with an Halpha filter, we see a rich layer of dark solar features such as filaments, arch filament systems, spicules, fibrils, etc."
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
