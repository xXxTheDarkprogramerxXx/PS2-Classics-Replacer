using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using System.Data;
using DiscUtils.Iso9660;
using System.Linq;

public class Controlador : MonoBehaviour {

    [DllImport("universal")]
    private static extern int FreeMountUsb();

        


    public static Controlador instancia;

    public Text txtCamino;
    public Text FechaHora;
    public Text ListaVacia;
    private string _s_ = "/";

    private int Nivel = 0;
    private List<Vector2> UltimaPos = new List<Vector2>();

    public GameObject PanelVideo;
    public Image PanelVideoImagen;
    public GameObject PanelImagen;
    public Image PanelImagenImagen;
        
    public GameObject carpetasPrefab;
    public GameObject ficherosPrefabMP4;
    public GameObject ficherosPrefabMOV;
    public GameObject ficherosPrefabSRT;
    public GameObject ficherosPrefabFOT;
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public Slider miVolumen;
    public Text Subtitulos;

    private List<GameObject> ObjetosCreados = new List<GameObject>();
    private List<string> TODOS = new List<string>();

    private int Posicion = 0;
    private string[] scaneo;
	public List<PS2Items> listofgames = new List<PS2Items>();
	//path to USB0
	public string camino = "/usb0";//= @"G:\Games\Playstation\PS2";
	//path to usb1
	public string usb1 = "/usb1";

	private bool Paso = true;
    private bool EnImagen = false;
    
    public bool EnVideo = false;
    public bool FullScreen = false;
        
	public enum USBType
	{
		USB0 =0,
		USB1 = 1,
		None = 9
	}

    public void Awake()
    {
        instancia = this;
    }
        
    Vector3 posOriginal;
    Vector2 sizeOriginal;
    Vector2 sizeOriginalVideoImagen;

	#region << PS2 Items >>

	public string GetNameFromID(string PS2ID,DataTable dt)
	{
		try {
			for (int i = 0; i < dt.Rows.Count; i++) {
				if (dt.Rows [i] ["PS2ID"].ToString () == PS2ID) {
					return dt.Rows [i] ["PS2Title"].ToString ();
				}
			}
		} catch (Exception ex) {

		}
		return "";
	}

	public string GetRegionFromID(string PS2ID,DataTable dt)
	{
		try {
			for (int i = 0; i < dt.Rows.Count; i++) {
				if (dt.Rows [i] ["PS2ID"].ToString () == PS2ID) {
					return dt.Rows [i] ["Region"].ToString ();
				}
			}
		} catch (Exception ex) {

		}
		return "";
	}

	//PS2 Images
	public string GetImageFromID(string PS2ID,DataTable dt)
	{
		try {
			for (int i = 0; i < dt.Rows.Count; i++) {
				if (dt.Rows [i] ["PS2ID"].ToString () == PS2ID) {
					return dt.Rows [i] ["Imagurl"].ToString ();
				}
			}
		} catch (Exception ex) {
			return "";
		}
		return "";
	}

	public string GetPS2ID(string isopath)
	{
		using (FileStream isoStream = System.IO.File.OpenRead(isopath))
		{
			//use disk utils to read iso file
			CDReader cd = new CDReader(isoStream, true);
			//look for the specific file naimly the system config file
			Stream fileStream = cd.OpenFile(@"SYSTEM.CNF", FileMode.Open);
			// Use fileStream...
			TextReader tr = new StreamReader(fileStream);
			string fullstring = tr.ReadToEnd();//read string to end this will read all the info we need

			//mine for info
			string Is = @"\";
			string Ie = ";";

			//mine the start and end of the string
			int start = fullstring.ToString().IndexOf(Is) + Is.Length;
			int end = fullstring.ToString().IndexOf(Ie, start);
			if (end > start)
			{
				string PS2Id = fullstring.ToString().Substring(start, end - start);

				if (PS2Id != string.Empty)
				{
					return PS2Id.Replace(".", "").Replace("_","-");
					Console.WriteLine("PS2 ID Found" + PS2Id);
				}
				else
				{
					Console.WriteLine("Could not load PS2 ID");
					return "";
				}
			}
		}
		return "";
	}


