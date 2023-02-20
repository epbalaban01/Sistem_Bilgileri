using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using Microsoft.Win32;
using System.Management;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;

namespace Sistem_Bilgileri
{
    public partial class Form1 : Form
    {
        int i;
        double islem;
        string yazi;
        string acilistarihi, acilis, osSerial, Rmn, sonacilistarih, sonacilistarih1, soncevirli = null;
        string islemciadi, islemcicekirdeksayisi, islemciureticisi, islemcicpumimari, cpu, islemciContorllerinfo = null;
        string toplamraminfo, ramhizi, slotSayisi, bosslotSayisi, toplamslotraminfo, profilyolu, ipadresadi, hdd, ramturu = null;
        string driverversion, videoControllerInfo, name, ram, horizontalResolution, verticalResolution, deviceID = null;

        public class HardDrive
        {
            public string Model { get; set; }
            public string InterfaceType { get; set; }
            public string Caption { get; set; }
            public string SerialNo { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            label21.Text = "Tüm telif hakları saklıdır. " + AssemblyCopyright;
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriCek();

        }
       
        public void VeriCek()
        {
            try
            {

                i = 1;
                ManagementObjectSearcher osInfo = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
                ManagementObjectSearcher sonAcilisSearcher = new ManagementObjectSearcher("Select * From Win32_NetworkAdapter");
                ManagementObjectSearcher vidSearcher = new ManagementObjectSearcher("Select * from Win32_VideoController Where availability='3'");
                ManagementObjectSearcher islemciSearcher = new ManagementObjectSearcher("Select * From Win32_Processor");
                ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
                ManagementObjectSearcher slotRamSearcher = new ManagementObjectSearcher("Select * From Win32_PhysicalMemoryArray");
                ManagementObjectSearcher ipSearcher = new ManagementObjectSearcher("Select * From Win32_NetworkAdapterConfiguration Where IPEnabled = True");
                ManagementObjectSearcher ekran = new ManagementObjectSearcher("Select * From Win32_VideoController");

                ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

                foreach (ManagementObject Mobject in Search.Get())
                {
                    //TOPLAM RAM BİLGİSİ
                    double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                    double ramgb = Ram_Bytes / 1073741824;
                    islem = Math.Ceiling(ramgb);
                    Rmn = islem.ToString();
                    //


                }





                //-----------------------------------------------
                //Ekran kartı bilgisi için

                //-----------------------------------------------



                foreach (ManagementObject osInfoObj in osInfo.Get())
                {
                    //SON FORMAT TARİHİ
                    acilistarihi = (string)osInfoObj["InstallDate"];
                    DateTime dt = System.Management.ManagementDateTimeConverter.ToDateTime(acilistarihi);
                    acilis = Convert.ToString(dt);
                    //

                    //İŞLETİM SİSTEMİ
                    osSerial = (string)osInfoObj["Caption"];
                    //

                    sonformattarihi.Text = acilis;
                    isletimsistemi.Text = osSerial;

                    //dynamic windowsShell = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell");
                    //var regValue = windowsShell.RegRead("HKEY_LOCAL_MACHINE/SYSTEM/CurrentControlSet/Control/Session Manager/Power/FwPOSTTime");

                }

                foreach (ManagementObject sonAcilisObject in sonAcilisSearcher.Get())
                {

                    //Son Açılış Tarihi
                    sonacilistarih = sonAcilisObject["TimeOfLastReset"].ToString();
                    DateTime dt1 = System.Management.ManagementDateTimeConverter.ToDateTime(sonacilistarih);
                    sonacilistarih1 = "" + dt1;

                    sonacilistarih2.Text = sonacilistarih1;

                    ////SON BIOS ZAMANI OLMUYOR
                    //key = Registry.CurrentUser.OpenSubKey("HKEY_LOCAL_MACHINE/SYSTEM/CurrentControlSet/Control/Session Manager/Power/FwPOSTTime");
                    ////

                }


                //------------------------------------------------------------------------------------------------------//
                //GRAFİK EKRAN KARTI
                foreach (ManagementObject mObject in vidSearcher.Get())
                {
                    name = mObject["Description"].ToString();
                    ram = (Convert.ToDouble(mObject["AdapterRam"]) / 1073741824).ToString();
                    deviceID = (string)mObject["DeviceID"];
                    horizontalResolution = mObject["CurrentHorizontalResolution"].ToString();
                    verticalResolution = mObject["CurrentVerticalResolution"].ToString();
                    driverversion = mObject["DriverVersion"].ToString();
                    videoControllerInfo = "Grafik (Ekran) Kartı / Kartları: \r\n" + name + "\r\n" + "Ram Miktarı: " + ram + " GB \r\nÇözünürlük: " + horizontalResolution + " x " + verticalResolution + "\r\nDriver Version: " + driverversion;


                    grafikadi.Text = name;
                    grafikrammiktari.Text = ram + " GB";
                    cozunurluk.Text = horizontalResolution + " x " + verticalResolution;
                    driverversion1.Text = driverversion;


                }

                //------------------------------------------------------------------------------------------------------//



                //------------------------------------------------------------------------------------------------------//
                //İŞLEMCİ ADI
                foreach (ManagementObject iObject in islemciSearcher.Get())
                {

                    islemciureticisi = iObject["Manufacturer"].ToString();
                    islemciadi = iObject["Name"].ToString();

                    islemcicpumimari = iObject["Architecture"].ToString();
                    if (Convert.ToInt32(islemcicpumimari) == 0)
                    {
                        cpu = "x86";
                    }
                    else if (Convert.ToInt32(islemcicpumimari) == 9)
                    {
                        cpu = "x64";
                    }

                    islemcicekirdeksayisi = iObject["NumberOfLogicalProcessors"].ToString();
                    islemciContorllerinfo = "İşlemci Üreticisi: " + islemciureticisi + " \r\nİşlemci İsmi: " + islemciadi + "\r\nCPU Mimarisi: " + cpu + "\r\nİşlemci Çekirdek Sayısı: " + islemcicekirdeksayisi;


                    islemciuretici.Text = islemciureticisi;
                    islemciadi1.Text = islemciadi;
                    cpumimarisi.Text = cpu;
                    islemcicekirdeksayisi1.Text = islemcicekirdeksayisi;
                }

                //------------------------------------------------------------------------------------------------------//


                //------------------------------------------------------------------------------------------------------//
                foreach (ManagementObject ramObject in ramSearcher.Get())
                {
                    //RAM ADI             
                    ramhizi = ramObject["ConfiguredClockSpeed"].ToString() + " MHz";
                    toplamraminfo = ramhizi;

              
                    if (Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) >= 100 && Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) <= 166)
                    {
                        ramturu = "SDRAM";
                    }
                    else if(Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) >= 266 && Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) <= 400)
                    {
                        ramturu = "DDR";
                    }
                    else if (Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) >= 533 && Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) <= 800)
                    {
                        ramturu = "DDR2";
                    }
                    else if (Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) >= 800 && Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) <= 1600)
                    {
                        ramturu = "DDR3";
                    }
                    else if (Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) >= 2133 && Convert.ToInt32(ramObject["ConfiguredClockSpeed"].ToString()) <= 3200)
                    {
                        ramturu = "DDR4";
                    }
                    else
                    {
                        ramturu = "Unkown";
                    }
                    //

                    toplamram1.Text = Rmn + " GB " + ramturu +" "+ ramhizi;

                }

                foreach (ManagementObject slotObject in slotRamSearcher.Get())
                {

                    //RAM SLOT SAYISI
                    slotSayisi = slotObject["MemoryDevices"].ToString();
                    bosslotSayisi = Convert.ToString(i - 1);

                    toplamslotraminfo = "Toplam Slot: " + slotSayisi + "\r\nBoş Slot: " + bosslotSayisi;

                    toplamslot1.Text = slotSayisi;
                    bosslot1.Text = "" + bosslotSayisi;
                }
                //------------------------------------------------------------------------------------------------------//



                //------------------------------------------------------------------------------------------------------//
                foreach (ManagementObject Mobject in Search.Get())
                {

                  

                    profilyolu = "\\\\" + (string)Mobject["Caption"] + "\\c$\\Users\\" + Environment.UserName + "\r\n";
                    

                    cihazadi.Text = Mobject["Domain"].ToString();
                    kullaniciadi.Text = Environment.UserName;
                    profilyolu1.Text = profilyolu;
                    pcadi.Text = Mobject["Caption"].ToString();
                    //label4.Text = "Profil Yolu: \\" + (string)Mobject["Caption"] + "\\c$\\Users\\" + bilgi;


                }
                //------------------------------------------------------------------------------------------------------//


                //------------------------------------------------------------------------------------------------------//
                string host1 = Dns.GetHostName();
                IPHostEntry ipadres = Dns.GetHostByName(host1);
                ipadresadi = ipadres.AddressList[0].ToString();

                ipadresi.Text = ipadresadi;
                //birden fazla ip olabilceğinden burada ilk bulunanı alıyoruz.
                //------------------------------------------------------------------------------------------------------//




                //------------------------------------------------------------------------------------------------------//
                var mc = new ManagementClass("Win32_OperatingSystem");
                var moc = mc.GetInstances();
                DateTime lastBootUpTime = DateTime.MinValue;

                foreach (var mo in moc)
                {
                    lastBootUpTime = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());
                    break;
                }

                var difference = DateTime.Now - lastBootUpTime;
                var days = (int)difference.Days;
                var hours = (int)difference.Hours;
                var minutes = (int)difference.Minutes;
                soncevirli = days + " Gün " + hours + " Saat " + minutes + " Dakika ";


                calismasuresi.Text = soncevirli;
                //------------------------------------------------------------------------------------------------------//




                //------------------------------------------------------------------------------------------------------//
                string hdboyut = null;


                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    HardDrive hd = new HardDrive();
                    hd.Model = wmi_HD["Model"].ToString();

                    hd.Caption = wmi_HD["Caption"].ToString();
                    hd.SerialNo = wmi_HD.GetPropertyValue("Size").ToString();

                    long value;
                    if (long.TryParse(hd.SerialNo, out value))
                    {
                        string formattedValue = value / (1024 * 1024 * 1024) + " GB";
                        hdboyut = formattedValue;
                    }


                    hdd = "Model: " + hd.Model + "\r\n" + "Harddisk Boyutu: " + hdboyut;
                    harddiskmodel.Text = hd.Model;
                    harddiskboyut.Text = hdboyut;
                }

                //------------------------------------------------------------------------------------------------------//

                yazi = "----------[Cihaz Bilgileri]----------" + "\n" +
                    "Cihaz Adı: "+ cihazadi.Text + "\n" +
                    "Kullanıcı Adı: " + kullaniciadi.Text + "\n"+
                    "Profil Yolu: " + profilyolu1.Text +
                    "PC Adı: " + pcadi.Text + "\n" +
                    "Son Format Tarihi: " + sonformattarihi.Text + "\n"+
                    "İşletim Sistemi: " + isletimsistemi.Text + "\n"+
                    "IP Adresi: " + ipadresi.Text + "\n"+
                    "Son Açılış Tarihi: " + sonacilistarih2.Text + "\n" +
                    "Çalışma Süresi: " + calismasuresi.Text + "\n" 
                    + "\n" + "\n" +
                    "----------[Harddisk Özellikleri]----------" + "\n" +
                    "Model: " + harddiskmodel.Text + "\n" +
                    "Harddisk Boyut: " + harddiskboyut.Text + "\n" +
                    "\n" + "\n" +
                    "----------[Grafik Ekran Kartı Özellikleri]----------" + "\n" +
                    "Grafik Adı: " + grafikadi.Text + "\n"+
                    "Grafik Ram: " + grafikrammiktari.Text + "\n"+
                    "Çözünürlük: " + cozunurluk.Text + "\n"+
                    "Driver Version: " + driverversion1.Text + "\n" +
                    "\n" + "\n" +
                    "----------[İşlemci Özellikleri]----------" + "\n" +
                    "İşlemci Üreticisi: " + islemciuretici.Text + "\n" +
                    "İşlemci Adı: " + islemciadi1.Text + "\n" +
                    "CPU Mimarisi: " + cpumimarisi.Text + "\n" +
                    "İşlemci Çekirdek Sayısı: " + islemcicekirdeksayisi1.Text + "\n" +
                    "\n" + "\n" +
                    "----------[Ram Özellikleri]----------" + "\n" +
                    "Toplam RAM: " + toplamram1.Text + "\n" +
                    "Toplam Slot: " + toplamslot1.Text + "\n" +
                    "Boş Slot: " + bosslot1.Text + "\n" 
                    
                    ;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }


        string htmlTable;
        private void btn_Gonder_Click(object sender, EventArgs e)
        {
           
            StringBuilder sb = new StringBuilder();

            //Tablo başlangıcı
            sb.Append("<table border='1'>");
           
            //Tablo başlıkları


            //cihaz bilgileri baslangıc
            sb.Append("<tr>");
            sb.Append("<th colspan='2' style='width: 500'>" + "Cihaz Bilgileri" + "</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Cihaz Adı:" + "</b></td>");
            sb.Append("<td>" + cihazadi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Kullanıcı Adı:" + "</b></td>");
            sb.Append("<td>" + kullaniciadi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Profil Yolu:" + "</b></td>");
            sb.Append("<td>" + profilyolu1.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Bilgisayar Adı:" + "</b></td>");
            sb.Append("<td>" + pcadi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Son Format Tarihi:" + "</b></td>");
            sb.Append("<td>" + sonformattarihi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "İşletim Sistemi:" + "</b></td>");
            sb.Append("<td>" + isletimsistemi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "IP Adresi:" + "</b></td>");
            sb.Append("<td>" + ipadresi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Son Açılış Tarihi:" + "</b></td>");
            sb.Append("<td>" + sonacilistarih2.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Çalışma Süresi:" + "</b></td>");
            sb.Append("<td>" + calismasuresi.Text + "</td>");
            sb.Append("</tr>");
            //cihaz bilgileri sonu


            //bos satır
            sb.Append("<tr>");
            sb.Append("<td colspan='2' height='25'>" + "" + "</td>");
            sb.Append("</tr>");
            //bos satır



            //harddisk baslangıc
            sb.Append("<tr>");
            sb.Append("<th colspan='2'>" + "Harddisk Özellikleri" + "</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Model:" + "</b></td>");
            sb.Append("<td>" + harddiskmodel.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Harddisk Boyutu:" + "</b></td>");
            sb.Append("<td>" + harddiskboyut.Text + "</td>");
            sb.Append("</tr>");
            //harddisk sonu

            //bos satır
            sb.Append("<tr>");
            sb.Append("<td colspan='2' height='25'>" + "" + "</td>");
            sb.Append("</tr>");
            //bos satır

            //grafik ekran kartı baslangıc
            sb.Append("<tr>");
            sb.Append("<th colspan='2'>" + "Grafik Ekran Kartı Özellikleri" + "</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Grafik Adı:" + "</b></td>");
            sb.Append("<td>" + grafikadi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Grafik Ram:" + "</b></td>");
            sb.Append("<td>" + grafikrammiktari.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Çözünürlük:" + "</b></td>");
            sb.Append("<td>" + cozunurluk.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Driver Version:" + "</b></td>");
            sb.Append("<td>" + driverversion1.Text + "</td>");
            sb.Append("</tr>");
            //grafik ekran kartı sonu


            //bos satır
            sb.Append("<tr>");
            sb.Append("<td colspan='2' height='25'>" + "" + "</td>");
            sb.Append("</tr>");
            //bos satır



            //islemci ozellikleri baslangıc
            sb.Append("<tr>");
            sb.Append("<th colspan='2'>" + "İşlemci Özellikleri" + "</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "İşlemci Üreticisi:" + "</b></td>");
            sb.Append("<td>" + islemciuretici.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "İşlemci Adı:" + "</b></td>");
            sb.Append("<td>" + islemciadi1.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "CPU Mimarisi:" + "</b></td>");
            sb.Append("<td>" + cpumimarisi.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "İşlemci Çekirdek Sayısı:" + "</b></td>");
            sb.Append("<td>" + islemcicekirdeksayisi1.Text + "</td>");
            sb.Append("</tr>");
            //islemci ozellikleri sonu


            //bos satır
            sb.Append("<tr>");
            sb.Append("<td colspan='2' height='25'>" + "" + "</td>");
            sb.Append("</tr>");
            //bos satır


            //ram ozellikleri baslangıc
            sb.Append("<tr>");
            sb.Append("<th colspan='2'>" + "RAM Özellikleri" + "</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Toplam RAM:" + "</b></td>");
            sb.Append("<td>" + toplamram1.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Toplam Slot:" + "</b></td>");
            sb.Append("<td>" + toplamslot1.Text + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style='text-align: right'><b>" + "Boş Slot:" + "</b></td>");
            sb.Append("<td>" + bosslot1.Text + "</td>");
            sb.Append("</tr>");
            //ram ozellikleri sonu

            //Tablo sonu
            sb.Append("</table>");

            htmlTable = sb.ToString();



            try
            {
                if (txtMail.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayın!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Loading fl = new Loading();
                    fl.ac();
                    fl.mesaj_yaz("Gönderiyor..");

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("example@hotmail.com");
                        mail.To.Add(txtMail.Text);
                        mail.Subject = Environment.UserDomainName + "\\" + Environment.UserName + " - " + DateTime.Now.ToString();
                        mail.Body = htmlTable; //htmlTable is the table you created
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("example@hotmail.com", "password");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                        fl.kapat();
                        MessageBox.Show("Mail gönderildi.");
                    }

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }       
        }


        private void profilyolu1_Click(object sender, EventArgs e)
        {

            Process.Start("explorer.exe", @"\\" + pcadi.Text + "\\c$\\Users\\" + Environment.UserName);
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel6.Visible = true;
                checkBox1.Text = "";
            }
            else
            {
                panel6.Visible = false;
                checkBox1.Text = "Mail Gönder";
            }

        }


        PrintDialog PRD = new PrintDialog();

        private void btn_yazdir_Click(object sender, EventArgs e)
        {
            PrintDocument Kagit = new PrintDocument();
            DialogResult yazdirmaislemi;
            yazdirmaislemi = PRD.ShowDialog();
            Kagit.PrintPage += Kagit_PrintPage;
            if (yazdirmaislemi == DialogResult.OK)
            {
                Kagit.Print();
            }
        }

        private void Kagit_PrintPage(object sender, PrintPageEventArgs e)
        {
            string NeYazicam = yazi;
            Font YaziAilesi = new Font("Arial", 12);
            SolidBrush Kalem = new SolidBrush(Color.Black);
            e.Graphics.DrawString(NeYazicam, YaziAilesi, Kalem, 10, 20);
        }

        private void btn_notdefteri_Click(object sender, EventArgs e)
        {
            string path = "C:sistem_bilgileri.txt";
            File.WriteAllText(path, yazi);
            MessageBox.Show("Not Defteri oluşturuldu.","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
            Ayarlar yeni = new Ayarlar();
            yeni.Show();

        }   
    }
}
