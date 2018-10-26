using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Win32;
using System.IO;
using CrystalDecisions.Shared;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Linq;
using System.Drawing.Printing;

namespace JFramework
{
    public abstract class AppFramework : IAppFramework
    {
        /// <summary>
        /// Return a SqlCommand. 
        /// Provide Parameters (SQL Syntax,  Parameters).
        /// </summary>
        /// <param name="syntax"></param>
        /// <returns></returns>
        public virtual SqlCommand SqlCommand(string syntax)
        {
            SqlConnection conn = SqlConnection();
            conn.Open();
            SqlCommand sql = new SqlCommand
            {
                Connection = conn,
                CommandText = syntax,
                CommandType = CommandType.Text
            };
            return sql;
        }

        /// <summary>
        /// Get the Connection from App.config.
        /// </summary>
        /// <returns></returns>
        public virtual SqlConnection SqlConnection()
        {
            var constr = ConfigurationManager.ConnectionStrings["ConnnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            return conn;
        }

        /// <summary>
        /// Create a ReportDocument for you to load it In Crystal Report.
        /// </summary>
        /// <param name="ReportToLoad"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="Param1"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual ReportDocument ReportLoad(string ReportToLoad, string user, string password, string[] Param1, string[] value)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(ReportToLoad);
            reportDocument.SetDatabaseLogon(user, password);

            for (int i = 0; i < Param1.Length; i++)
            {
                reportDocument.SetParameterValue(Param1[i], value[i]);
            }
            return reportDocument;
        }

        /// <summary>
        /// Set Value for the Registry.
        /// Provide a UserRoot, Subkey, {ValueName}, {Value}.
        /// Note: {} = Array.
        /// </summary>
        /// <param name="UserRoot"></param>
        /// <param name="SubKey"></param>
        /// <param name="ValueName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public virtual string RegistrySettings(string UserRoot, string SubKey, string[] ValueName, string[] Value)
        {
            string KeyName = UserRoot + "\\" + SubKey;
            for (int i = 0; i < ValueName.Length; i++)
            {
                Registry.SetValue(KeyName, ValueName[i], Value[i]);
            }
            return "";
        }

        /// <summary>
        /// GetValue to the KeyName and {ValueName} You Provide.
        /// Note: {} = Array.
        /// </summary>
        /// <param name="Keyname"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        public virtual List<string> RegistryGetValue(string Keyname, string[] ValueName)
        {
            List<string> Value = new List<string>();
            RegistryKey registry = Registry.CurrentUser.OpenSubKey(@Keyname);
            string ValueItemName = "";
            if (registry != null)
            {
                for (int i = 0; i < ValueName.Length; i++)
                {
                    ValueItemName = registry.GetValue(ValueName[i]).ToString();
                    Value.Add(ValueItemName);
                }
            }
            return Value;
        }

        /// <summary>
        /// Convert the PDF into Bytes for other use.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public virtual byte[] PDF(string location)
        {
            byte[] PdfBytes;
            PdfBytes = File.ReadAllBytes(location);
            return PdfBytes;
        }

        /// <summary>
        /// Used to get the folderdialogPath selected.
        /// </summary>
        /// <returns></returns>
        public virtual string FolderDialogPath()
        {
            string path = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog.RootFolder;
            }
            return path;
        }

        /// <summary>
        /// Create a Folder and give the name for the folder.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public virtual string FolderCreation(string Path)
        {
            string str;
            Directory.CreateDirectory(Path).ToString();
            str = Path;
            return str;
        }

        /// <summary>
        /// Load a Certain Report and export it to PDF.
        /// </summary>
        /// <param name="report"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual string PDF(ReportDocument report, string path)
        {
            report.ExportToDisk(ExportFormatType.PortableDocFormat, path);
            return null;
        }