	public DataTable ConvertToDataTable (StreamReader sr)
	{
		DataTable tbl = new DataTable();

		//add defualt columns 
		tbl.Columns.Add("PS2Title");
		tbl.Columns.Add("Region");
		tbl.Columns.Add("PS2ID");
		tbl.Columns.Add ("Imagurl");

		string line;
		while ((line = sr.ReadLine ()) != null) 
		{


			var cols = line.Split (';');
			if (cols.Count() > 2) 
			{
				DataRow dr = tbl.NewRow ();
				dr [0] = cols [0];
				dr [1] = cols [1];
				dr [2] = cols [2];
				if (cols.Count() > 3) {
					dr [3] = cols [3];
				}
				tbl.Rows.Add (dr);

			}
		}

		return tbl;
	}

	#endregion << PS2 Items >>

	public class PS2Items
	{
		public string PS2ID { get; set; }
		public string PS2_Title { get; set; }
		public string Region { get; set;}
		public string Picture { get; set; }
		public string Path { get; set; }
	}

    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        FechaHora.text = System.DateTime.Now.AddHours(-3).ToShortTimeString() + "\n" + System.DateTime.Now.AddHours(-3).ToLongDateString();
        StartCoroutine(ActualizarFechaHora());
                        
       

		if(Application.platform == RuntimePlatform.PS4)
		{			
			/*Uncomment when test is sucsesfull */
			try
			{
				FreeMountUsb();
			}
			catch(Exception ex) { txtCamino.text = "Failed to free mount usb's " + ex.Message;}
		}

		string path = @"G:\Games\Playstation\PS2";

		var charDataFile = Resources.Load<TextAsset>("PS2DB") ;
		//StreamReader reader = new StreamReader(ms, System.Text.Encoding.UTF8, true);
		StreamReader reader =   new StreamReader(new MemoryStream (charDataFile.bytes)); 

		DataTable dttemp = ConvertToDataTable (reader);
		List<string> lstofisos = new List<string> ();

		USBType typeofusb = USBType.None;

		string USBPath0 = "/usb0/PS2/";
		string USBPath1 = "/usb1/PS2/";
		string mntUsbPath0 = "mnt/usb0/PS2/";
		string mntUsbPath1 = "mnt/usb0/PS2/";

		if (Directory.Exists (USBPath0) || Directory.Exists (mntUsbPath0)) {
			typeofusb = USBType.USB0;
		}
		if (Directory.Exists (USBPath1) || Directory.Exists (mntUsbPath1)) {
			typeofusb =	USBType.USB1;
		}
		if (typeofusb == USBType.None) {
			//no usb found
			//or no path found

		}



		DirectoryInfo d = null;
		if (typeofusb == USBType.USB0) {
			camino = "/usb0/ps2/";
			d = new DirectoryInfo (USBPath0);
		}

		if (typeofusb == USBType.USB1) {
			camino = "/usb1/ps2/";
			d = new DirectoryInfo (USBPath1);
		}
		if (typeofusb == USBType.None) {
			d = new DirectoryInfo (path);
		}
		if(Directory.Exists(d.FullName))
		{
			FileInfo[] fileinfo = d.GetFiles ("*.iso");
			foreach (var item in fileinfo) {
				//load each ps2 iso item into 
				//our custom db
				lstofisos.Add (item.FullName);
			}
		}

		List<PS2Items> items = new List<PS2Items> ();

