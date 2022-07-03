using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Memory;

namespace MHRiseTrainer
{
    public partial class Form1 : Form
    {
        Mem memory = new Mem();
        Process gameProcess;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeVisualEffects();

            if (!searchAndInject.IsBusy)
            {
                searchAndInject.RunWorkerAsync();
            }
        }


        private void searchAndInjectDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            while (true)
            {
                FindGameProcess();


                if (gameProcess != null)
                {
                    processIdValue.Invoke(t => t.Text = gameProcess.Id.ToString());
                    bool isProcessOpen = memory.OpenProcess(gameProcess.Id);

                    if (isProcessOpen)
                    {
                        try
                        {
                            ReadAndWriteFpsLimit();
                            ReadAndWriteRenderScale();
                        }
                        catch
                        {
                            isProcessOpen = false;
                            ResetFieldValues();
                        }
                    }
                }
                else
                {
                    ResetFieldValues();
                }
            }
        }

        private void ReadAndWriteFpsLimit()
        {
            const String address = "MonsterHunterRise.exe+0x1CF343F8,0x50,0x1F8,0x88,0x108,0x108,0x30,0x364";

            decimal currentLimit = memory.ReadMemory<Decimal>(address);
            currentFpsLimit.Invoke(t => t.Text = currentLimit.ToString());

            String currentValue = "";
            fpsValues.Invoke(t => currentValue = t.SelectedValue.ToString());
            memory.WriteMemory(address, "float", currentValue);
        }

        private void ReadAndWriteRenderScale()
        {
            const String address = "MonsterHunterRise.exe+0x0E956758,0x68,0x120,0x1D8,0xB8,0x1F8,0x48,0x88";

            decimal currentLimit = memory.ReadMemory<Decimal>(address);
            currentRenderScale.Invoke(t => t.Text = currentLimit.ToString());

            String currentValue = "";
            renderScaleValues.Invoke(t => currentValue = t.SelectedValue.ToString());
            memory.WriteMemory(address, "float", currentValue);
        }

        private void FindGameProcess()
        {
            Process[] processes = Process.GetProcessesByName("MonsterHunterRise");

            if (processes.Length > 0)
            {
                gameProcess = processes.First();
            }
            else
            {
                gameProcess = null;
                ResetFieldValues();
            }

        }
        private void OnFpsLimitChanged(object sender, EventArgs e)
        {

            if (!searchAndInject.IsBusy)
            {
                searchAndInject.RunWorkerAsync();
            }
        }

        private void ResetFieldValues()
        {
            processIdValue.Invoke(t => t.Text = "Not Found");
            currentFpsLimit.Invoke(t => t.Text = "Not Found");
            currentRenderScale.Invoke(t => t.Text = "Not Found");
        }


        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute,
                    ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 &&
                Environment.OSVersion.Version.Build >= build;
        }

        private void InitializeVisualEffects() {
            var listFps = new List<ComboBoxValues>() {
                new ComboBoxValues() {Value = "30.0", Name = "30"},
                new ComboBoxValues() {Value = "60.0", Name = "60"},
                new ComboBoxValues() {Value = "120.0", Name = "120"},
                new ComboBoxValues() {Value = "144.0", Name = "144"},
                new ComboBoxValues() {Value = "165.0", Name = "165"},
                new ComboBoxValues() {Value = "240.0", Name = "240"},
            };

            fpsValues.DataSource = listFps;
            fpsValues.DisplayMember = "Name";
            fpsValues.ValueMember = "Value";
            fpsValues.SelectedItem = listFps[1];


            var listRenderScale = new List<ComboBoxValues>() {
                new ComboBoxValues() {Value = "1.5", Name = "150%"},
                new ComboBoxValues() {Value = "2.0", Name = "200%"},
                new ComboBoxValues() {Value = "2.5", Name = "250%"},
                new ComboBoxValues() {Value = "3.0", Name = "300%"},
            };

            renderScaleValues.DataSource = listRenderScale;
            renderScaleValues.DisplayMember = "Name";
            renderScaleValues.ValueMember = "Value";
            renderScaleValues.SelectedItem = listRenderScale[0];

            UseImmersiveDarkMode(this.Handle,true);

        }
    }

    public class ComboBoxValues
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }

    public static class Extensions
    {
        public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del)
            where TControlType : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }

}