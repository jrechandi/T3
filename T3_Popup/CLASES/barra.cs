using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CustomUIControls;
using Microsoft.Win32;
using System.Runtime.InteropServices;
namespace T3_Popup
{
	/// <summary>
	/// Descripción breve de barra.
	/// </summary>
	public class barra
	{
		TaskbarNotifier taskbarNotifier1;
		TaskbarNotifier taskbarNotifier2;
		TaskbarNotifier taskbarNotifier3;
		public static int top;
	
		[DllImport("winmm.dll", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
		static extern bool PlaySound( string pszSound,
			IntPtr hMod, SoundFlags sf );

		[Flags]
			public enum SoundFlags : int 
		{
			SND_SYNC = 0x0000,  /* play synchronously (default) */
			SND_ASYNC = 0x0001,  /* play asynchronously */
			SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
			SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
			SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
			SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
			SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS = 0x00010000, /* name is a registry alias */
			SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
			SND_FILENAME = 0x00020000, /* name is file name */
			SND_RESOURCE = 0x00040004  /* name is resource name or atom */
		}

		private  void CloseClick(object obj,EventArgs ea)
		{
			//MessageBox.Show("Closed was Clicked");
		}

		private  void TitleClick(object obj,EventArgs ea)
		{
			//MessageBox.Show("Title was Clicked");
		}

		private void ContentClick(object obj,EventArgs ea)
		{
			//MessageBox.Show("Content was Clicked");
		}
//		private void tbFileName_TextChanged(object sender, System.EventArgs e)
//		{
//			if (tbFileName.Text.Length > 0)
//				//buttonPlay.Enabled = true;
//			else
//				buttonPlay.Enabled = false;
//		}
		/// <summary>
		/// sonido del notificador de la barra tipo msn
		/// </summary>
		/// <param name="sonido"></param>
		public static void sonido(string sonido)
		{
			int err = 0;	// last error

			try
			{
				// play the sound from the selected filename
				if (!PlaySound( sonido, IntPtr.Zero,
					SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC ))
					MessageBox.Show("Error",
						"mal sonido");
			}
			catch
			{
//				err = Marshal.GetLastWin32Error();
//				if (err != 0)
//					MessageBox.Show( "Error",
//						"Error " + err.ToString(),
//						"PlaySound() failed",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error );
			}
		}
		/// <summary>
		/// tipo de cuadro ecisten 3 tipos
		/// </summary>
		/// <param name="titulo">Titulo del mensaje</param>
		/// <param name="mensaje">Mensaje</param>
		public void cuadro1(string titulo,string mensaje)
		{

			
			
			taskbarNotifier1.CloseClickable=true;
			taskbarNotifier1.TitleClickable=false;
			taskbarNotifier1.ContentClickable=true;
			taskbarNotifier1.EnableSelectionRectangle=true;
			taskbarNotifier1.KeepVisibleOnMousOver=true;	// Added Rev 002
			taskbarNotifier1.ReShowOnMouseOver=false;			// Added Rev 002
			taskbarNotifier1.Show(titulo,mensaje,250,5000,500);
			//sonido(@Application.StartupPath+"\\a.wav");
		}
		/// <summary>
		/// tipo de cuadro ecisten 3 tipos
		/// </summary>
		/// <param name="titulo">Titulo del mensaje</param>
		/// <param name="mensaje">Mensaje</param>
		public  void cuadro2(string titulo,string mensaje)
		{
			sonido(@Application.StartupPath+"\\a.wav");
			//sonido();
			taskbarNotifier2.CloseClickable=true;
			taskbarNotifier2.TitleClickable=false;
			taskbarNotifier2.ContentClickable=true;
			taskbarNotifier2.EnableSelectionRectangle=true;
			taskbarNotifier2.KeepVisibleOnMousOver=true;	// Added Rev 002
			taskbarNotifier2.ReShowOnMouseOver=false;			// Added Rev 002
			taskbarNotifier2.Show(titulo,mensaje,500,4000,500);
			
		}
		/// <summary>
		/// crea los notificadores 
		/// </summary>
		public barra()
		{            
            taskbarNotifier2 = new TaskbarNotifier();
            taskbarNotifier2.SetBackgroundBitmap(new Bitmap(GetType(), "Multimedia.skin2.bmp"), Color.FromArgb(255, 0, 255));
            taskbarNotifier2.SetCloseBitmap(new Bitmap(GetType(), "Multimedia.close2.bmp"), Color.FromArgb(255, 0, 255), new Point(300, 74));
            taskbarNotifier2.TitleRectangle = new Rectangle(123, 80, 176, 16);
            taskbarNotifier2.ContentRectangle = new Rectangle(116, 97, 120, 22);
            taskbarNotifier2.TitleClick += new EventHandler(TitleClick);
            taskbarNotifier2.ContentClick += new EventHandler(ContentClick);
            taskbarNotifier2.CloseClick += new EventHandler(CloseClick);

            taskbarNotifier1 = new TaskbarNotifier();
            taskbarNotifier1.SetBackgroundBitmap(new Bitmap(GetType(), "Multimedia.skin.bmp"), Color.FromArgb(255, 0, 255));
            taskbarNotifier1.SetCloseBitmap(new Bitmap(GetType(), "Multimedia.close.bmp"), Color.FromArgb(255, 0, 255), new Point(127, 8));
            taskbarNotifier1.TitleRectangle = new Rectangle(40, 9, 70, 25);
            taskbarNotifier1.ContentRectangle = new Rectangle(8, 21, 133, 68);
            taskbarNotifier1.TitleClick += new EventHandler(TitleClick);
            taskbarNotifier1.ContentClick += new EventHandler(ContentClick);
            taskbarNotifier1.CloseClick += new EventHandler(CloseClick);	
		
		}
			
	}

}