		for (int i = 0; i < lstofisos.Count; i++) {
			//read asb data 
			string id = GetPS2ID (lstofisos [i]);
			var exmapleitem = new PS2Items ();
			exmapleitem.PS2ID = id;
			//exmapleitem.Message = id;// (id,dttemp);
			exmapleitem.Path = lstofisos[i];
			exmapleitem.PS2_Title = GetNameFromID (id, dttemp);
			exmapleitem.Region = GetRegionFromID (id, dttemp);
			exmapleitem.Picture = GetImageFromID (id, dttemp);
			items.Add (exmapleitem);
		}

		listofgames = items;
		CrearDirectorio(items);

        posOriginal = PanelVideo.transform.localPosition;
        sizeOriginal = PanelVideo.GetComponent<RectTransform>().sizeDelta;
    }

    IEnumerator ActualizarFechaHora()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            FechaHora.text = System.DateTime.Now.AddHours(-3).ToShortTimeString() + "\n" + System.DateTime.Now.AddHours(-3).ToLongDateString();
        }
    }

	void CrearDirectorio(List<PS2Items> Items = null)
    {
//        txtCamino.text = camino.Replace("\\", "/");
//
        List<string> CarpetasCreadas = new List<string>();
        List<string> FicherosCreados = new List<string>();
        GameObject objeto = null;
//
//        scaneo = Directory.GetFileSystemEntries(txtCamino.text);
		foreach (var registro in Items) {
//            if (Directory.Exists(registro))
//            {
//                CarpetasCreadas.Add(registro);
//            }
//            else
//            {
			FicherosCreados.Add (registro.PS2_Title);
//            }
       }

        for (int i = 0; i < 		CarpetasCreadas.Count; i++)
        {
            objeto = Instantiate(carpetasPrefab, transform);
            objeto.GetComponentInChildren<Text>().text = Path.GetFileName(CarpetasCreadas[i]);

            ObjetosCreados.Add(objeto);
            TODOS.Add(CarpetasCreadas[i]);
        }
		for (int i = 0; i < Items.Count; i++) {
			
			objeto = Instantiate (ficherosPrefabMOV, transform);
			objeto.GetComponentInChildren<Text> ().text = Items [i].PS2_Title;
			ObjetosCreados.Add (objeto);
			TODOS.Add (Items [i].Path);
			//break;
            
		}

        scrollRect.verticalNormalizedPosition = 1;
        
        // si hay algo selecionar el 1ro de la lista
        if (TODOS.Count > 0)
        {
            ObjetosCreados[0].transform.GetChild(0).gameObject.SetActive(true);
            camino = TODOS[0];

            ListaVacia.gameObject.SetActive(false);
        }
        else
        {
            camino = "";
        }

        Paso = true;
    }

	bool firstload = false;

    void Update()
    {
        if (!EnImagen && !FullScreen)
        {
            // movimientos arriba y abajo
            if ((Input.GetAxis("dpad1_vertical") > 0 || Input.GetAxis("leftstick1vertical") < 0 || Input.GetAxis("rightstick1vertical") < 0 || Input.GetKey(KeyCode.UpArrow)) && Posicion > 0 && Paso)
            {
                Paso = false;

                ObjetosCreados[Posicion].transform.GetChild(0).gameObject.SetActive(false);
                Posicion--;
                ObjetosCreados[Posicion].transform.GetChild(0).gameObject.SetActive(true);
                camino = TODOS[Posicion];
				var itemsofps2 = listofgames [Posicion];
				txtCamino.text = itemsofps2.Path;
				StartCoroutine(MostrarImagen(itemsofps2));
                if (contentPanel.anchoredPosition.y > 0)
                {
                    contentPanel.anchoredPosition -= new Vector2(0, 45);
                }
                if (contentPanel.anchoredPosition.y < 0)
                {
                    contentPanel.anchoredPosition = new Vector2(0, 0);
                }
                
                StartCoroutine(SeguirPasando());
            }

            if ((Input.GetAxis("dpad1_vertical") < 0 || Input.GetAxis("leftstick1vertical") > 0 || Input.GetAxis("rightstick1vertical") > 0 || Input.GetKey(KeyCode.DownArrow)) && Posicion < TODOS.Count - 1 && Paso)
            {
                Paso = false;

                ObjetosCreados[Posicion].transform.GetChild(0).gameObject.SetActive(false);
                Posicion++;
                ObjetosCreados[Posicion].transform.GetChild(0).gameObject.SetActive(true);
                camino = TODOS[Posicion];
				var itemsofps2 = listofgames [Posicion];
				txtCamino.text = itemsofps2.Path;
				StartCoroutine(MostrarImagen (itemsofps2));
                if (scrollRect.verticalNormalizedPosition >= 0 && Posicion > 9)
                {
                    contentPanel.anchoredPosition += new Vector2(0, 45);
                }

                StartCoroutine(SeguirPasando());
            }

            // abrir o ejecutar
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                try
                {
                    //LOG = "";
                    if (Directory.Exists(camino)) // si es una carpeta abrirla
                    {
                        Nivel++;
                        UltimaPos.Add(new Vector2(Posicion, contentPanel.anchoredPosition.y));
      	              LimpiarTodo();
                        CrearDirectorio();
                    }
                    else // si no ejecutar el fichero si esta soportado
                    {
						switch (Path.GetExtension(listofgames[Posicion].Path).ToLower())
                        {
                            case ".iso":
                                //we need to copy over the file into the data folder
							string path =Application.dataPath +@"/image/disc01.iso";
							txtCamino.text = "path:" + path;
							   File.Copy(listofgames[Posicion].Path,Application.dataPath +@"/image/disc01.iso",true);
								//and lunach second eboot
								//lol no way Unity is best
								System.Diagnostics.Process.Start(Application.dataPath + "/theApplication.exe");
                                break;
						}
                    }
				}
                catch // (System.Exception ex)
                {
                    ; //LOG = "Error " + ex.Message;
                }
            }

            // refrescar usb
            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                SceneManager.LoadScene("main");
            }
			if (firstload == false) {
				try{
					var itemsofps21 = listofgames [Posicion];
				StartCoroutine(MostrarImagen (itemsofps21));
				firstload = true;
				}
				catch(Exception ex) {

				}
			}
        }

        // atras o cerrar opciones
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (FullScreen)
            {
                FullScreen = false;
                PanelVideo.transform.localPosition = posOriginal;
                PanelVideo.GetComponent<RectTransform>().sizeDelta = sizeOriginal;
                PanelVideoImagen.GetComponent<RectTransform>().sizeDelta = sizeOriginalVideoImagen;

                Subtitulos.fontSize = 32;
                Subtitulos.transform.localPosition = new Vector2(0, -200);

                return;
            }

            if (EnImagen)
            {
                //LOG = "";
                EnImagen = false;
                PanelImagen.gameObject.SetActive(false);
            }
            else
            {
               // if (txtCamino.text != "/usb0")
               // {
              //      Nivel--;

                    //LOG = "";
               //     LimpiarTodo();

                    //camino = txtCamino.text.Substring(0, txtCamino.text.LastIndexOf(_s_));
                    
               //     CrearDirectorio();

                 //   Posicion = (int)UltimaPos[Nivel].x;
               //     contentPanel.anchoredPosition += new Vector2(0, UltimaPos[Nivel].y);
                //    UltimaPos.RemoveAt(Nivel);

                //    ObjetosCreados[0].transform.GetChild(0).gameObject.SetActive(false);
                //    ObjetosCreados[Posicion].transform.GetChild(0).gameObject.SetActive(true);
                 //   camino = TODOS[Posicion];
				//	var itemsofps2 = listofgames [Posicion];
				//	StartCoroutine(MostrarImagen (itemsofps2));


                //}

				/*Here we need to access the config file inside the system file and then we need to execute a new window that allows the user to cnahge the items on the fly*/

            }
        }
		if ((Input.GetKeyDown (KeyCode.Joystick1Button4) || Input.GetKeyDown (KeyCode.Keypad4)) && Paso) {
			Paso = false;

			//Load Config from usb

			StartCoroutine(SeguirPasando());
		}
        // cambiar FullScreen y normal
        if ((Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Keypad8)) && Paso)
        {
            Paso = false;

            if (!FullScreen)
            {
                PanelVideo.transform.localPosition = Vector3.zero;
                PanelVideo.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

                Subtitulos.fontSize = 64;
                Subtitulos.transform.localPosition = new Vector2(0, -430);

                // tamaño de la Image del Video
                sizeOriginalVideoImagen = PanelVideoImagen.gameObject.GetComponent<RectTransform>().sizeDelta;

                int DW = 1920;
                int DH = 1080;

                float AR = (float)PanelVideoImagen.gameObject.GetComponent<RectTransform>().rect.width / (float)PanelVideoImagen.gameObject.GetComponent<RectTransform>().rect.height;
                float XX = DW;
                float YY = DW / AR;

                if (YY > DH)
                {
                    YY = DH;
                    XX = YY * AR;
                }

                PanelVideoImagen.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.RoundToInt(XX), Mathf.RoundToInt(YY));                
            }
            else
            {
                PanelVideo.transform.localPosition = posOriginal;
                PanelVideo.GetComponent<RectTransform>().sizeDelta = sizeOriginal;
                PanelVideoImagen.GetComponent<RectTransform>().sizeDelta = sizeOriginalVideoImagen;

                Subtitulos.fontSize = 32;
                Subtitulos.transform.localPosition = new Vector2(0, -200);
            }

            FullScreen = !FullScreen;
            StartCoroutine(SeguirPasando());
        }
                
        //txtLog.text = LOG;
    }

    public void ParoEnFullScreen()
    {
        FullScreen = false;
        PanelVideo.transform.localPosition = posOriginal;
        PanelVideoImagen.GetComponent<RectTransform>().sizeDelta = sizeOriginalVideoImagen;
        PanelVideo.GetComponent<RectTransform>().sizeDelta = sizeOriginal;
    }

    private void LimpiarTodo()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        ObjetosCreados.Clear();
        TODOS.Clear();
        Posicion = 0;
    }

    private IEnumerator SeguirPasando()
    {
        if (Input.GetAxis("joystick1_left_trigger") != 0)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(0.15f);
        }
        
        Paso = true;
    }

	private IEnumerator MostrarImagen(PS2Items item)
	{
		
		Texture2D texture = new Texture2D (0, 0, TextureFormat.RGBA32, false);
		texture.filterMode = FilterMode.Trilinear;
		var newTexture = new Texture2D (2, 2);

		if (item.Picture == "") {
			item.Picture = "http://www.bfegy.com/cdn/7/2014/444/ps2-game-cover-template_179589.jpg";
		}
		WWW www = new WWW (item.Picture);

		yield return www;
		Debug.Log("Why on earh is this never called?");

		www.LoadImageIntoTexture (texture);
		
		Sprite sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.0f, 0.0f), 1.0f);

		float AR = 0;
		float XX = 0;
		float YY = 0;
		if (texture.height >= 492) {
			AR = (float)texture.width / (float)texture.height;
			YY = Mathf.Min (texture.width, (874));
			XX = YY * AR;

			if (XX > 492) {
				XX = 492;
				YY = 492 / AR;
			}
		} else {
			AR = (float)texture.width / (float)texture.height;
			XX = Mathf.Min (texture.width, (492));
			YY = XX / AR;
		}

		PanelVideoImagen.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (XX, Mathf.RoundToInt (YY));
		PanelVideoImagen.gameObject.SetActive (true);
		PanelVideoImagen.sprite = sprite;

	}

    private void PlayVideo()
    {
        EnVideo = true;
    }

    public void UpdateVolumen(float volumen)
    {
        miVolumen.value = volumen;
    }
}