        /// <summary>
        /// Sending Email.
        /// </summary>
        /// <param name="smtpClient"></param>
        /// <param name="EmailSender"></param>
        /// <param name="EmailPassword"></param>
        /// <param name="EmailReceiver"></param>
        /// <param name="EmailBCC"></param>
        /// <param name="EmailCC"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attach"></param>
        /// <returns></returns>
        public virtual MailMessage EmailSend(string smtpClient, string EmailSender, string EmailPassword,
                                        string EmailReceiver, string EmailBCC, string EmailCC, string subject,
                                        string body, string attach)
        {
            MailMessage message = new MailMessage(EmailSender, EmailReceiver, subject, body);
            SmtpClient smtp = new SmtpClient(smtpClient)
            {
                EnableSsl = false,
                UseDefaultCredentials = false
            };
            NetworkCredential credentials = new NetworkCredential("ereports.mdmpi@marsmandrysdale.com", "JayAb@0ag");
            smtp.Credentials = credentials;
            if (attach != "")
            {
                Attachment attachment = new Attachment(attach);
                message.Attachments.Add(attachment);
            }
            if (EmailBCC != "")
            {
                message.Bcc.Add(EmailBCC);
            }
            else if (EmailCC != "")
            {
                message.CC.Add(EmailCC);
            }
            smtp.Send(message);
            return message;
        }

        /// <summary>
        /// File Searching. "error" if the path is not exist.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual object Searching(string path,string fileExtension)
        {
            object fileCount = 0;
            if (Directory.Exists(path))
            {
                fileCount = Directory.GetFiles(path, "*." + fileExtension, SearchOption.TopDirectoryOnly).Length;
            }
            else
            {
                fileCount = "error";
            }
            return fileCount;
        }

        /// <summary>
        /// Check Path or IP Address.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual string Ping(string path)
        {
            string err = "";
            Ping ping = new Ping();
            try
            {
                PingReply pingReply = ping.Send(path);
            }
            catch (Exception)
            {
                err = "Ping Error " + path;
            }
            return err;
        }

        /// <summary>
        /// Folder location detection. Return error when false.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual string CheckLocation(string path)
        {
            string err = "";
            bool pathValidation = Directory.Exists(path);
            if (pathValidation != true)
            {
                err = "error";
            }
            return err;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public virtual Timer TimerProtocol(int interval)
        {
            Timer timer = new Timer
            {
                Interval = interval
            };
            return timer;
        }


        public virtual string FileMakerWithData(string path,string laman)
        {
            string location = "";

            if (File.Exists(path))
            {
                File.AppendAllText(path, laman);
            }
            else
            {
                File.AppendAllText(path, laman);
            }
            return location;
        }

        public virtual string OpenExe(string exepath)
        {
            string err = "";
            if (File.Exists(exepath))
            {
                Process process = Process.Start(exepath);
            }
            else
            {
                err = "error";
            }
            return err;
        }

        public virtual bool DetectProcess(string exepath)
        {
            bool isRunning;
            string filename = GetFileOrName(exepath, "noextension");
            string directory = GetFileOrName(exepath, "path");
            Process[] pname = Process.GetProcessesByName(filename);
            if (pname.Length != 0)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
            return isRunning;
        }

        public virtual string GetFileOrName(string path,string getvalue)
        {
            string pathname = "";
            if (getvalue == "path")
            {
                pathname = Path.GetDirectoryName(path);
            }
            else if (getvalue == "filename")
            {
                pathname = Path.GetFileName(path);
            }
            else if (getvalue == "fullpath")
            {
                pathname = Path.GetFullPath(path);
            }
            else if (getvalue == "noextension")
            {   
                pathname = Path.GetFileNameWithoutExtension(path);
            }
            return pathname;
        }
        public string FileDialog()
        {
            string fullpath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result  = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fullpath = openFileDialog.FileName;
            }
            return fullpath;
        }

        public virtual System.Drawing.Printing.PaperSize SetPaperSize(int RawKind)
        {
            PrintDocument printDocument = new PrintDocument();

            List<string> sizelist = new List<string>();
            System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize();

            for (int i = 0; i < printDocument.PrinterSettings.PaperSizes.Count; i++)
            {
                paperSize = printDocument.PrinterSettings.PaperSizes[i];
                if (paperSize.RawKind == RawKind)
                {
                    break;
                }
            }
            return paperSize;
        }
    }
}
