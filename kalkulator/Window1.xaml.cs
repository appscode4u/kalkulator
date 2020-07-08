using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace kalkulator
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	/// 

	//klasa która będzie przechowywała poszczególne wartości Log'u
	public class Log{
		public string Kliczba1{get;set;}
		public string Kliczba2{get;set;}
		public string Kdzialanie{get;set;}
		public string Kwynik{get;set;}
	}	
	
	public partial class Window1 : Window
	{
		public int kodFunkcji=1;
		public double liczba1;
		public double liczba2;
		public bool przecinek;
		public int RNDvalue;
		public static string DecimalSep = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
		
	public void zapiszLog(double l1,double l2,string dzialanie,string wynik){
		Log wiersz = new Log();
		//dopisuję szczegóły wiersza do zmiennych klasy
		wiersz.Kliczba1 = l1.ToString();
		wiersz.Kliczba2 = l2.ToString();
		wiersz.Kdzialanie = dzialanie;
		wiersz.Kwynik = wynik;
		
		//dopisuję wiersz logu do DataGrid
		HISTORIA.Items.Add(wiersz);		
	}
		
		public Window1()
		{
			InitializeComponent();
			kodFunkcji=0;
			RndVal.Content = BarVal.Value.ToString();
			RNDvalue = 4;
			BPRZECINEK.Content = DecimalSep;
		}
					void B1_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("1");
					}
			
					void B2_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("2");
					}
					void B3_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("3");
					}	
					void B4_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("4");
					}
					void B5_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("5");
					}
					void B6_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("6");
					}
					void B7_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("7");
					}
					void B8_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("8");
					}
					void B9_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("9");
					}
					void B0_Click(object sender, RoutedEventArgs e)
					{
						wpisz ("0");
					}
					void BCE_Click(object sender, RoutedEventArgs e)
					{
						WYNIK.Text = "0";
						liczba1=liczba2=kodFunkcji=0;
					}
					void BPRZECINEK_Click(object sender, RoutedEventArgs e)
					{
						if(WYNIK.Text.Contains(DecimalSep)==false)
							przecinek = true;
					}		
					void BPM_Click(object sender, RoutedEventArgs e)
					{
						if(WYNIK.Text!="0")
							WYNIK.Text = (Convert.ToDouble(WYNIK.Text)*(-1)).ToString();
					}
					
					
		void wpisz (String l)
		{
			if(WYNIK.Text=="0"){
				if(przecinek)
					WYNIK.Text = "0" + DecimalSep + l;
				else
					WYNIK.Text = l;
			}
			else
				if(przecinek)
					WYNIK.Text = WYNIK.Text + DecimalSep + l;
				else
				WYNIK.Text +=l;				

			przecinek = false;
			
		}
		void BCOFNIJ_Click(object sender, RoutedEventArgs e)
		{
			if (WYNIK.Text.Substring(0,1)!="-")
			{
				if(WYNIK.Text.Length >1)
				WYNIK.Text = WYNIK.Text.Substring(0,WYNIK.Text.Length - 1);
				else
					WYNIK.Text = "0";
			}
			else
				if(WYNIK.Text.Length >2)
					WYNIK.Text = WYNIK.Text.Substring(0,WYNIK.Text.Length - 1);
				else
					WYNIK.Text = "0";
		}
		
		void funkcje(int nrFunkcji)
		{ double tmpWynik;
			switch(nrFunkcji)
			{
				case 1:
					//dodawanie
					tmpWynik = liczba1+liczba2;
					WYNIK.Text = Math.Round(tmpWynik,RNDvalue).ToString();
						zapiszLog(liczba1,liczba2,"+",WYNIK.Text);
					break;
				case 2:
					//odejmowanie
					tmpWynik = liczba1-liczba2;
					WYNIK.Text = Math.Round(tmpWynik,RNDvalue).ToString();
						zapiszLog(liczba1,liczba2,"-",WYNIK.Text);
					break;
				case 3:
					//mnożenie
					tmpWynik = liczba1*liczba2;
					WYNIK.Text = Math.Round(tmpWynik,RNDvalue).ToString();
						zapiszLog(liczba1,liczba2,"*",WYNIK.Text);
					break;
				case 4:
				//dzielenie
					if(liczba2==0)
					{WYNIK.Text = "0";
						zapiszLog(liczba1,liczba2,"/","nie dziel /0");
					}				
					else
					{
						tmpWynik = liczba1/liczba2;
						WYNIK.Text = Math.Round(tmpWynik,RNDvalue).ToString();
						zapiszLog(liczba1,liczba2,"/",WYNIK.Text);					
					}
					break;
				case 5:
				//potęgowanie
					tmpWynik = Math.Pow(liczba1,liczba2);
					WYNIK.Text = Math.Round(tmpWynik,RNDvalue).ToString();
					zapiszLog(liczba1,liczba2,"^",WYNIK.Text);
				break;
				case 6:
				//modulo
					tmpWynik = liczba1%liczba2;
					WYNIK.Text = Math.Round(tmpWynik,RNDvalue).ToString();
					zapiszLog(liczba1,liczba2,"%",WYNIK.Text);					
				break;
			}		
			
		}
		void BPLUS_Click(object sender, RoutedEventArgs e)
		{
			double.TryParse(WYNIK.Text, out liczba1);
			kodFunkcji = 1;
			WYNIK.Text = "0";
		}
		void BWYNIK_Click(object sender, RoutedEventArgs e)
		{//dodawanie
			double.TryParse(WYNIK.Text, out liczba2);
			funkcje(kodFunkcji);
			kodFunkcji = 0;
		}
		void BMINUS_Click(object sender, RoutedEventArgs e)
		{//odejmowanie
			double.TryParse(WYNIK.Text, out liczba1);
			kodFunkcji = 2;
			WYNIK.Text = "0";
		}
		void BMNOZ_Click(object sender, RoutedEventArgs e)
		{//mnożenie
			double.TryParse(WYNIK.Text, out liczba1);
			kodFunkcji = 3;
			WYNIK.Text = "0";
		}
		void BDZIEL_Click(object sender, RoutedEventArgs e)
		{//dzielenie
			double.TryParse(WYNIK.Text, out liczba1);
			kodFunkcji = 4;
			WYNIK.Text = "0";
		}
		void BSQR_Click(object sender, RoutedEventArgs e)
		{//potęgowanie
			double.TryParse(WYNIK.Text, out liczba1);
			kodFunkcji = 5;
			WYNIK.Text = "0";
		}
		void BROOT_Click(object sender, RoutedEventArgs e)
		{//pierwiastokowanie
			double tmpVal;
			double.TryParse(WYNIK.Text, out tmpVal);
			WYNIK.Text = Math.Round(Math.Sqrt(tmpVal),RNDvalue).ToString();
			if (kodFunkcji==0)
				zapiszLog(tmpVal,0,"√",WYNIK.Text);
			else
				zapiszLog(0,tmpVal,"√",WYNIK.Text);
		}
		void BMOD_Click(object sender, RoutedEventArgs e)
		{//modulo
			double.TryParse(WYNIK.Text, out liczba1);
			kodFunkcji = 6;
			WYNIK.Text = "0";
		}
		void RMBUAction(object sender, MouseButtonEventArgs e)
		{
			if (MessageBox.Show("Czy chcesz wyczyścić historię?", "Czyścimy ?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
				HISTORIA.Items.Clear();
            }
		}
		void BarVal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{

			try{RndVal.Content = BarVal.Value.ToString();
				RNDvalue =(int)BarVal.Value;}
			catch{}
		}
	}
}