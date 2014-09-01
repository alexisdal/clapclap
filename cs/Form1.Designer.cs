namespace clap_clap
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.bufferLengthLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lowerBoundTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.upperBoundTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.soundDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.play = new System.Windows.Forms.Button();
            this.listenTextBox = new System.Windows.Forms.TextBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buffer (ms)";
            // 
            // bufferLengthLabel
            // 
            this.bufferLengthLabel.AutoSize = true;
            this.bufferLengthLabel.Location = new System.Drawing.Point(137, 64);
            this.bufferLengthLabel.Name = "bufferLengthLabel";
            this.bufferLengthLabel.Size = new System.Drawing.Size(40, 17);
            this.bufferLengthLabel.TabIndex = 0;
            this.bufferLengthLabel.Text = "5000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Listen (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "LowerBound (0->1)";
            // 
            // lowerBoundTextBox
            // 
            this.lowerBoundTextBox.Location = new System.Drawing.Point(361, 61);
            this.lowerBoundTextBox.Name = "lowerBoundTextBox";
            this.lowerBoundTextBox.Size = new System.Drawing.Size(49, 22);
            this.lowerBoundTextBox.TabIndex = 1;
            this.lowerBoundTextBox.Text = "0.95";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "UpperBound (0->1)";
            // 
            // upperBoundTextBox
            // 
            this.upperBoundTextBox.Location = new System.Drawing.Point(361, 89);
            this.upperBoundTextBox.Name = "upperBoundTextBox";
            this.upperBoundTextBox.Size = new System.Drawing.Size(49, 22);
            this.upperBoundTextBox.TabIndex = 1;
            this.upperBoundTextBox.Text = "0.05";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(303, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // soundDevicesComboBox
            // 
            this.soundDevicesComboBox.FormattingEnabled = true;
            this.soundDevicesComboBox.Location = new System.Drawing.Point(26, 16);
            this.soundDevicesComboBox.Name = "soundDevicesComboBox";
            this.soundDevicesComboBox.Size = new System.Drawing.Size(315, 24);
            this.soundDevicesComboBox.TabIndex = 4;
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(361, 16);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(58, 24);
            this.play.TabIndex = 5;
            this.play.Text = "record";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // listenTextBox
            // 
            this.listenTextBox.Location = new System.Drawing.Point(136, 86);
            this.listenTextBox.Name = "listenTextBox";
            this.listenTextBox.Size = new System.Drawing.Size(49, 22);
            this.listenTextBox.TabIndex = 1;
            this.listenTextBox.Text = "100";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(365, 146);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(0, 17);
            this.volumeLabel.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 183);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "volumes";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(431, 129);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 324);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.play);
            this.Controls.Add(this.soundDevicesComboBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listenTextBox);
            this.Controls.Add(this.upperBoundTextBox);
            this.Controls.Add(this.lowerBoundTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bufferLengthLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.label1);
            this.Name = "ClapClap";
            this.Text = "ClapClap";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bufferLengthLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lowerBoundTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox upperBoundTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox soundDevicesComboBox;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.TextBox listenTextBox;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

