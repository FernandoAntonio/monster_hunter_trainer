using System.Diagnostics;
using System.Runtime.InteropServices;
using Memory;

namespace MHRiseTrainer
{
    public partial class Form1 : Form
    {
        readonly Mem memory = new();
        Process? gameProcess;
        bool isProcessOpen = false;
        string? fpsLimiterBaseAddress;
        string? renderScaleBaseAddress;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFromIni();
            InitializeVisualEffects();

            if (!searchAndInject.IsBusy)
                searchAndInject.RunWorkerAsync();
        }

        private void SearchAndInjectDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                ManageGameProcess();

                if (gameProcess != null)
                {
                    ManageOpenProcess();

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
                            FailedReadAndWriteValues();
                            ManageGameProcess();
                            Thread.Sleep(5000);
                        }
                    }
                }
                else
                    ResetAllValues();

                Thread.Sleep(1000);
            }
        }

        private void ReadAndWriteFpsLimit()
        {
            decimal currentLimit = memory.ReadMemory<Decimal>(fpsLimiterBaseAddress);
            currentFpsLimit.Invoke(t => t.Text = currentLimit.ToString());

            String selectedValue = "";
            fpsValues.Invoke(t => selectedValue = t.SelectedValue.ToString() ?? "");

            if (decimal.Parse(selectedValue) != currentLimit)
                memory.WriteMemory(fpsLimiterBaseAddress, "float", selectedValue);
        }

        private void ReadAndWriteRenderScale()
        {
            decimal currentLimit = memory.ReadMemory<Decimal>(renderScaleBaseAddress);
            currentRenderScale.Invoke(t => t.Text = currentLimit.ToString());

            String selectedValue = "";
            renderScaleValues.Invoke(t => selectedValue = t.SelectedValue.ToString() ?? "");

            if (decimal.Parse(selectedValue) != currentLimit)
                memory.WriteMemory(renderScaleBaseAddress, "float", selectedValue);

        }

        private void ManageGameProcess()
        {
            Process[] processes = Process.GetProcessesByName("MonsterHunterRise");

            if (processes.Length > 0)
            {
                gameProcess = processes.First();
                processIdValue.Invoke(t => t.Text = gameProcess.Id.ToString());
            }
            else
            {
                gameProcess = null;
                ResetAllValues();
                Thread.Sleep(5000);
            }
        }

        private void ManageOpenProcess() {
          isProcessOpen = memory.OpenProcess(gameProcess.Id);

            if (isProcessOpen)
            {
                processStatusValue.Invoke(t => t.Text = "Open");
                processStatusValue.Invoke(t => t.ForeColor = Color.Green);
            }
        }

        private void ResetAllValues()
        {
            processIdValue.Invoke(t => t.Text = "Not Found");
            processStatusValue.Invoke(t => t.Text = "Closed");
            processStatusValue.Invoke(t => t.ForeColor = Color.Red);
            currentFpsLimit.Invoke(t => t.Text = "Not Found");
            currentRenderScale.Invoke(t => t.Text = "Not Found");
        }

        private void FailedReadAndWriteValues()
        {
            currentFpsLimit.Invoke(t => t.Text = "Failed to Read Memory");
            currentRenderScale.Invoke(t => t.Text = "Failed to Read Memory");
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

        private void ReadFromIni()
        {
            try
            {
                fpsLimiterBaseAddress = File.ReadAllText("config.ini").Split('\r', '\n').First(st => st.StartsWith("FPSLimiterAddress")).Split('=').Last();
                renderScaleBaseAddress = File.ReadAllText("config.ini").Split('\r', '\n').First(st => st.StartsWith("RenderScaleAddress")).Split('=').Last();

                if (fpsLimiterBaseAddress == null || renderScaleBaseAddress == null)
                    ShowIniErrorDialog();
            }
            catch
            {
                ShowIniErrorDialog();
            }
          
        }

        private static void ShowIniErrorDialog()
        {
            DialogResult errorMessage = MessageBox.Show("The config.ini file is missing, terminating application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (errorMessage == DialogResult.OK)
                System.Windows.Forms.Application.Exit();
        }

        private void InitializeVisualEffects()
        {
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

            UseImmersiveDarkMode(this.Handle, true);

        }
    }

    public class ComboBoxValues
    {
        public string? Value { get; set; }
        public string? Name { get; set; }
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