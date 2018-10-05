using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using DiscUtils.Iso9660;

namespace FancyScrollView
{
	
    public class Example04Scene : MonoBehaviour
    {
        [SerializeField]
        Example04ScrollView scrollView;
        [SerializeField]
        Button prevCellButton;
        [SerializeField]
        Button nextCellButton;
        [SerializeField]
        Text selectedItemInfo;

        List<Example04CellDto> cellData;
        Example04ScrollViewContext context;

        void HandlePrevButton()
        {
            SelectCell(context.SelectedIndex - 1);
        }

        void HandleNextButton()
        {
            SelectCell(context.SelectedIndex + 1);
        }

        void SelectCell(int index)
        {
            if (index >= 0 && index < cellData.Count)
            {
                scrollView.UpdateSelection(index);
            }
        }

        void HandleSelectedIndexChanged(int index)
        {
            selectedItemInfo.text = String.Format("Selected item info: index {0}", index);
        }

        void Awake()
        {
            prevCellButton.onClick.AddListener(HandlePrevButton);
            nextCellButton.onClick.AddListener(HandleNextButton);
        }

		public enum USBType
		{
			USB0 =0,
			USB1 = 1,
			None = 9
		}


		public string GetNameFromID(string PS2ID,DataTable dt)
		{
			for (int i = 0; i < dt.Rows.Count; i++) {
				if (dt.Rows [i] ["PS2ID"].ToString () == PS2ID) {
					return dt.Rows [i] ["PS2Title"].ToString ();
				}
			}
			return "";
		}

        void Start()
        {
			/*Load PS2 Database*/
			/*Should have most of the names of games might miss a few but thats okay*/

			string path = "Assets/PS2DB.d";
			StreamReader reader = new StreamReader(path); 

			DataTable dttemp = ConvertToDataTable (reader);
			List<string> lstofisos = new List<string> ();

			USBType typeofusb = USBType.None;

			string USBPath0 = "USB0/PS2/";
			string USBPath1 = "USB1/PS2/";
			if (Directory.Exists (USBPath0)) {
				typeofusb = USBType.USB0;
			}
			if (Directory.Exists (USBPath1)) {
				typeofusb =	USBType.USB1;
			}
			if (typeofusb == USBType.None) {
				//no usb found
			}



			DirectoryInfo d = null;
			if (typeofusb == USBType.USB0) {
				d = new DirectoryInfo (USBPath0);
			}

			if (typeofusb == USBType.USB1) {
				d = new DirectoryInfo (USBPath1);
			}
			if(typeofusb == USBType.None)
				{
				 d = new DirectoryInfo (@"G:\Games\Playstation\PS2");
				}
			FileInfo[] fileinfo = d.GetFiles ("*.iso");
			foreach (var item in fileinfo) {
				//load each ps2 iso item into 
				//our custom db
				lstofisos.Add(item.FullName);
			}

			cellData = new List<Example04CellDto> ();

            for (int i = 0; i < lstofisos.Count; i++)
            {
                //read udb data 
                string id = GetPS2ID(lstofisos[i]);
				var exmapleitem = new Example04CellDto ();
				exmapleitem.PS2ID = id;
				exmapleitem.Message = GetNameFromID (id,dttemp);
				exmapleitem.PS2_Title = exmapleitem.Message;
				exmapleitem.Region = "";
				cellData.Add (exmapleitem);
            }





            context = new Example04ScrollViewContext();
            context.OnSelectedIndexChanged = HandleSelectedIndexChanged;
            context.SelectedIndex = 0;

            scrollView.UpdateData(cellData, context);
            scrollView.UpdateSelection(context.SelectedIndex);
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
                        return PS2Id.Replace(".", "");
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
					tbl.Rows.Add (dr);

				}
			}

			return tbl;
		}
    }
}
