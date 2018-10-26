using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace JFramework
{
    public interface IAppFramework
    {
        string CheckLocation(string path);
        bool DetectProcess(string exepath);
        MailMessage EmailSend(string smtpClient, string EmailSender, string EmailPassword, string EmailReceiver, string EmailBCC, string EmailCC, string subject, string body, string attach);
        string FileDialog();
        string FileMakerWithData(string path, string laman);
        string FolderCreation(string Path);
        string FolderDialogPath();
        string GetFileOrName(string path, string getvalue);
        string OpenExe(string exepath);
        string PDF(ReportDocument report, string path);
        byte[] PDF(string location);
        string Ping(string path);
        List<string> RegistryGetValue(string Keyname, string[] ValueName);
        string RegistrySettings(string UserRoot, string SubKey, string[] ValueName, string[] Value);
        ReportDocument ReportLoad(string ReportToLoad, string user, string password, string[] Param1, string[] value);
        object Searching(string path, string fileExtension);
        PaperSize SetPaperSize(int RawKind);
        SqlCommand SqlCommand(string syntax);
        SqlConnection SqlConnection();
        Timer TimerProtocol(int interval);
    }
}