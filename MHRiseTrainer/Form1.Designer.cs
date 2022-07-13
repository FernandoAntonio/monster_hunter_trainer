namespace MHRiseTrainer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchAndInject = new System.ComponentModel.BackgroundWorker();
            this.processIdLabel = new System.Windows.Forms.Label();
            this.processIdValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fpsValues = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentFpsLimit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentRenderScale = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.renderScaleValues = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.processStatusLabel = new System.Windows.Forms.Label();
            this.processStatusValue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchAndInject
            // 
            this.searchAndInject.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchAndInjectDoWork);
            // 
            // processIdLabel
            // 
            this.processIdLabel.AutoSize = true;
            this.processIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.processIdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.processIdLabel.ForeColor = System.Drawing.Color.Silver;
            this.processIdLabel.Location = new System.Drawing.Point(12, 9);
            this.processIdLabel.Name = "processIdLabel";
            this.processIdLabel.Size = new System.Drawing.Size(68, 15);
            this.processIdLabel.TabIndex = 0;
            this.processIdLabel.Text = "Process ID:";
            // 
            // processIdValue
            // 
            this.processIdValue.AutoSize = true;
            this.processIdValue.BackColor = System.Drawing.Color.Transparent;
            this.processIdValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.processIdValue.ForeColor = System.Drawing.Color.Silver;
            this.processIdValue.Location = new System.Drawing.Point(86, 9);
            this.processIdValue.Name = "processIdValue";
            this.processIdValue.Size = new System.Drawing.Size(64, 15);
            this.processIdValue.TabIndex = 1;
            this.processIdValue.Text = "Not Found";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose:";
            // 
            // fpsValues
            // 
            this.fpsValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fpsValues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fpsValues.FormattingEnabled = true;
            this.fpsValues.Location = new System.Drawing.Point(74, 46);
            this.fpsValues.Name = "fpsValues";
            this.fpsValues.Size = new System.Drawing.Size(64, 23);
            this.fpsValues.TabIndex = 3;
            this.fpsValues.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current:";
            // 
            // currentFpsLimit
            // 
            this.currentFpsLimit.AutoSize = true;
            this.currentFpsLimit.BackColor = System.Drawing.Color.Transparent;
            this.currentFpsLimit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentFpsLimit.Location = new System.Drawing.Point(74, 19);
            this.currentFpsLimit.Name = "currentFpsLimit";
            this.currentFpsLimit.Size = new System.Drawing.Size(64, 15);
            this.currentFpsLimit.TabIndex = 5;
            this.currentFpsLimit.Text = "Not Found";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Current:";
            // 
            // currentRenderScale
            // 
            this.currentRenderScale.AutoSize = true;
            this.currentRenderScale.BackColor = System.Drawing.Color.Transparent;
            this.currentRenderScale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentRenderScale.Location = new System.Drawing.Point(74, 19);
            this.currentRenderScale.Name = "currentRenderScale";
            this.currentRenderScale.Size = new System.Drawing.Size(64, 15);
            this.currentRenderScale.TabIndex = 7;
            this.currentRenderScale.Text = "Not Found";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Choose: ";
            // 
            // renderScaleValues
            // 
            this.renderScaleValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderScaleValues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.renderScaleValues.FormattingEnabled = true;
            this.renderScaleValues.Location = new System.Drawing.Point(74, 46);
            this.renderScaleValues.Name = "renderScaleValues";
            this.renderScaleValues.Size = new System.Drawing.Size(64, 23);
            this.renderScaleValues.TabIndex = 9;
            this.renderScaleValues.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fpsValues);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.currentFpsLimit);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 91);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FPS Limit";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.renderScaleValues);
            this.groupBox2.Controls.Add(this.currentRenderScale);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 91);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Render Scale";
            // 
            // processStatusLabel
            // 
            this.processStatusLabel.AutoSize = true;
            this.processStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.processStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.processStatusLabel.ForeColor = System.Drawing.Color.Silver;
            this.processStatusLabel.Location = new System.Drawing.Point(12, 24);
            this.processStatusLabel.Name = "processStatusLabel";
            this.processStatusLabel.Size = new System.Drawing.Size(45, 15);
            this.processStatusLabel.TabIndex = 12;
            this.processStatusLabel.Text = "Status:";
            // 
            // processStatusValue
            // 
            this.processStatusValue.AutoSize = true;
            this.processStatusValue.BackColor = System.Drawing.Color.Transparent;
            this.processStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.processStatusValue.ForeColor = System.Drawing.Color.Red;
            this.processStatusValue.Location = new System.Drawing.Point(86, 24);
            this.processStatusValue.Name = "processStatusValue";
            this.processStatusValue.Size = new System.Drawing.Size(43, 15);
            this.processStatusValue.TabIndex = 13;
            this.processStatusValue.Text = "Closed";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MHRiseTrainer.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(284, 291);
            this.Controls.Add(this.processStatusValue);
            this.Controls.Add(this.processStatusLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.processIdValue);
            this.Controls.Add(this.processIdLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 330);
            this.MinimumSize = new System.Drawing.Size(300, 330);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MH Rise Trainer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker searchAndInject;
        private Label processIdLabel;
        private Label processIdValue;
        private Label label1;
        private ComboBox fpsValues;
        private Label label2;
        private Label currentFpsLimit;
        private Label label4;
        private Label currentRenderScale;
        private Label label6;
        private ComboBox renderScaleValues;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label processStatusLabel;
        private Label processStatusValue;
    }
}